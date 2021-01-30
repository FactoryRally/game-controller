using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using Tgm.Roborally.Server.Engine.Exceptions;
using Tgm.Roborally.Server.Models;

namespace Tgm.Roborally.Server.Engine {
	public class GameLogic {
		private readonly GameThread                            thread;
		private          GameState                             _state = GameState.LOBBY;
		private          Dictionary<string, int>               _consumerKeys;
		private          Dictionary<int, ConsumerRegistration> _consumers;
		public           int                                   Id;
		public           int                                   playerOnTurn;


		public GameLogic(GameRules r) {
			Rules         = r;
			EventManager  = new EventManager(this);
			ActionHandler = new GameActionHandler(this);
			Hardware      = new HardwareManager(this);
			Info          = new GameInfo(this);
			Game          = new Game(this);
			thread        = new GameThread(this);
			Entitys       = new EntityManager();
			thread.Start();
		}

		public GameState LastState { get; private set; }

		public string            Password      => Rules.Password;
		public List<Player>      Players       { get; } = new List<Player>();
		public Map               Map           { get; private set; }
		public EventManager      EventManager  { get; }
		public HardwareManager   Hardware      { get; }
		public EntityManager     Entitys       { get; }
		public GameActionHandler ActionHandler { get; }
		public Game              Game          { get; }
		public GameInfo          Info          { get; }

		public GameState State {
			get => _state;
			set {
				LastState = State;
				_state    = value;
			}
		}


		public GameRules Rules { get; }

		public bool      PlayerNamesVisible => Rules.PlayerNamesVisible;
		public string    Name               => Rules.Name;
		public int       MaxPlayers         => Rules.MaxPlayers;
		public List<int> PlayerIds          => Players.Select(selector: e => e.Id).ToList();

		public bool        Joinable  => State == GameState.LOBBY && Players.Count < MaxPlayers;

		public Dictionary<int, ConsumerRegistration> Consumers => _consumers;

		public void CommitEvent(GenericEvent e) {
			EventManager.Notify(e);
			thread.Notify(e);
		}

		public void CommitEvent(Event e) => CommitEvent(new GenericEvent(e));

		public int NewPlayerID() {
			int id;
			do {
				id = new Random().Next(1, MaxPlayers + 1);
			} while (GetPlayer(id) != null);

			return id;
		}

		public Player GetPlayer(int id) {
			try {
				return Players.Find(match: e => e.Id == id);
			}
			catch (ArgumentNullException e) {
				return null;
			}
		}

		public Player Join(string name) => Join(null, name);

		public Player Join(string password, string name) {
			if (!Joinable) throw new GameNotJoinableException("The game cannot be joined at the moment");

			if ((password == null && Rules.Password != null) ||(Rules.Password != null && password != null && !password.Equals(Password)))
				throw new AuthenticationException("The provided password was wrong or null");

			Player p = new Player {Id = NewPlayerID(), DisplayName = name};
			Players.Add(p);

			GenericEvent e = new GenericEvent(EventType.Join);
			e.Data = new JoinEvent {
				JoinedId = p.Id,
				Unjoin   = false
			};
			CommitEvent(e);
			return p;
		}

		public void RemovePlayer(int playerId) {
			if (_state == GameState.LOBBY)
				Players.Remove(GetPlayer(playerId));
			else if (_state == GameState.PLAYING || _state == GameState.PLANNING) {
				Player p = GetPlayer(playerId);
				p.Active = false;
			}
			else
				throw new PlayerNotRemoveableException("The player is not removeable in this state of the game");
		}

		public void StartGame() {
			if (_state != GameState.LOBBY) throw new WrongStateException(GameState.LOBBY, _state, "Start Game");

			if (Players.Count == 0) throw new PlayerCountException(">0", Players.Count, "Start Game");

			if (Players.Count < MaxPlayers && Rules.FillWithBots) {
				//Todo fill with bots
			}

			Map = new Map(20, 20);
			CommitEvent(new ActionEvent(EventType.GameStart));
		}

		public void NotifyThread(ActionType type) => thread.Notify(type);

		public Player AuthPlayer(string authKey) => Players.Find(match: p => p.auth.Equals(authKey));

		public JoinResponse RegisterConsumer(ConsumerRegistration consumerRegistration) {
			int id;
			do {
				id = new Random().Next(100, 9999);
			} while (_consumers.ContainsKey(id));

			if (_consumers.Count >= 200)
				return null;

			_consumers[id] = consumerRegistration;
			Player pseudo = new Player {
				Id = id
			};
			_consumerKeys[pseudo.auth] = id;
			return new JoinResponse(pseudo);
		}

		public (bool, int) IsConsumer(string authKey) {
			bool a;
			return (a = _consumerKeys.ContainsKey(authKey), a ? _consumerKeys[authKey] : -1);
		}

		public ConsumerRegistration GetConsumer(int resItem2) => _consumers[resItem2];

		public class GameNotJoinableException : Exception {
			public GameNotJoinableException(string theGameCannotBeJoinedAtTheMoment) : base(
				theGameCannotBeJoinedAtTheMoment) {
			}
		}

		public class PlayerNotRemoveableException : Exception {
			public PlayerNotRemoveableException(string? message) : base(message) {
			}
		}
	}
}