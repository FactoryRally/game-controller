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
	///     A upgrade is a module making a robot stronger
	/// </summary>
	[DataContract]
	public class Upgrade : IEquatable<Upgrade> {
		/// <summary>
		///     The energy cost to buy this upgrade
		/// </summary>
		/// <value>The energy cost to buy this upgrade</value>
		[Required]
		[Range(0, 5)]
		[DataMember(Name = "cost", EmitDefaultValue = true)]
		public int Cost { get; set; } = 2;

		/// <summary>
		///     The ame to display for this Upgrade. ***Not*** unique (identifying)
		/// </summary>
		/// <value>The ame to display for this Upgrade. ***Not*** unique (identifying)</value>
		[Required]
		[StringLength(27, MinimumLength = 2)]
		[DataMember(Name                = "name", EmitDefaultValue = true)]
		public string Name { get; set; }

		/// <summary>
		///     if true the card belongs to the player for the rest of the game
		/// </summary>
		/// <value>if true the card belongs to the player for the rest of the game</value>
		[DataMember(Name = "permanent", EmitDefaultValue = true)]
		public bool Permanent { get; set; } = true;

		/// <summary>
		///     A description about the effect of the card. Variables are using the format &#x60;{name}&#x60; where *name* refers
		///     to the names in &#x60;values&#x60;.
		/// </summary>
		/// <value>
		///     A description about the effect of the card. Variables are using the format &#x60;{name}&#x60; where *name*
		///     refers to the names in &#x60;values&#x60;.
		/// </value>
		[MaxLength(300)]
		[DataMember(Name = "description", EmitDefaultValue = true)]
		public string Description { get; set; } = "null";

		/// <summary>
		///     If the Upgrade is not permanent this variable defines the number of rounds this Upgrade works
		/// </summary>
		/// <value>If the Upgrade is not permanent this variable defines the number of rounds this Upgrade works</value>
		[Range(1, 10)]
		[DataMember(Name = "rounds", EmitDefaultValue = true)]
		public int Rounds { get; set; }

		/// <summary>
		///     Defines number values for the upgrade.&lt;br&gt;Example: Effect: \&quot;You have {registers} additonal Registers\
		///     &quot;&lt;br&gt; &#x60;{registers}&#x60; is the number of the regsiters (that will be added) and the exact value
		///     will be defined in here (&#x60;values&#x60;)
		/// </summary>
		/// <value>
		///     Defines number values for the upgrade.&lt;br&gt;Example: Effect: \&quot;You have {registers} additonal
		///     Registers\&quot;&lt;br&gt; &#x60;{registers}&#x60; is the number of the regsiters (that will be added) and the
		///     exact value will be defined in here (&#x60;values&#x60;)
		/// </value>
		[DataMember(Name = "values", EmitDefaultValue = true)]
		public List<Pair> Values { get; set; }

		/// <summary>
		///     Gets or Sets Type
		/// </summary>
		[Required]
		[DataMember(Name = "type", EmitDefaultValue = true)]
		public UpgradeType Type { get; set; }

		/// <summary>
		///     The id of an upgrade. **Unique**
		/// </summary>
		/// <value>The id of an upgrade. **Unique**</value>
		[Range(0, 10000)]
		[DataMember(Name = "id", EmitDefaultValue = true)]
		public int Id { get; set; }

		/// <summary>
		///     Returns true if Upgrade instances are equal
		/// </summary>
		/// <param name="other">Instance of Upgrade to be compared</param>
		/// <returns>Boolean</returns>
		public bool Equals(Upgrade other) {
			if (other is null) return false;
			if (ReferenceEquals(this, other)) return true;

			return
				(
					Cost == other.Cost ||
					Cost.Equals(other.Cost)
				) &&
				(
					Name == other.Name ||
					Name != null &&
					Name.Equals(other.Name)
				) &&
				(
					Permanent == other.Permanent ||
					Permanent.Equals(other.Permanent)
				) &&
				(
					Description == other.Description ||
					Description != null &&
					Description.Equals(other.Description)
				) &&
				(
					Rounds == other.Rounds ||
					Rounds.Equals(other.Rounds)
				) &&
				(
					Values == other.Values ||
					Values       != null &&
					other.Values != null &&
					Values.SequenceEqual(other.Values)
				) &&
				(
					Type == other.Type ||
					Type.Equals(other.Type)
				) &&
				(
					Id == other.Id ||
					Id.Equals(other.Id)
				);
		}

		/// <summary>
		///     Returns the string presentation of the object
		/// </summary>
		/// <returns>String presentation of the object</returns>
		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			sb.Append("class Upgrade {\n");
			sb.Append("  Cost: ").Append(Cost).Append("\n");
			sb.Append("  Name: ").Append(Name).Append("\n");
			sb.Append("  Permanent: ").Append(Permanent).Append("\n");
			sb.Append("  Description: ").Append(Description).Append("\n");
			sb.Append("  Rounds: ").Append(Rounds).Append("\n");
			sb.Append("  Values: ").Append(Values).Append("\n");
			sb.Append("  Type: ").Append(Type).Append("\n");
			sb.Append("  Id: ").Append(Id).Append("\n");
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
			return obj.GetType() == GetType() && Equals((Upgrade) obj);
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

				hashCode = hashCode * 59 + Cost.GetHashCode();
				if (Name != null)
					hashCode = hashCode * 59 + Name.GetHashCode();

				hashCode = hashCode * 59 + Permanent.GetHashCode();
				if (Description != null)
					hashCode = hashCode * 59 + Description.GetHashCode();

				hashCode = hashCode * 59 + Rounds.GetHashCode();
				if (Values != null)
					hashCode = hashCode * 59 + Values.GetHashCode();

				hashCode = hashCode * 59 + Type.GetHashCode();

				hashCode = hashCode * 59 + Id.GetHashCode();
				return hashCode;
			}
		}

		#region Operators

		#pragma warning disable 1591

		public static bool operator ==(Upgrade left, Upgrade right) => Equals(left, right);

		public static bool operator !=(Upgrade left, Upgrade right) => !Equals(left, right);

		#pragma warning restore 1591

		#endregion Operators
	}
}