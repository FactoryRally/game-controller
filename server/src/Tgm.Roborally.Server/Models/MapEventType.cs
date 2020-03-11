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
        /// The event that occurs if the active map elements are activated
        /// </summary>
        /// <value>The event that occurs if the active map elements are activated</value>
        [TypeConverter(typeof(CustomEnumConverter<MapEventType>))]
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum MapEventType
        {
            
            /// <summary>
            /// Enum LazerEnum for lazer
            /// </summary>
            [EnumMember(Value = "lazer")]
            LazerEnum = 1,
            
            /// <summary>
            /// Enum RotatorEnum for rotator
            /// </summary>
            [EnumMember(Value = "rotator")]
            RotatorEnum = 2,
            
            /// <summary>
            /// Enum ConveyorBeltsEnum for conveyor-belts
            /// </summary>
            [EnumMember(Value = "conveyor-belts")]
            ConveyorBeltsEnum = 3,
            
            /// <summary>
            /// Enum StomperEnum for stomper
            /// </summary>
            [EnumMember(Value = "stomper")]
            StomperEnum = 4,
            
            /// <summary>
            /// Enum HoleEnum for hole
            /// </summary>
            [EnumMember(Value = "hole")]
            HoleEnum = 5,
            
            /// <summary>
            /// Enum HoleTrapEnum for hole-trap
            /// </summary>
            [EnumMember(Value = "hole-trap")]
            HoleTrapEnum = 6,
            
            /// <summary>
            /// Enum PusherEnum for pusher
            /// </summary>
            [EnumMember(Value = "pusher")]
            PusherEnum = 7,
            
            /// <summary>
            /// Enum FlamethrowerEnum for flamethrower
            /// </summary>
            [EnumMember(Value = "flamethrower")]
            FlamethrowerEnum = 8,
            
            /// <summary>
            /// Enum PortalEnum for portal
            /// </summary>
            [EnumMember(Value = "portal")]
            PortalEnum = 9,
            
            /// <summary>
            /// Enum ToggleRampsEnum for toggle-ramps
            /// </summary>
            [EnumMember(Value = "toggle-ramps")]
            ToggleRampsEnum = 10,
            
            /// <summary>
            /// Enum RepairEnum for repair
            /// </summary>
            [EnumMember(Value = "repair")]
            RepairEnum = 11
        }
}
