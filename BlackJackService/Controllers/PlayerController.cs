using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BlackJackService.Data;
using BlackJackService.Model;
using BlackJackService.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlackJackService.Controllers
{
    [Route("api/player")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class PlayerController : ControllerBase
    {
        readonly IPlayer _player;


        public PlayerController(IPlayer player)
        {
            _player = player;
        }

        [HttpGet]
        public HttpResponseMessage GetPlayer()
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Int32), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddPlayer([FromBody] string playerName)
        {          
            try
            {
                if (playerName == null)
                {
                    return BadRequest();
                }

                var playerId = await _player.Save(playerName);

                return Ok(playerId);
            }
            catch (Exception ex)
            {
                throw new BlackJackException(ex.ToString());
            }


        }
    }
}
