using BlackJackService.Context;
using BlackJackService.Model;
using BlackJackService.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackService.Data
{
    public class CardRepository : ICard
    {

        readonly BlackJackContext _blackJackContext;
        public CardRepository(BlackJackContext blackJackContext)
        {
            _blackJackContext = blackJackContext;
        }

        /// <summary>
        /// This will fetch the card details from the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<Card>> IGetCardValues()
        {
            List<Card> lstcard = new List<Card>();
            List<Card> cardValues = new List<Card>();
            try
            {
                cardValues = await (from c in _blackJackContext.card
                                    join s in _blackJackContext.suit on c.suit.Suit_Id equals s.Suit_Id
                                    select new Card
                                    {
                                        Card_Id = c.Card_Id,
                                        Name = c.Name,
                                        Points = c.Points,
                                        suit = c.suit
                                    }).ToListAsync();

                if (cardValues != null)
                {
                    foreach (var item in cardValues)
                    {
                        Card card = new Card();
                        card.Card_Id = item.Card_Id;
                        card.Name = item.Name;
                        card.Points = item.Points;
                        card.suit = new Suit();

                        if (item.suit.Name == "Spades" || item.suit.Name == "Clubs")
                        {
                            card.suit.Color = "black";
                            card.suit.Name = setItem(item.Name, item.suit.Name, card.Points);

                        }
                        else if (item.suit.Name == "Hearts" || item.suit.Name == "Diamond")
                        {
                            card.suit.Color = "red";
                            card.suit.Name = setItem(item.Name, item.suit.Name, card.Points);
                        }
                        lstcard.Add(card);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lstcard;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardName"></param>
        /// <param name="suitName"></param>
        /// <param name="points"></param>
        /// <returns></returns>
        private string setItem(string cardName, string suitName, int points)
        {
            if (suitName == "Diamond")
            {
                suitName = "diams";
            }

            if (cardName.Contains("King"))
            {
                suitName = "&" + suitName.ToLower() + "; K";
            }
            else if (cardName.Contains("Jack"))
            {
                suitName = "&" + suitName.ToLower() + "; J" ;
            }
            else if (cardName.Contains("Queen"))
            {
                suitName = "&" + suitName.ToLower() + "; Q";
            }
            else
            {
                suitName = "&" + suitName.ToLower() + "; " + points;
            }

            return suitName;
        }

    }
}
