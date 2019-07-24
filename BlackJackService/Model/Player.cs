using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackJackService.Model
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Player_Id { get; set; }
        public string Name { get; set; }

        public ICollection<Game> game { get; set; }
    }
}
