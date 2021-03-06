using System;
using System.Collections.Generic;
using System.Threading;
using Tgm.Roborally.Server.Models;

namespace Tgm.Roborally.Server.Engine.Phases {
	public class UpgradeShopPhase : GamePhase {
		private const      int         TIME      = 20000;
		private readonly   object      _listener = new object();
		private            int         _activePlayer;
		private            long        _endTime;
		private            bool        _executed;
		private            bool        _shopFilled;

		protected override RoundPhase? Cathegory => RoundPhase.Upgrade;

		protected override object      Information => new UpgradeInfo();

		public override GameState NewState => GameState.PLAYING;

		protected override GamePhase Run(GameLogic game) {
			game.Upgrades.FillShop();
			_shopFilled = true;
			//TODO calculate order based on prio beacon
			foreach (int activePlayer in game.PlayerIds) {
				_activePlayer = activePlayer;
				_endTime      = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + TIME;
				_executed     = false;
				game.CommitEvent(new TimerStartEvent() {
					EndTime = _endTime,
					Duration = TIME,
					Passable = true,
					RobotsActive = new List<int>(){game.GetPlayer(_activePlayer).ControlledEntities[0]},
					Subject = TimerStartEvent.SubjectEnum.BuyUpgrades
				});
				lock (_listener) {
					Monitor.Wait(_listener, TIME);
					if (!_executed) {
						game.CommitEvent(new TimeElapsedEvent {
							OriginalDuration = TIME,
							Context          = ("player:" + _activePlayer, "action:buy_upgrade")
						});
						Thread.Sleep(game.AnimationDelay);
					}
				}
			}

			return new PreProgrammingPhase(); //todo
		}

		public override void Notify(ActionType action) {
		}

		public override bool Notify(GenericEvent ev) {
			if (ev.GetEventType() == EventType.UpgradePurchase) {
				PurchaseEvent @event = ev.Data as PurchaseEvent;
				if (@event.Player != _activePlayer)
					throw new GameFlowException(GameFlowException.BAD_EVENT);
				lock (_listener) {
					_executed = true;
					Monitor.Pulse(_listener);
				}

				return true;
			}

			if (ev.GetEventType() == EventType.ActivateUpgrade) {
				//TODO handle
				return true;
			}

			return ev.GetEventType() == EventType.TimeElapsed ||
				   ev.GetEventType() == EventType.ClearShop ||
				   ev.GetEventType() == EventType.FillShop ||
				   ev.GetEventType() == EventType.TimerStart;
		}

		public override IList<EntityEventOportunity> GetPossibleActions(int robot, int player) {
			if (Game.State == GameState.BREAK || player != _activePlayer || !_shopFilled)
				return new List<EntityEventOportunity>();

			return new List<EntityEventOportunity> {
				new EntityEventOportunity {
					EndTime  = _endTime,
					TimeLeft = _endTime - DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - 30,
					Type     = EntityActionType.BuyUpgrade
				},
				new EntityEventOportunity {
					EndTime = _endTime,
					TimeLeft = _endTime - DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - 30, //-30 to correct timing with ping
					Type = EntityActionType.Pass
				}
			};
		}

		public class UpgradeInfo {
			public int timer => TIME;
		}
	}
}