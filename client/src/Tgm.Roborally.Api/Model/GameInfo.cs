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
    /// Describes the current state of the game. It does not includes the gamedata (like players/poitions/field) but general information.  This is read only
    /// </summary>
    [DataContract]
    public partial class GameInfo :  IEquatable<GameInfo>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets State
        /// </summary>
        [DataMember(Name="state", EmitDefaultValue=false)]
        public GameState State { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="GameInfo" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GameInfo() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GameInfo" /> class.
        /// </summary>
        /// <param name="passedTime">The time passed since the game started in secconds. If the game is not started it will be &#x60;0&#x60; (required) (default to -1).</param>
        /// <param name="state">state (required).</param>
        /// <param name="hardwareCompatible">Not every game can be connected to hardware (for example to many bots)  If this is true it means you can use this game with hardware (required) (default to false).</param>
        /// <param name="hardwareAttached">Is a hardware boead connected (required) (default to false).</param>
        /// <param name="playerOnTurn">This id uniquely identifys the player (in a game).   **Not** to be confused with the &#x60;uid&#x60; which is used for authentication (required).</param>
        public GameInfo(int passedTime = -1, GameState state = default(GameState), bool hardwareCompatible = false, bool hardwareAttached = false, int playerOnTurn = default(int))
        {
            this.PassedTime = passedTime;
            // to ensure "state" is required (not null)
            this.State = state;
            this.HardwareCompatible = hardwareCompatible;
            this.HardwareAttached = hardwareAttached;
            this.PlayerOnTurn = playerOnTurn;
        }
        
        /// <summary>
        /// The time passed since the game started in secconds. If the game is not started it will be &#x60;0&#x60;
        /// </summary>
        /// <value>The time passed since the game started in secconds. If the game is not started it will be &#x60;0&#x60;</value>
        [DataMember(Name="passed-time", EmitDefaultValue=false)]
        public int PassedTime { get; set; }

        /// <summary>
        /// Not every game can be connected to hardware (for example to many bots)  If this is true it means you can use this game with hardware
        /// </summary>
        /// <value>Not every game can be connected to hardware (for example to many bots)  If this is true it means you can use this game with hardware</value>
        [DataMember(Name="hardware-compatible", EmitDefaultValue=false)]
        public bool HardwareCompatible { get; set; }

        /// <summary>
        /// Is a hardware boead connected
        /// </summary>
        /// <value>Is a hardware boead connected</value>
        [DataMember(Name="hardware-attached", EmitDefaultValue=false)]
        public bool HardwareAttached { get; set; }

        /// <summary>
        /// This id uniquely identifys the player (in a game).   **Not** to be confused with the &#x60;uid&#x60; which is used for authentication
        /// </summary>
        /// <value>This id uniquely identifys the player (in a game).   **Not** to be confused with the &#x60;uid&#x60; which is used for authentication</value>
        [DataMember(Name="player-on-turn", EmitDefaultValue=false)]
        public int PlayerOnTurn { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GameInfo {\n");
            sb.Append("  PassedTime: ").Append(PassedTime).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  HardwareCompatible: ").Append(HardwareCompatible).Append("\n");
            sb.Append("  HardwareAttached: ").Append(HardwareAttached).Append("\n");
            sb.Append("  PlayerOnTurn: ").Append(PlayerOnTurn).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as GameInfo);
        }

        /// <summary>
        /// Returns true if GameInfo instances are equal
        /// </summary>
        /// <param name="input">Instance of GameInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GameInfo input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.PassedTime == input.PassedTime ||
                    this.PassedTime.Equals(input.PassedTime)
                ) && 
                (
                    this.State == input.State ||
                    this.State.Equals(input.State)
                ) && 
                (
                    this.HardwareCompatible == input.HardwareCompatible ||
                    this.HardwareCompatible.Equals(input.HardwareCompatible)
                ) && 
                (
                    this.HardwareAttached == input.HardwareAttached ||
                    this.HardwareAttached.Equals(input.HardwareAttached)
                ) && 
                (
                    this.PlayerOnTurn == input.PlayerOnTurn ||
                    this.PlayerOnTurn.Equals(input.PlayerOnTurn)
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
                int hashCode = 41;
                hashCode = hashCode * 59 + this.PassedTime.GetHashCode();
                hashCode = hashCode * 59 + this.State.GetHashCode();
                hashCode = hashCode * 59 + this.HardwareCompatible.GetHashCode();
                hashCode = hashCode * 59 + this.HardwareAttached.GetHashCode();
                hashCode = hashCode * 59 + this.PlayerOnTurn.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            // PassedTime (int) minimum
            if(this.PassedTime < (int)-1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for PassedTime, must be a value greater than or equal to -1.", new [] { "PassedTime" });
            }

            // PlayerOnTurn (int) maximum
            if(this.PlayerOnTurn > (int)8)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for PlayerOnTurn, must be a value less than or equal to 8.", new [] { "PlayerOnTurn" });
            }

            // PlayerOnTurn (int) minimum
            if(this.PlayerOnTurn < (int)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for PlayerOnTurn, must be a value greater than or equal to 0.", new [] { "PlayerOnTurn" });
            }

            yield break;
        }
    }

}
