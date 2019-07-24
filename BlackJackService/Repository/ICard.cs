using BlackJackService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackService.Repository
{
   public interface ICard
    {
        Task<List<Card>> IGetCardValues();
    }
}
