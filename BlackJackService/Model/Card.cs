using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackService.Model
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Card_Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public Suit suit { get; set; }

    }
}
