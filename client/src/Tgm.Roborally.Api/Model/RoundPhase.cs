/* 
 * Robot Rally Game logic engine
 *
 * This api controlls the flow of a game and provides it's data. It is desiged to be RESTfull so the structure works simmilar as file system. The service will run and only work in a local network, `game.host` is the IP of the Computer hosting the game and will be found via a IP scan
 *
 * The version of the OpenAPI document: 0.1.0
 * Contact: nbrugger@student.tgm.ac.at
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Tgm.Roborally.Api.Client.OpenAPIDateConverter;

namespace Tgm.Roborally.Api.Model
{
    /// <summary>
    /// A round consits of 3 Phases each phase does different things * &#x60;Upgrade&#x60; : Purchase Upgrades with energy cubes * &#x60;Programming&#x60; : Programm your robot(s) * &#x60;Activation&#x60; : The robots execute their code
    /// </summary>
    /// <value>A round consits of 3 Phases each phase does different things * &#x60;Upgrade&#x60; : Purchase Upgrades with energy cubes * &#x60;Programming&#x60; : Programm your robot(s) * &#x60;Activation&#x60; : The robots execute their code</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum RoundPhase
    {
        /// <summary>
        /// Enum Upgrade for value: upgrade
        /// </summary>
        [EnumMember(Value = "upgrade")]
        Upgrade = 1,

        /// <summary>
        /// Enum Programming for value: programming
        /// </summary>
        [EnumMember(Value = "programming")]
        Programming = 2,

        /// <summary>
        /// Enum Activation for value: activation
        /// </summary>
        [EnumMember(Value = "activation")]
        Activation = 3

    }

}
