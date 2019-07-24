using BlackJackService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackService.Context
{
    public class BlackJackContext :DbContext
    {

        public BlackJackContext(DbContextOptions options) :base(options) { }
        
        public DbSet<Suit> suit { get; set; }
        public DbSet<Card> card { get; set; }

        public DbSet<Player> player { get; set; }

        public DbSet<Transaction> transaction { get; set; }
        public DbSet<Game> game { get; set; }
        public DbSet<Result> result { get; set; }

    }
}
