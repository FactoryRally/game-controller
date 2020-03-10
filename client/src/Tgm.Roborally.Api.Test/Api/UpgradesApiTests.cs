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
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using Xunit;

using Tgm.Roborally.Api.Client;
using Tgm.Roborally.Api.Api;
using Tgm.Roborally.Api.Model;

namespace Tgm.Roborally.Api.Test
{
    /// <summary>
    ///  Class for testing UpgradesApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class UpgradesApiTests : IDisposable
    {
        private UpgradesApi instance;

        public UpgradesApiTests()
        {
            instance = new UpgradesApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of UpgradesApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' UpgradesApi
            //Assert.IsType(typeof(UpgradesApi), instance, "instance is a UpgradesApi");
        }

        
        /// <summary>
        /// Test BuyUpgrade
        /// </summary>
        [Fact]
        public void BuyUpgradeTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int gameId = null;
            //int upgrade = null;
            //int? exchange = null;
            //instance.BuyUpgrade(gameId, upgrade, exchange);
            
        }
        
        /// <summary>
        /// Test GetAllUpgradeIDs
        /// </summary>
        [Fact]
        public void GetAllUpgradeIDsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int gameId = null;
            //var response = instance.GetAllUpgradeIDs(gameId);
            //Assert.IsType<List<int>> (response, "response is List<int>");
        }
        
        /// <summary>
        /// Test GetUpgradeInformation
        /// </summary>
        [Fact]
        public void GetUpgradeInformationTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int gameId = null;
            //int upgradeId = null;
            //var response = instance.GetUpgradeInformation(gameId, upgradeId);
            //Assert.IsType<Upgrade> (response, "response is Upgrade");
        }
        
        /// <summary>
        /// Test GetUpgradeShop
        /// </summary>
        [Fact]
        public void GetUpgradeShopTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //int gameId = null;
            //var response = instance.GetUpgradeShop(gameId);
            //Assert.IsType<UpgradeShop> (response, "response is UpgradeShop");
        }
        
    }

}
