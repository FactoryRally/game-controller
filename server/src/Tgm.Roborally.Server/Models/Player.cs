/*
 * Robot Rally Game logic engine
 *
 * This api controlls the flow of a game and provides it's data. It is desiged to be RESTfull so the structure works simmilar as file system. The service will run and only work in a local network, `game.host` is the IP of the Computer hosting the game and will be found via a IP scan
 *
 * The version of the OpenAPI document: v0.4.1b0
 * Contact: nbrugger@student.tgm.ac.at
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Tgm.Roborally.Server.Models {
	/// <summary>
	///     A player attending in a game. #### Warning This is **not** permanent. It is created and removed with the game (or
	///     with you joining and leaving the game)
	/// </summary>
	[DataContract]
	public class Player : IEquatable<Player> {
		private const string chars = "ABCDEFGHIJKLMNOPQRSTabcdefghijklmnopqrst1234567890-_+?:!";

		/// <summary>
		///     This is the ID used for authentication
		/// </summary>
		public readonly string auth = AuthID();

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
		[DataMember(Name = "id", EmitDefaultValue = true)]
		public int Id { get; set; }

		/// <summary>
		///     The list of entities controlled by this player
		/// </summary>
		/// <value>The list of entities controlled by this player</value>
		[Required]
		[DataMember(Name = "controlled_entities", EmitDefaultValue = true)]
		public List<int> ControlledEntities { get; set; } = new List<int>();

		/// <summary>
		///     Îf this is true rhe player is able to interact at the moment
		/// </summary>
		/// <value>Îf this is true rhe player is able to interact at the moment</value>
		[DataMember(Name = "on-turn", EmitDefaultValue = true)]
		public bool OnTurn { get; set; }

		/// <summary>
		///     Defines if the player is actively playing. If this is false the player does random moves. This is only false if the
		///     player disconnects
		/// </summary>
		/// <value>
		///     Defines if the player is actively playing. If this is false the player does random moves. This is only false if
		///     the player disconnects
		/// </value>
		[DataMember(Name = "active", EmitDefaultValue = true)]
		public bool Active { get; set; } = true;

		/// <summary>
		///     The display name of a player including rules
		/// </summary>
		/// <value>The display name of a player including rules</value>
		[Required]
		[RegularExpression("[A-Za-z0-9_-]+")]
		[StringLength(30, MinimumLength = 3)]
		[DataMember(Name                = "display_name", EmitDefaultValue = true)]
		public string DisplayName { get; set; }

		/// <summary>
		///     Returns true if Player instances are equal
		/// </summary>
		/// <param name="other">Instance of Player to be compared</param>
		/// <returns>Boolean</returns>
		public bool Equals(Player other) {
			if (other is null) return false;
			if (ReferenceEquals(this, other)) return true;

			return
				(
					Id == other.Id ||
					Id.Equals(other.Id)
				) &&
				(
					ControlledEntities == other.ControlledEntities ||
					ControlledEntities       != null &&
					other.ControlledEntities != null &&
					ControlledEntities.SequenceEqual(other.ControlledEntities)
				) &&
				(
					OnTurn == other.OnTurn ||
					OnTurn.Equals(other.OnTurn)
				) &&
				(
					Active == other.Active ||
					Active.Equals(other.Active)
				) &&
				(
					DisplayName == other.DisplayName ||
					DisplayName != null &&
					DisplayName.Equals(other.DisplayName)
				);
		}

		private static string AuthID() {
			Random        r = new Random();
			int           l = r.Next(20) + 20;
			StringBuilder b = new StringBuilder();
			for (int i = 0; i < l; i++) b.Append(chars[r.Next(chars.Length)]);

			return b.ToString();
		}

		/// <summary>
		///     Returns the string presentation of the object
		/// </summary>
		/// <returns>String presentation of the object</returns>
		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			sb.Append("class Player {\n");
			sb.Append("  Id: ").Append(Id).Append("\n");
			sb.Append("  ControlledEntities: ").Append(ControlledEntities).Append("\n");
			sb.Append("  OnTurn: ").Append(OnTurn).Append("\n");
			sb.Append("  Active: ").Append(Active).Append("\n");
			sb.Append("  DisplayName: ").Append(DisplayName).Append("\n");
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
			return obj.GetType() == GetType() && Equals((Player) obj);
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

				hashCode = hashCode * 59 + Id.GetHashCode();
				if (ControlledEntities != null)
					hashCode = hashCode * 59 + ControlledEntities.GetHashCode();

				hashCode = hashCode * 59 + OnTurn.GetHashCode();

				hashCode = hashCode * 59 + Active.GetHashCode();
				if (DisplayName != null)
					hashCode = hashCode * 59 + DisplayName.GetHashCode();
				return hashCode;
			}
		}

		#region Operators

		#pragma warning disable 1591

		public static bool operator ==(Player left, Player right) => Equals(left, right);

		public static bool operator !=(Player left, Player right) => !Equals(left, right);

		#pragma warning restore 1591

		#endregion Operators
	}
}