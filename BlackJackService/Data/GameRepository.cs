using BlackJackService.Model;
using BlackJackService.Repository;
using System;
using System.Collections.Generic;
using BlackJackService.Context;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace BlackJackService.Data
{
    public class GameRepository : IGame
    {
        readonly BlackJackContext _blackJacksContext;

        public GameRepository(BlackJackContext blackJackContext)
        {
            _blackJacksContext = blackJackContext;
        }

        public async Task<Int32> IAddGame(Game game)
        {
            Game gm = new Game();
            try
            {
                gm.Game_No = game.Game_No;
                gm.Player_Id = game.Player_Id;
                await _blackJacksContext.game.AddAsync(gm);
                await _blackJacksContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;                
            }

            return gm.Game_Id;
        }
    }
}
