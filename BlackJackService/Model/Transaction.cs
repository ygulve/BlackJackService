using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlackJackService.Model
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Transaction_Id { get; set; }
        public int PlayerScore { get; set; }
        public int DealerScore { get; set; }
        public string Session_Id { get; set; }
        public int Card_Id { get; set; }
        public int Game_Id { get; set; }
    }
}