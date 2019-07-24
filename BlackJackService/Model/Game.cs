using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackService.Model
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Game_Id { get; set; }       

        public int Player_Id { get; set; }
        public Player player { get; set; }
        public int Game_No { get; set; }
    }
}
