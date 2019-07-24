using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackService.Model
{
    public class Suit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Suit_Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public string Color { get; set; }
    }
}
