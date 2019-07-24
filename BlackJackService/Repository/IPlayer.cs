using BlackJackService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlackJackService.Repository
{
   public interface IPlayer
    {
        Player GetPlayer();

       Task<Int32> Save(string player);
    }
}
