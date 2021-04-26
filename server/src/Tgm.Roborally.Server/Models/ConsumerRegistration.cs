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
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Tgm.Roborally.Server.Models {
	/// <summary>
	///     Data to describe a consumer
	/// </summary>
	[DataContract]
	public class ConsumerRegistration : IEquatable<ConsumerRegistration> {
		/// <summary>
		///     The default rule for names in the game
		/// </summary>
		/// <value>The default rule for names in the game</value>
		[Required]
		[RegularExpression("[A-Za-z]+[A-Za-z0-9_ -]+[A-Za-z0-9]{1}")]
		[StringLength(13, MinimumLength = 3)]
		[DataMember(Name                = "name", EmitDefaultValue = true)]
		public string Name { get; set; }

		/// <summary>
		///     A description what the consumer is used for (and or is)
		/// </summary>
		/// <value>A description what the consumer is used for (and or is)</value>
		[Required]
		[StringLength(10000, MinimumLength = 5)]
		[DataMember(Name                   = "description", EmitDefaultValue = true)]
		public string Description { get; set; }

		/// <summary>
		///     Returns true if ConsumerRegistration instances are equal
		/// </summary>
		/// <param name="other">Instance of ConsumerRegistration to be compared</param>
		/// <returns>Boolean</returns>
		public bool Equals(ConsumerRegistration other) {
			if (other is null) return false;
			if (ReferenceEquals(this, other)) return true;

			return
				(
					Name == other.Name ||
					Name != null &&
					Name.Equals(other.Name)
				) &&
				(
					Description == other.Description ||
					Description != null &&
					Description.Equals(other.Description)
				);
		}

		/// <summary>
		///     Returns the string presentation of the object
		/// </summary>
		/// <returns>String presentation of the object</returns>
		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			sb.Append("class ConsumerRegistration {\n");
			sb.Append("  Name: ").Append(Name).Append("\n");
			sb.Append("  Description: ").Append(Description).Append("\n");
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
			return obj.GetType() == GetType() && Equals((ConsumerRegistration) obj);
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
				if (Name != null)
					hashCode = hashCode * 59 + Name.GetHashCode();
				if (Description != null)
					hashCode = hashCode * 59 + Description.GetHashCode();
				return hashCode;
			}
		}

		#region Operators

		#pragma warning disable 1591

		public static bool operator ==(ConsumerRegistration left, ConsumerRegistration right) => Equals(left, right);

		public static bool operator !=(ConsumerRegistration left, ConsumerRegistration right) => !Equals(left, right);

		#pragma warning restore 1591

		#endregion Operators
	}
}