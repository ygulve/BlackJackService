using BlackJackService.Context;
using BlackJackService.Model;
using BlackJackService.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlackJackService.Data
{
    public class PlayerRepository : IPlayer
    {
        readonly BlackJackContext _blackJacksContext;

        public PlayerRepository(BlackJackContext blackJackContext)
        {
            _blackJacksContext = blackJackContext;
        }

        /// <summary>
        /// Get the playerInformatio from db
        /// </summary>
        /// <returns></returns>
        public Player GetPlayer()
        {
            //Get the players from the database
            throw new NotImplementedException();
        }

        /// <summary>
        /// Save Player in db
        /// </summary>
        /// <returns></returns>        
        public async Task<Int32> Save(string playerName)
        {
            Player player = new Player();
            try
            {
                if (_blackJacksContext.player.Any(o => o.Name == playerName))
                {
                    return _blackJacksContext.player.Where(x => x.Name == playerName).Select(p=>p.Player_Id).FirstOrDefault();
                }
              
                player.Name = playerName;

                await _blackJacksContext.player.AddAsync(player);
                await _blackJacksContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;          
            }
            
            return player.Player_Id;

        }
    }
}
