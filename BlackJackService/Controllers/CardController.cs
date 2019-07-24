using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlackJackService.Data;
using BlackJackService.Model;
using BlackJackService.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlackJackService.Controllers
{
    [Route("api/card")]
    [ApiController]
    [EnableCors("AllowSpecificOrigin")]
    public class CardController : ControllerBase
    {

        private readonly ICard _cardRepo;

        public CardController(ICard card)
        {
            _cardRepo = card;
        }

        [HttpGet]
        public async Task<List<Card>> GetCard()
        {
            List<Card> lstcards = null;
            try
            {
                lstcards = await _cardRepo.IGetCardValues();
            }
            catch (Exception ex)
            {
                throw new BlackJackException(ex.ToString());
            }

            return lstcards;
        }

    }
}
