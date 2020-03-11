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
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Tgm.Roborally.Server.Attributes;
using Microsoft.AspNetCore.Authorization;
using Tgm.Roborally.Server.Models;

namespace Tgm.Roborally.Server.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class MapApiController : ControllerBase
    { 
        /// <summary>
        /// Get Map info
        /// </summary>
        /// <remarks>Get meta information abouzt the map of the game</remarks>
        /// <param name="gameId"></param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/v1/games/{game_id}/map/info")]
        [Authorize(Policy = "Player-Token-Access")]
        [ValidateModelState]
        [SwaggerOperation("GetMapInfo")]
        [SwaggerResponse(statusCode: 200, type: typeof(MapInfo), description: "OK")]
        public virtual IActionResult GetMapInfo([FromRoute][Required]string gameId)
        { 

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(MapInfo));
            string exampleJson = null;
            exampleJson = "{\r\n  \"width\" : 43,\r\n  \"prioBeacon\" : {\r\n    \"x\" : 1,\r\n    \"y\" : 5\r\n  },\r\n  \"height\" : 302\r\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<MapInfo>(exampleJson)
            : default(MapInfo);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Get tile
        /// </summary>
        /// <remarks>Inspect a tile of the map</remarks>
        /// <param name="gameId"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/v1/games/{game_id}/map/tiles/{x}/{y}")]
        [Authorize(Policy = "Player-Token-Access")]
        [ValidateModelState]
        [SwaggerOperation("GetTile")]
        [SwaggerResponse(statusCode: 200, type: typeof(Tile), description: "OK")]
        public virtual IActionResult GetTile([FromRoute][Required]string gameId, [FromRoute][Required]string x, [FromRoute][Required]string y)
        { 

            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Tile));
            string exampleJson = null;
            exampleJson = "{\r\n  \"empty\" : true\r\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Tile>(exampleJson)
            : default(Tile);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
