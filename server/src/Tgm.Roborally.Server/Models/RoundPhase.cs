/*
 * Robot Rally Game logic engine
 *
 * This api controlls the flow of a game and provides it's data. It is desiged to be RESTfull so the structure works simmilar as file system. The service will run and only work in a local network, `game.host` is the IP of the Computer hosting the game and will be found via a IP scan
 *
 * The version of the OpenAPI document: 0.1.0
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

namespace Tgm.Roborally.Server.Models
{ 
        /// <summary>
        /// A round consits of 3 Phases each phase does different things * `Upgrade` : Purchase Upgrades with energy cubes * `Programming` : Programm your robot(s) * `Activation` : The robots execute their code
        /// </summary>
        /// <value>A round consits of 3 Phases each phase does different things * `Upgrade` : Purchase Upgrades with energy cubes * `Programming` : Programm your robot(s) * `Activation` : The robots execute their code</value>
        [TypeConverter(typeof(CustomEnumConverter<RoundPhase>))]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum RoundPhase
        {
            
            /// <summary>
            /// Enum UpgradeEnum for upgrade
            /// </summary>
            [EnumMember(Value = "upgrade")]
            UpgradeEnum = 1,
            
            /// <summary>
            /// Enum ProgrammingEnum for programming
            /// </summary>
            [EnumMember(Value = "programming")]
            ProgrammingEnum = 2,
            
            /// <summary>
            /// Enum ActivationEnum for activation
            /// </summary>
            [EnumMember(Value = "activation")]
            ActivationEnum = 3
        }
}
