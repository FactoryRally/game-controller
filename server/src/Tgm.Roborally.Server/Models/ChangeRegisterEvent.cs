/*
 * Robot Rally Game logic engine
 *
 * This api controlls the flow of a game and provides it's data. It is desiged to be RESTfull so the structure works simmilar as file system. The service will run and only work in a local network, `game.host` is the IP of the Computer hosting the game and will be found via a IP scan
 *
 * The version of the OpenAPI document: v2.15.1
 * Contact: nbrugger@student.tgm.ac.at
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Tgm.Roborally.Server.Converters;
using Tgm.Roborally.Server.Engine;

namespace Tgm.Roborally.Server.Models
{ 
	/// <summary>
	/// The event when a player places or removes an robot command from/to a register
	/// </summary>
	[DataContract]
	public class ChangeRegisterEvent : IEquatable<ChangeRegisterEvent>, Event {

		/// <summary>
		/// Gets or Sets Action
		/// </summary>
		[TypeConverter(typeof(CustomEnumConverter<ActionEnum>))]
		[JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
		public enum ActionEnum
		{
			
			/// <summary>
			/// Enum Fill for fill
			/// </summary>
			[EnumMember(Value = "fill")]
			Fill = 1,
			
			/// <summary>
			/// Enum Clear for clear
			/// </summary>
			[EnumMember(Value = "clear")]
			Clear = 2,
			
			/// <summary>
			/// Enum Replace for replace
			/// </summary>
			[EnumMember(Value = "replace")]
			Replace = 3
		}

		/// <summary>
		/// Gets or Sets Action
		/// </summary>
		[Required]
		[DataMember(Name="action", EmitDefaultValue=false)]
		public ActionEnum Action { get; set; }

		/// <summary>
		/// The id of an upgrade. **Unique**
		/// </summary>
		/// <value>The id of an upgrade. **Unique**</value>
		[Range(0, 10000)]
		[DataMember(Name="card", EmitDefaultValue=false)]
		public int Card { get; set; }

		/// <summary>
		/// The changed register
		/// </summary>
		/// <value>The changed register</value>
		[Required]
		[Range(0, 8)]
		[DataMember(Name="register", EmitDefaultValue=false)]
		public int Register { get; set; }

		/// <summary>
		/// The unique identification of this entity. &lt;br&gt; *!!!* This is not the id of the player&lt;br&gt; This value will be autogenerated by the api and is read only
		/// </summary>
		/// <value>The unique identification of this entity. &lt;br&gt; *!!!* This is not the id of the player&lt;br&gt; This value will be autogenerated by the api and is read only</value>
		[DataMember(Name="robotId", EmitDefaultValue=false)]
		public int RobotId { get; set; }

		/// <summary>
		/// Returns the string presentation of the object
		/// </summary>
		/// <returns>String presentation of the object</returns>
		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.Append("class ChangeRegisterEvent {\n");
			sb.Append("  Action: ").Append(Action).Append("\n");
			sb.Append("  Card: ").Append(Card).Append("\n");
			sb.Append("  Register: ").Append(Register).Append("\n");
			sb.Append("  RobotId: ").Append(RobotId).Append("\n");
			sb.Append("}\n");
			return sb.ToString();
		}

		public EventType GetEventType() => EventType.ChangeRegister;

		/// <summary>
		/// Returns the JSON string presentation of the object
		/// </summary>
		/// <returns>JSON string presentation of the object</returns>
		public string ToJson()
		{
			return JsonConvert.SerializeObject(this, Formatting.Indented);
		}

		/// <summary>
		/// Returns true if objects are equal
		/// </summary>
		/// <param name="obj">Object to be compared</param>
		/// <returns>Boolean</returns>
		public override bool Equals(object obj)
		{
			if (obj is null) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((ChangeRegisterEvent)obj);
		}

		/// <summary>
		/// Returns true if ChangeRegisterEvent instances are equal
		/// </summary>
		/// <param name="other">Instance of ChangeRegisterEvent to be compared</param>
		/// <returns>Boolean</returns>
		public bool Equals(ChangeRegisterEvent other)
		{
			if (other is null) return false;
			if (ReferenceEquals(this, other)) return true;

			return 
				(
					Action == other.Action ||
					
					Action.Equals(other.Action)
				) && 
				(
					Card == other.Card ||
					
					Card.Equals(other.Card)
				) && 
				(
					Register == other.Register ||
					
					Register.Equals(other.Register)
				) && 
				(
					RobotId == other.RobotId ||
					
					RobotId.Equals(other.RobotId)
				);
		}

		/// <summary>
		/// Gets the hash code
		/// </summary>
		/// <returns>Hash code</returns>
		public override int GetHashCode()
		{
			unchecked // Overflow is fine, just wrap
			{
				var hashCode = 41;
				// Suitable nullity checks etc, of course :)
					
					hashCode = hashCode * 59 + Action.GetHashCode();
					
					hashCode = hashCode * 59 + Card.GetHashCode();
					
					hashCode = hashCode * 59 + Register.GetHashCode();
					
					hashCode = hashCode * 59 + RobotId.GetHashCode();
				return hashCode;
			}
		}

		#region Operators
		#pragma warning disable 1591

		public static bool operator ==(ChangeRegisterEvent left, ChangeRegisterEvent right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(ChangeRegisterEvent left, ChangeRegisterEvent right)
		{
			return !Equals(left, right);
		}

		#pragma warning restore 1591
		#endregion Operators
	}
}
