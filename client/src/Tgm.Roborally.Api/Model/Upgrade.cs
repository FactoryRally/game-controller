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
    /// A upgrade is a module making a robot stronger
    /// </summary>
    [DataContract]
    public partial class Upgrade :  IEquatable<Upgrade>, IValidatableObject
    {
        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public UpgradeType Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Upgrade" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Upgrade() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="Upgrade" /> class.
        /// </summary>
        /// <param name="cost">The energy cost to buy this upgrade (required) (default to 2).</param>
        /// <param name="name">The ame to display for this Upgrade. ***Not*** unique (identifying) (required).</param>
        /// <param name="permanent">if true the card belongs to the player for the rest of the game (default to true).</param>
        /// <param name="description">A description about the effect of the card. Variables are using the format &#x60;{name}&#x60; where *name* refers to the names in &#x60;values&#x60;.  (default to &quot;null&quot;).</param>
        /// <param name="rounds">If the Upgrade is not permanent this variable defines the number of rounds this Upgrade works.</param>
        /// <param name="values">Defines number values for the upgrade.&lt;br&gt;Example: Effect: \&quot;You have {registers} additonal Registers\&quot;&lt;br&gt; &#x60;{registers}&#x60; is the number of the regsiters (that will be added) and the exact value will be defined in here (&#x60;values&#x60;).</param>
        /// <param name="type">type (required).</param>
        /// <param name="id">The id of an upgrade. **Unique**.</param>
        public Upgrade(int cost = 2, string name = default(string), bool permanent = true, string description = "null", int rounds = default(int), List<Pair> values = default(List<Pair>), UpgradeType type = default(UpgradeType), int id = default(int))
        {
            this.Cost = cost;
            // to ensure "name" is required (not null)
            this.Name = name ?? throw new ArgumentNullException("name is a required property for Upgrade and cannot be null");;
            // to ensure "type" is required (not null)
            this.Type = type;
            this.Permanent = permanent;
            // use default value if no "description" provided
            this.Description = description ?? "null";
            this.Rounds = rounds;
            this.Values = values;
            this.Id = id;
        }
        
        /// <summary>
        /// The energy cost to buy this upgrade
        /// </summary>
        /// <value>The energy cost to buy this upgrade</value>
        [DataMember(Name="cost", EmitDefaultValue=false)]
        public int Cost { get; set; }

        /// <summary>
        /// The ame to display for this Upgrade. ***Not*** unique (identifying)
        /// </summary>
        /// <value>The ame to display for this Upgrade. ***Not*** unique (identifying)</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// if true the card belongs to the player for the rest of the game
        /// </summary>
        /// <value>if true the card belongs to the player for the rest of the game</value>
        [DataMember(Name="permanent", EmitDefaultValue=false)]
        public bool Permanent { get; set; }

        /// <summary>
        /// A description about the effect of the card. Variables are using the format &#x60;{name}&#x60; where *name* refers to the names in &#x60;values&#x60;. 
        /// </summary>
        /// <value>A description about the effect of the card. Variables are using the format &#x60;{name}&#x60; where *name* refers to the names in &#x60;values&#x60;. </value>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// If the Upgrade is not permanent this variable defines the number of rounds this Upgrade works
        /// </summary>
        /// <value>If the Upgrade is not permanent this variable defines the number of rounds this Upgrade works</value>
        [DataMember(Name="rounds", EmitDefaultValue=false)]
        public int Rounds { get; set; }

        /// <summary>
        /// Defines number values for the upgrade.&lt;br&gt;Example: Effect: \&quot;You have {registers} additonal Registers\&quot;&lt;br&gt; &#x60;{registers}&#x60; is the number of the regsiters (that will be added) and the exact value will be defined in here (&#x60;values&#x60;)
        /// </summary>
        /// <value>Defines number values for the upgrade.&lt;br&gt;Example: Effect: \&quot;You have {registers} additonal Registers\&quot;&lt;br&gt; &#x60;{registers}&#x60; is the number of the regsiters (that will be added) and the exact value will be defined in here (&#x60;values&#x60;)</value>
        [DataMember(Name="values", EmitDefaultValue=false)]
        public List<Pair> Values { get; set; }

        /// <summary>
        /// The id of an upgrade. **Unique**
        /// </summary>
        /// <value>The id of an upgrade. **Unique**</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public int Id { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
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
            return this.Equals(input as Upgrade);
        }

        /// <summary>
        /// Returns true if Upgrade instances are equal
        /// </summary>
        /// <param name="input">Instance of Upgrade to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Upgrade input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Cost == input.Cost ||
                    this.Cost.Equals(input.Cost)
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Permanent == input.Permanent ||
                    this.Permanent.Equals(input.Permanent)
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Rounds == input.Rounds ||
                    this.Rounds.Equals(input.Rounds)
                ) && 
                (
                    this.Values == input.Values ||
                    this.Values != null &&
                    input.Values != null &&
                    this.Values.SequenceEqual(input.Values)
                ) && 
                (
                    this.Type == input.Type ||
                    this.Type.Equals(input.Type)
                ) && 
                (
                    this.Id == input.Id ||
                    this.Id.Equals(input.Id)
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
                hashCode = hashCode * 59 + this.Cost.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                hashCode = hashCode * 59 + this.Permanent.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                hashCode = hashCode * 59 + this.Rounds.GetHashCode();
                if (this.Values != null)
                    hashCode = hashCode * 59 + this.Values.GetHashCode();
                hashCode = hashCode * 59 + this.Type.GetHashCode();
                hashCode = hashCode * 59 + this.Id.GetHashCode();
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
            // Cost (int) maximum
            if(this.Cost > (int)5)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Cost, must be a value less than or equal to 5.", new [] { "Cost" });
            }

            // Cost (int) minimum
            if(this.Cost < (int)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Cost, must be a value greater than or equal to 0.", new [] { "Cost" });
            }

            // Name (string) maxLength
            if(this.Name != null && this.Name.Length > 27)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be less than 27.", new [] { "Name" });
            }

            // Name (string) minLength
            if(this.Name != null && this.Name.Length < 2)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Name, length must be greater than 2.", new [] { "Name" });
            }

            // Description (string) maxLength
            if(this.Description != null && this.Description.Length > 300)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Description, length must be less than 300.", new [] { "Description" });
            }

            // Rounds (int) maximum
            if(this.Rounds > (int)10)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Rounds, must be a value less than or equal to 10.", new [] { "Rounds" });
            }

            // Rounds (int) minimum
            if(this.Rounds < (int)1)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Rounds, must be a value greater than or equal to 1.", new [] { "Rounds" });
            }

            // Id (int) maximum
            if(this.Id > (int)10000)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Id, must be a value less than or equal to 10000.", new [] { "Id" });
            }

            // Id (int) minimum
            if(this.Id < (int)0)
            {
                yield return new System.ComponentModel.DataAnnotations.ValidationResult("Invalid value for Id, must be a value greater than or equal to 0.", new [] { "Id" });
            }

            yield break;
        }
    }

}
