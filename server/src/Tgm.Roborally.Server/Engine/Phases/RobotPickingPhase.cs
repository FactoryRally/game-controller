using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Tgm.Roborally.Server.Models;

namespace Tgm.Roborally.Server.Engine.Phases {
	public class RobotPickingPhase : GamePhase {
		protected override object Information => new PickingInformation(PickingMode.RANDOM_DISTRIBUTION);

		public override GameState NewState => GameState.PLANNING;

		protected override GamePhase Run(GameLogic game) {
			//TODO: Later on maybe a more intelligent algorithm will take place here
			//where players can choose their robot type

			List<Robots> available = Enum.GetValues(typeof(Robots)).Cast<Robots>().ToList();
			foreach (Player gamePlayer in game.Players) {
				Robots type = available[0];
				game.Entitys.PickRobo(type, gamePlayer);
				available.Remove(type);
				Thread.Sleep(game.AnimationDelay);
			}

			return new MainPhase();
		}

		public override void Notify(ActionType action) =>
			throw new NotImplementedException("This phase cant be paused (received: " + action + ")");

		public override bool Notify(GenericEvent ev) {
			return ev.GetEventType() == EventType.LockIn;
			throw new NotImplementedException(
				"The picking phase works automaticaly at the moment, no need for events (recived event: " +
				ev.GetEventType()                                                                         + ")");
		}

		public override IList<EntityEventOportunity> GetPossibleActions(int a, int b) =>
			new List<EntityEventOportunity>();
	}

	public class PickingInformation {
		public PickingMode Mode;

		public PickingInformation(PickingMode mode) {
			Mode = mode;
		}
	}

	public enum PickingMode {
		RANDOM_DISTRIBUTION,
		LEAGUE_LIKE_PICKING,
		FIRST_COME_FIRST_SERVE
	}
}