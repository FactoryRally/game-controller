using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Tgm.Roborally.Server.Engine.Abstraction.Managers;
using Tgm.Roborally.Server.Engine.Phases;
using Tgm.Roborally.Server.Engine.Statement;
using Tgm.Roborally.Server.Models;

namespace Tgm.Roborally.Server.Engine.Managers {
	/// <summary>
	/// Manages the registers and execution of the programming cards
	/// </summary>
	public class ProgrammingManager : IProgrammingManager {
		/// <summary>
		/// Maps additional values to the commands. This is the pool it contails ALL the cards in the game.
		///  <br/>
		/// * Key: CardID, <br/>
		/// * Value: (TheCommandObject, LocationOfTheCard, IdOfTheOwningEntity)
		/// 
		/// </summary>
		private readonly
			Dictionary<int, (RobotCommand command, CardLocation location, int owner)> _pool = new();

		private readonly GameLogic _game;

		public ProgrammingManager(GameLogic game) {
			_game = game;
		}


		public  ISet<int>              IDs   => _pool.Keys.ToHashSet();
		public  IList<RobotCommand>    Cards => _pool.Values.Select(selector: e => e.command).ToList();
		private Dictionary<int, int[]> Registers = new();

		public IImmutableSet<int> Deck => _pool
								 .Where(predicate: e => e.Value.location == CardLocation.DECK)
								 .Select(selector: e => e.Key)
								 .ToImmutableHashSet();


		/// <summary>
		/// Get the Command for the regarding id
		/// </summary>
		/// <param name="robotId">the id of the command</param>
		public RobotCommand this[int robotId] => !_pool.ContainsKey(robotId) ? null : _pool[robotId].command;

		private Random rand = new Random();
		private void Shuffle() {
			Dictionary<int, (RobotCommand, CardLocation, int)> cache =
				_pool.ToDictionary(keySelector: e => e.Key, elementSelector: e => e.Value);
			_pool.Clear();
			cache = cache.OrderBy(keySelector: e => rand.Next())
						 .ToDictionary(keySelector: item => item.Key, elementSelector: item => item.Value);
			;
			foreach (KeyValuePair<int, (RobotCommand, CardLocation, int)> pair in cache)
				_pool.Add(pair.Key, pair.Value);
		}


		/// <inheritdoc />
		public void AddCard(int number, RobotCommand command) {
			for (int i = 0; i < number; i++)
				_pool[_pool.Count] = (command, CardLocation.DECK, -1);
		}

		public void Clear(int robotId) {
			int[] regs = GetRegister(robotId);
			for (int i = 0; i < regs.Length; i++) {
				int oldCard = regs[i];
				if (oldCard != -1) {
					var valueTuple = _pool[oldCard];
					valueTuple.location = CardLocation.DISCARDED;
					valueTuple.owner    = -1;
					_pool[oldCard]      = valueTuple;
				}
				regs[i] = -1;
				_game.CommitEvent(new ChangeRegisterEvent {
					Action   = ChangeRegisterEvent.ActionEnum.Clear,
					Register = i
				});
			}

			Registers[robotId] = regs;
		}

		public int[] GetRegister(int robotId) {
			InitMissingRegisters(robotId);
			return Registers[robotId];
		}

		public void Draw(int robot) {
			RobotInfo robo = (RobotInfo) _game.Entitys[robot];

			List<int> cards = new List<int>();
			for (int i = 0; i < robo.Health - 1; i++) {
				if (Deck.Count == 0)
					ReShuffleDeck();
				if (Deck.Count == 0) {
					Console.Out.WriteLine("pool: \n" +
										  string.Join(Environment.NewLine,
													  _pool.Select(selector: e => $"[{e.Key} -> {e.Value}]")));
					GameFlowException ex = new GameFlowException(GameFlowException.NO_DECK);
					throw ex;
				}

				int[]                                                    deck   = Deck.ToArray();
				int                                                      cardId = deck[rand.Next(deck.Length)];
				var elem   = _pool[cardId];
				elem.owner    = robot;
				elem.location = CardLocation.IN_HAND;
				_pool[cardId] = elem;
				cards.Add(cardId);
			}

			_game.CommitEvent(new DrawCardEvent {
				Cards  = cards,
				Count  = cards.Count,
				Robot = robot //todo rename to robot
			});
		}

		/// <summary>
		/// Recycles the DISCARDED cards and reinserts them into the deck
		/// </summary>
		private void ReShuffleDeck() {
			foreach (int id in _pool.Keys) {
				if (_pool[id].location == CardLocation.DISCARDED) {
					(RobotCommand command, CardLocation location, int owner) stub = _pool[id];
					stub.location = CardLocation.DECK;
					_pool[id]     = stub;
				}
			}

			Shuffle();
		}

		public int[] GetHandCards(int rid) => _pool
											  .Where(predicate: e =>
														 e.Value.location == CardLocation.IN_HAND &&
														 e.Value.owner    == rid)
											  .Select(selector: e => e.Key)
											  .ToArray();

		public void SetRegister(int rid, int register, int card) {
			(RobotCommand command, CardLocation location, int owner) entry = _pool[card];
			entry.location           = CardLocation.IN_REGISTER;
			entry.owner              = rid;
			_pool[card]              = entry;
			InitMissingRegisters(rid);
			Registers[rid][register] = card;
			_game.CommitEvent(new ChangeRegisterEvent {
				Action   = ChangeRegisterEvent.ActionEnum.Fill,
				Card     = card,
				Register = register,
				RobotId = rid
			});
		}

		private void InitMissingRegisters(int rid) {
			if (!Registers.ContainsKey(rid)) {
				Registers[rid] = new int[5];
				Clear(rid);
			}
		}

		public void Setup() {
		}
	}

	internal enum CardLocation {
		DECK = 0,
		DISCARDED,
		IN_HAND,
		IN_REGISTER
	}
}