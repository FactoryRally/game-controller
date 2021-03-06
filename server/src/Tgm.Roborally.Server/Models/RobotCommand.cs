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
using Tgm.Roborally.Server.Engine;
using Tgm.Roborally.Server.Engine.Statement;

namespace Tgm.Roborally.Server.Models {
	/// <summary>
	///     A command for a robot to execute
	/// </summary>
	[DataContract]
	public abstract class RobotCommand : IEquatable<RobotCommand>, RobotCommandExecutor {
		private readonly Dictionary<string, int> _parameters = new Dictionary<string, int>();

		/// <summary>
		///     Gets or Sets Type
		/// </summary>
		[Required]
		[DataMember(Name = "type", EmitDefaultValue = true)]
		public abstract Instruction Type { get; }

		/// <summary>
		///     Returns the value of the given parameter
		/// </summary>
		/// <param name="index"> the name of the value</param>
		public int this[string index] {
			get => _parameters.ContainsKey(index) ? _parameters[index] : 0;
			set => _parameters[index] = value;
		}

		/// <summary>
		///     Defines parameters for the instruction.&lt;br&gt;Example: Effect: \&quot;Move {steps} steps forward\&quot;&lt;br
		///     &gt; &#x60;{steps}&#x60; is the number of steps the robot will do. And the exact value (of steps) will be defined
		///     in here (&#x60;values&#x60;)
		/// </summary>
		/// <value>
		///     Defines parameters for the instruction.&lt;br&gt;Example: Effect: \&quot;Move {steps} steps forward\&quot;&lt;br
		///     &gt; &#x60;{steps}&#x60; is the number of steps the robot will do. And the exact value (of steps) will be defined
		///     in here (&#x60;values&#x60;)
		/// </value>
		[DataMember(Name = "parameters", EmitDefaultValue = true)]
		public List<Pair> Parameters {
			get => _parameters.Select(selector: e => new Pair(e.Key, e.Value)).ToList();
			set {
				_parameters.Clear();
				foreach (Pair pair in value) _parameters.Add(pair.Name, pair.Value);
			}
		}

		/// <summary>
		///     A description about the effect of the command. Variables are using the format &#x60;{name}&#x60; where *name*
		///     refers to the names in &#x60;values&#x60;.
		/// </summary>
		/// <value>
		///     A description about the effect of the command. Variables are using the format &#x60;{name}&#x60; where *name*
		///     refers to the names in &#x60;values&#x60;.
		/// </value>
		[MaxLength(300)]
		[DataMember(Name = "description", EmitDefaultValue = true)]
		public abstract string Description { get; }

		/// <summary>
		///     The ame to display for this Command. ***Not*** unique (identifying)
		/// </summary>
		/// <value>The ame to display for this Command. ***Not*** unique (identifying)</value>
		[StringLength(27, MinimumLength = 2)]
		[DataMember(Name                = "name", EmitDefaultValue = true)]
		public string Name { get; set; }

		/// <summary>
		///     Describes how often this command is going to be executed
		/// </summary>
		/// <value>Describes how often this command is going to be executed</value>
		[Range(1, 10)]
		[DataMember(Name = "times", EmitDefaultValue = true)]
		public abstract int Times { get; }

		public string FilledDescription {
			get {
				string output = Description;
				foreach ((string key, int val) in _parameters) {
					while (output.Contains($"{{{key}}}"))
						output = output.Replace($"{{{key}}}", val.ToString());
				}

				return output;
			}
		}

		/// <summary>
		///     Returns true if RobotCommand instances are equal
		/// </summary>
		/// <param name="other">Instance of RobotCommand to be compared</param>
		/// <returns>Boolean</returns>
		public bool Equals(RobotCommand other) {
			if (other is null) return false;
			if (ReferenceEquals(this, other)) return true;

			return
				(
					Type == other.Type ||
					Type.Equals(other.Type)
				) &&
				(
					Parameters == other.Parameters ||
					Parameters       != null &&
					other.Parameters != null &&
					Parameters.SequenceEqual(other.Parameters)
				) &&
				(
					Description == other.Description ||
					Description != null &&
					Description.Equals(other.Description)
				) &&
				(
					Name == other.Name ||
					Name != null &&
					Name.Equals(other.Name)
				) &&
				(
					Times == other.Times ||
					Times.Equals(other.Times)
				);
		}

		public abstract void Do(GameLogic game, int robotId);

		public void Execute(GameLogic game, int robot) {
			for (int i = 0; i < Times; i++) Do(game, robot);
		}

		/// <summary>
		///     Returns the string presentation of the object
		/// </summary>
		/// <returns>String presentation of the object</returns>
		public override string ToString() {
			StringBuilder sb = new StringBuilder();
			sb.Append("class RobotCommand {\n");
			sb.Append("  Type: ").Append(Type).Append("\n");
			sb.Append("  Parameters: ").Append(Parameters).Append("\n");
			sb.Append("  Description: ").Append(Description).Append("\n");
			sb.Append("  Name: ").Append(Name).Append("\n");
			sb.Append("  Times: ").Append(Times).Append("\n");
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
			return obj.GetType() == GetType() && Equals((RobotCommand) obj);
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

				hashCode = hashCode * 59 + Type.GetHashCode();
				if (Parameters != null)
					hashCode = hashCode * 59 + Parameters.GetHashCode();
				if (Description != null)
					hashCode = hashCode * 59 + Description.GetHashCode();
				if (Name != null)
					hashCode = hashCode * 59 + Name.GetHashCode();

				hashCode = hashCode * 59 + Times.GetHashCode();
				return hashCode;
			}
		}

		#region Operators

		#pragma warning disable 1591

		public static bool operator ==(RobotCommand left, RobotCommand right) => Equals(left, right);

		public static bool operator !=(RobotCommand left, RobotCommand right) => !Equals(left, right);

		#pragma warning restore 1591

		#endregion Operators
	}
}