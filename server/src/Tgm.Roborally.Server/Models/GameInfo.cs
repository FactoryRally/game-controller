/*
 * Robot Rally Game logic engine
 *
 * This api controlls the flow of a game and provides it's data. It is desiged to be RESTfull so the structure works simmilar as file system. The service will run and only work in a local network, `game.host` is the IP of the Computer hosting the game and will be found via a IP scan
 *
 * The version of the OpenAPI document: v2.2.0b0
 * Contact: nbrugger@student.tgm.ac.at
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Tgm.Roborally.Server.Engine;

namespace Tgm.Roborally.Server.Models {
	/// <summary>
	///     Describes the current state of the game. It does not includes the gamedata (like players/poitions/field) but
	///     general information.  This is read only
	/// </summary>
	[DataContract]
	public class GameInfo : IEquatable<GameInfo> {
		private readonly GameLogic _ref;

		public GameInfo(GameLogic game) {
			_ref = game;
		}

		/// <summary>
		///     The time passed since the game started in secconds. If the game is not started it will be &#x60;0&#x60;
		/// </summary>
		/// <value>The time passed since the game started in secconds. If the game is not started it will be &#x60;0&#x60;</value>
		[Required]
		[DataMember(Name = "passed-time", EmitDefaultValue = true)]
		public long PassedTime {
			get {
				if (_startTime == 0)
					return -1;
				return (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - _startTime) / 1000;
			}
		}

		private long _startTime;

		/// <summary>
		///     Gets or Sets State
		/// </summary>
		[Required]
		[DataMember(Name = "state", EmitDefaultValue = true)]
		public GameState State => _ref.State;

		/// <summary>
		///     Not every game can be connected to hardware (for example to many bots)  If this is true it means you can use this
		///     game with hardware
		/// </summary>
		/// <value>
		///     Not every game can be connected to hardware (for example to many bots)  If this is true it means you can use
		///     this game with hardware
		/// </value>
		[Required]
		[DataMember(Name = "hardware-compatible", EmitDefaultValue = true)]
		public bool HardwareCompatible => _ref.Hardware.Compatible;

		/// <summary>
		///     This id uniquely identifys the player (in a game).   **Not** to be confused with the &#x60;uid&#x60; which is used
		///     for authentication
		/// </summary>
		/// <value>
		///     This id uniquely identifys the player (in a game).   **Not** to be confused with the &#x60;uid&#x60; which is
		///     used for authentication
		/// </value>
		[Required]
		[Range(0, 8)]
		[DataMember(Name = "player-on-turn", EmitDefaultValue = true)]
		public int PlayerOnTurn => _ref.playerOnTurn;

		/// <summary>
		///     The default rule for names in the game
		/// </summary>
		/// <value>The default rule for names in the game</value>
		[Required]
		[RegularExpression("[A-Za-z]+[A-Za-z0-9_ -]+[A-Za-z0-9]{1}")]
		[StringLength(13, MinimumLength = 3)]
		[DataMember(Name                = "name", EmitDefaultValue = true)]
		public string Name => _ref.Name;

		/// <summary>
		///     The maximum count of players that can participate in this game
		/// </summary>
		/// <value>The maximum count of players that can participate in this game</value>
		[Required]
		[Range(1, 10)]
		[DataMember(Name = "max-players", EmitDefaultValue = true)]
		public int MaxPlayers => _ref.MaxPlayers;

		/// <summary>
		///     The numbers of players in the game
		/// </summary>
		/// <value>The numbers of players in the game</value>
		[Required]
		[Range(0, 10)]
		[DataMember(Name = "current-players", EmitDefaultValue = true)]
		public int CurrentPlayers => _ref.PlayerCount;

		/// <summary>
		///     Gets or Sets ExecutionInfo
		/// </summary>
		[Required]
		[DataMember(Name = "executionInfo", EmitDefaultValue = true)]
		public GameInfoExecutionInfo ExecutionInfo => _ref.executionState;

		/// True if the game has a password in order to join 
		/// </summary>
		/// <value>True if the game has a password in order to join </value>
		[Required]
		[DataMember(Name = "password-protected", EmitDefaultValue = true)]
		public bool PasswordProtected => !string.IsNullOrEmpty(_ref.Password);

		public long Started {
			set => _startTime = value;
		}

		/// <summary>
		/// <summary>
		///     Returns true if GameInfo instances are equal
		/// </summary>
		/// <param name="other">Instance of GameInfo to be compared</param>
		/// <returns>Boolean</returns>
		public bool Equals(GameInfo other) {
			if (other is null) return false;
			if (ReferenceEquals(this, other)) return true;

			return
				(
					PassedTime == other.PassedTime ||
					PassedTime.Equals(other.PassedTime)
				) &&
				(
					State == other.State ||
					State.Equals(other.State)
				) &&
				(
					HardwareCompatible == other.HardwareCompatible ||
					HardwareCompatible.Equals(other.HardwareCompatible)
				) &&
				(
					PlayerOnTurn == other.PlayerOnTurn ||
					PlayerOnTurn.Equals(other.PlayerOnTurn)
				) &&
				(
					Name == other.Name ||
					Name != null &&
					Name.Equals(other.Name)
				) &&
				(
					MaxPlayers == other.MaxPlayers ||
					MaxPlayers.Equals(other.MaxPlayers)
				) &&
				(
					CurrentPlayers == other.CurrentPlayers ||
					CurrentPlayers.Equals(other.CurrentPlayers)
				) &&
				(
					ExecutionInfo == other.ExecutionInfo ||
					ExecutionInfo != null &&
					ExecutionInfo.Equals(other.ExecutionInfo)
				);
		}

		/// <summary>
		///     Returns the string presentation of the object
		/// </summary>
		/// <returns>String presentation of the object</returns>
		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			sb.Append("class GameInfo {\n");
			sb.Append("  PassedTime: ").Append(PassedTime).Append("\n");
			sb.Append("  State: ").Append(State).Append("\n");
			sb.Append("  HardwareCompatible: ").Append(HardwareCompatible).Append("\n");
			sb.Append("  PlayerOnTurn: ").Append(PlayerOnTurn).Append("\n");
			sb.Append("  Name: ").Append(Name).Append("\n");
			sb.Append("  MaxPlayers: ").Append(MaxPlayers).Append("\n");
			sb.Append("  CurrentPlayers: ").Append(CurrentPlayers).Append("\n");
			sb.Append("  ExecutionInfo: ").Append(ExecutionInfo).Append("\n");
			sb.Append("}\n");
			return sb.ToString();
		}

		/// <summary>
		///     Returns the JSON string presentation of the object
		/// </summary>
		/// <returns>JSON string presentation of the object</returns>
		public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);

		/// <summary>
		///     Returns true if objects are equal
		/// </summary>
		/// <param name="obj">Object to be compared</param>
		/// <returns>Boolean</returns>
		public override bool Equals(object obj) {
			if (obj is null) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((GameInfo) obj);
		}

		/// <summary>
		///     Gets the hash code
		/// </summary>
		/// <returns>Hash code</returns>
		public override int GetHashCode() {
			unchecked // Overflow is fine, just wrap
			{
				int hashCode = 41;
				// Suitable nullity checks etc, of course :)

				hashCode = hashCode * 59 + PassedTime.GetHashCode();

				hashCode = hashCode * 59 + State.GetHashCode();

				hashCode = hashCode * 59 + HardwareCompatible.GetHashCode();

				hashCode = hashCode * 59 + PlayerOnTurn.GetHashCode();
				if (Name != null)
					hashCode = hashCode * 59 + Name.GetHashCode();

				hashCode = hashCode * 59 + MaxPlayers.GetHashCode();

				hashCode = hashCode * 59 + CurrentPlayers.GetHashCode();
				if (ExecutionInfo != null)
					hashCode = hashCode * 59 + ExecutionInfo.GetHashCode();
				return hashCode;
			}
		}

		#region Operators

		#pragma warning disable 1591

		public static bool operator ==(GameInfo left, GameInfo right) => Equals(left, right);

		public static bool operator !=(GameInfo left, GameInfo right) => !Equals(left, right);

		#pragma warning restore 1591

		#endregion Operators
	}
}