/* 
 * Robot Rally Game logic engine
 *
 * This api controlls the flow of a game and provides it's data. It is desiged to be RESTfull so the structure works simmilar as file system. The service will run and only work in a local network, `game.host` is the IP of the Computer hosting the game and will be found via a IP scan
 *
 * The version of the OpenAPI document: 0.1.0
 * Contact: nbrugger@student.tgm.ac.at
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */


using Xunit;

using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using Tgm.Roborally.Api.Api;
using Tgm.Roborally.Api.Model;
using Tgm.Roborally.Api.Client;
using System.Reflection;
using Newtonsoft.Json;

namespace Tgm.Roborally.Api.Test
{
    /// <summary>
    ///  Class for testing MovementEvent
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the model.
    /// </remarks>
    public class MovementEventTests : IDisposable
    {
        // TODO uncomment below to declare an instance variable for MovementEvent
        //private MovementEvent instance;

        public MovementEventTests()
        {
            // TODO uncomment below to create an instance of MovementEvent
            //instance = new MovementEvent();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of MovementEvent
        /// </summary>
        [Fact]
        public void MovementEventInstanceTest()
        {
            // TODO uncomment below to test "IsInstanceOfType" MovementEvent
            //Assert.IsInstanceOfType<MovementEvent> (instance, "variable 'instance' is a MovementEvent");
        }


        /// <summary>
        /// Test the property 'Entity'
        /// </summary>
        [Fact]
        public void EntityTest()
        {
            // TODO unit test for the property 'Entity'
        }
        /// <summary>
        /// Test the property 'Direction'
        /// </summary>
        [Fact]
        public void DirectionTest()
        {
            // TODO unit test for the property 'Direction'
        }
        /// <summary>
        /// Test the property 'MovementAmmount'
        /// </summary>
        [Fact]
        public void MovementAmmountTest()
        {
            // TODO unit test for the property 'MovementAmmount'
        }
        /// <summary>
        /// Test the property 'Rotation'
        /// </summary>
        [Fact]
        public void RotationTest()
        {
            // TODO unit test for the property 'Rotation'
        }
        /// <summary>
        /// Test the property 'RotationTimes'
        /// </summary>
        [Fact]
        public void RotationTimesTest()
        {
            // TODO unit test for the property 'RotationTimes'
        }
        /// <summary>
        /// Test the property 'From'
        /// </summary>
        [Fact]
        public void FromTest()
        {
            // TODO unit test for the property 'From'
        }
        /// <summary>
        /// Test the property 'To'
        /// </summary>
        [Fact]
        public void ToTest()
        {
            // TODO unit test for the property 'To'
        }

    }

}
