using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Tgm.Roborally.Server.Engine.Abstraction.Managers;
using Tgm.Roborally.Server.Models;
using Action = System.Action;

namespace Tgm.Roborally.Server.Engine {
	public class GameActionHandler : IGameActionHandler {
		private readonly Dictionary<ActionType, Action>    ActionMap = new Dictionary<ActionType, Action>();
		private readonly Dictionary<ActionType, EventType> EventMap  = new Dictionary<ActionType, EventType>();
		private readonly GameLogic                         game;


		public GameActionHandler(GameLogic game) {
			this.game = game;
			InitActionMap();
			InitEventMap();
		}

		private List<ActionType> _Queue { get; } = new List<ActionType>();

		/// <summary>
		/// The index of the last executed Action
		/// </summary>
		public int QueuePos { get; private set; }

		/// <summary>
		/// A list of all Actions that still need to be executed
		/// </summary>
		public List<ActionType> Pending => _Queue.Where(predicate: (e, index) => index >= QueuePos).ToList();

		/// <summary>
		/// A list of all actions that were executed in the past
		/// </summary>
		public List<ActionType> Executed => _Queue.Where(predicate: (e, index) => index < QueuePos).ToList();

		/// <summary>
		/// The Action Queue with all data at once
		/// </summary>
		public List<Models.Action> Queue => _Queue
											.Select(
												selector: (e, i) => new Models.Action {
													Index = i, Executed = i < QueuePos, Type = e
												}).ToList();

		/// <summary>
		/// Execute the next pending action
		/// </summary>
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void ExecuteNext() {
			ActionType type = _Queue[QueuePos++];
			ActionMap[type].Invoke();
			game.CommitEvent(new ActionEvent(EventMap[type]));
			game.NotifyThread(type);
		}

		private void InitActionMap() {
			ActionMap[ActionType.PAUSE]     = () => { game.State = GameState.BREAK; };
			ActionMap[ActionType.UNPAUSE]   = () => { game.State = game.LastState; };
			ActionMap[ActionType.STARTGAME] = () => { game.StartGame(); };
		}

		private void InitEventMap() {
			EventMap[ActionType.PAUSE]     = EventType.Pause;
			EventMap[ActionType.UNPAUSE]   = EventType.Unpause;
			EventMap[ActionType.STARTGAME] = EventType.GameStart;
		}

		/// <summary>
		/// Add an action to be executed FIFO
		/// </summary>
		/// <param name="t">the action to add</param>
		[MethodImpl(MethodImplOptions.Synchronized)]
		public void Add(ActionType t) => _Queue.Add(t);

		public void Setup() {
		}
	}
}