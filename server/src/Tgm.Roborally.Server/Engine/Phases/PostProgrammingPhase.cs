using System.Collections.Generic;
using System.Threading;
using Tgm.Roborally.Server.Models;

namespace Tgm.Roborally.Server.Engine.Phases {
	public class PostProgrammingPhase : GamePhase {
		protected override object Information => null;

		public override GameState NewState => GameState.PLAYING;

		protected override GamePhase Run(GameLogic game) {
			game.executionState.CurrentRegister = 0;
			Thread.Sleep(game.AnimationDelay);
			return new PreExecutionPhase();
		}

		public override void Notify(ActionType action) {
			//TODO
		}

		public override bool Notify(GenericEvent ev) => false;

		public override IList<EntityEventOportunity> GetPossibleActions(int robot, int player) =>
			new List<EntityEventOportunity>();
	}
}