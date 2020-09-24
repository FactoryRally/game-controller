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
    /// Game Rules define the rules for a Game
    /// </summary>
    [DataContract]
    public partial class GameRules :  IEquatable<GameRules>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameRules" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected GameRules() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="GameRules" /> class.
        /// </summary>
        /// <param name="playerNamesVisible">If true players can see the name of the player controlling a robot (default to true).</param>
        /// <param name="maxPlayers">The maximum ammount of players able to join the game (default to 4).</param>
        /// <param name="name">The visible name of the game (required).</param>
        /// <param name="robotsPerPlayer">Defines the number of robots per player.</param>
        /// <param name="password">The password of a game.</param>
        /// <param name="fillWithBots">If true emply player slots are going to be filled up with AI enemys (default to false).</param>
        public GameRules(bool playerNamesVisible = true, int maxPlayers = 4, string name = default(string), int robotsPerPlayer = default(int), string password = default(string), bool fillWithBots = false)
        {
            // to ensure "name" is required (not null)
            if (name == null)
            {
                throw new InvalidDataException("name is a required property for GameRules and cannot be null");
            }
            else
            {
                this.Name = name;
            }
            
            // use default value if no "playerNamesVisible" provided
            if (playerNamesVisible == null)
            {
                this.PlayerNamesVisible = true;
            }
            else
            {
                this.PlayerNamesVisible = playerNamesVisible;
            }
            // use default value if no "maxPlayers" provided
            if (maxPlayers == null)
            {
                this.MaxPlayers = 4;
            }
            else
            {
                this.MaxPlayers = maxPlayers;
            }
            this.RobotsPerPlayer = robotsPerPlayer;
            this.Password = password;
            // use default value if no "fillWithBots" provided
            if (fillWithBots == null)
            {
                this.FillWithBots = false;
            }
            else
            {
                this.FillWithBots = fillWithBots;
            }
        }
        
        /// <summary>
        /// If true players can see the name of the player controlling a robot
        /// </summary>
        /// <value>If true players can see the name of the player controlling a robot</value>
        [DataMember(Name="player-names-visible", EmitDefaultValue=false)]
        public bool PlayerNamesVisible { get; set; }

        /// <summary>
        /// The maximum ammount of players able to join the game
        /// </summary>
        /// <value>The maximum ammount of players able to join the game</value>
        [DataMember(Name="max-players", EmitDefaultValue=false)]
        public int MaxPlayers { get; set; }

        /// <summary>
        /// The visible name of the game
        /// </summary>
        /// <value>The visible name of the game</value>
        [DataMember(Name="name", EmitDefaultValue=true)]
        public string Name { get; set; }

        /// <summary>
        /// Defines the number of robots per player
        /// </summary>
        /// <value>Defines the number of robots per player</value>
        [DataMember(Name="robots-per-player", EmitDefaultValue=false)]
        public int RobotsPerPlayer { get; set; }

        /// <summary>
        /// The password of a game
        /// </summary>
        /// <value>The password of a game</value>
        [DataMember(Name="password", EmitDefaultValue=false)]
        public string Password { get; set; }

        /// <summary>
        /// If true emply player slots are going to be filled up with AI enemys
        /// </summary>
        /// <value>If true emply player slots are going to be filled up with AI enemys</value>
        [DataMember(Name="fill-with-bots", EmitDefaultValue=false)]
        public bool FillWithBots { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GameRules {\n");
            sb.Append("  PlayerNamesVisible: ").Append(PlayerNamesVisible).Append("\n");
            sb.Append("  MaxPlayers: ").Append(MaxPlayers).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  RobotsPerPlayer: ").Append(RobotsPerPlayer).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  FillWithBots: ").Append(FillWithBots).Append("\n");
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
            return this.Equals(input as GameRules);
        }

        /// <summary>
        /// Returns true if GameRules instances are equal
        /// </summary>
        /// <param name="input">Instance of GameRules to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GameRules input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.PlayerNamesVisible == input.PlayerNamesVisible ||
                    (this.PlayerNamesVisible != null &&
                    this.PlayerNamesVisible.Equals(input.PlayerNamesVisible))
                ) && 
                (
                    this.MaxPlayers == input.MaxPlayers ||
                    (this.MaxPlayers != null &&
                    this.MaxPlayers.Equals(input.MaxPlayers))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.RobotsPerPlayer == input.RobotsPerPlayer ||
                    (this.RobotsPerPlayer != null &&
                    this.RobotsPerPlayer.Equals(input.RobotsPerPlayer))
                ) && 
                (
                    this.Password == input.Password ||
                    (this.Password != null &&
                    this.Password.Equals(input.Password))
                ) && 
                (
                    this.FillWithBots == input.FillWithBots ||
                    (this.FillWithBots != null &&
                    this.FillWithBots.Equals(input.FillWithBots))
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
                if (this.PlayerNamesVisible != null)
                    hashCode = hashCode * 59 + this.PlayerNamesVisible.GetHashCode();
                if (this.MaxPlayers != null)
                    hashCode = hashCode * 59 + this.MaxPlayers.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.RobotsPerPlayer != null)
                    hashCode = hashCode * 59 + this.RobotsPerPlayer.GetHashCode();
                if (this.Password != null)
                    hashCode = hashCode * 59 + this.Password.GetHashCode();
                if (this.FillWithBots != null)
                    hashCode = hashCode * 59 + this.FillWithBots.GetHashCode();
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

            
            // MaxPlayers (int) maximum
            if(this.MaxPlayers > (int)10)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for MaxPlayers, must be a value less than or equal to 10.", new [] { "MaxPlayers" });
            }

            // MaxPlayers (int) minimum
            if(this.MaxPlayers < (int)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for MaxPlayers, must be a value greater than or equal to 1.", new [] { "MaxPlayers" });
            }

            // Name (string) maxLength
            if(this.Name != null && this.Name.Length > 50)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be less than 50.", new [] { "Name" });
            }

            // Name (string) minLength
            if(this.Name != null && this.Name.Length < 3)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be greater than 3.", new [] { "Name" });
            }
            

            
            // RobotsPerPlayer (int) maximum
            if(this.RobotsPerPlayer > (int)3)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for RobotsPerPlayer, must be a value less than or equal to 3.", new [] { "RobotsPerPlayer" });
            }

            // RobotsPerPlayer (int) minimum
            if(this.RobotsPerPlayer < (int)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for RobotsPerPlayer, must be a value greater than or equal to 1.", new [] { "RobotsPerPlayer" });
            }

            // Password (string) maxLength
            if(this.Password != null && this.Password.Length > 18)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Password, length must be less than 18.", new [] { "Password" });
            }

            // Password (string) minLength
            if(this.Password != null && this.Password.Length < 4)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Password, length must be greater than 4.", new [] { "Password" });
            }
            
            yield break;
        }
    }

}
