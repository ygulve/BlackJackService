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

    [Route("api/game")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class GameController : ControllerBase
    {

        private readonly IGame _repo;

        public GameController(IGame game)
        {
            _repo = game;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Int32), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public  async Task<IActionResult> Post([FromBody] Game game)
        {           
            try
            {
                if (game == null)
                {
                    return BadRequest();
                }
                var gameId = await _repo.IAddGame(game);

                return Ok(gameId);
            }
            catch (Exception ex)
            {
                throw new BlackJackException(ex.ToString());
            }
        }
    }
}
