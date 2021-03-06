/*
 * Robot Rally Game logic engine
 *
 * This api controlls the flow of a game and provides it's data. It is desiged to be RESTfull so the structure works simmilar as file system. The service will run and only work in a local network, `game.host` is the IP of the Computer hosting the game and will be found via a IP scan
 *
 * The version of the OpenAPI document: v0.4.1b0
 * Contact: nbrugger@student.tgm.ac.at
 * Generated by: https://openapi-generator.tech
 */

using System.ComponentModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Tgm.Roborally.Server.Converters;

namespace Tgm.Roborally.Server.Models {
	/// <summary>
	///     Defines the type (the code/actions) this card will have * `generator` : Generates *x* energy every round
	/// </summary>
	/// <value>Defines the type (the code/actions) this card will have * `generator` : Generates *x* energy every round</value>
	[TypeConverter(typeof(CustomEnumConverter<UpgradeType>))]
	[JsonConverter(typeof(StringEnumConverter))]
	public enum UpgradeType {
		/// <summary>
		///     Enum Generator for generator
		/// </summary>
		[EnumMember(Value = "generator")] Generator = 1
	}
}