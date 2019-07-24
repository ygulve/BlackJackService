using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackService.Data
{
    public class BlackJackException :Exception
    {
        public BlackJackException() {
        }

        public BlackJackException(string message) :base(message)
        {
            //Keep these into error log file or in database
        }
    }
}
