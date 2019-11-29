using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNSwap.Models
{
    public class Game
    {
        public long Id { get; set; }
        public string EntrancePin { get; set; } // probably like Kahoot - W3H5 letter/num/letter/num
        public ICollection<Player> Players { get; set; }




    }
}
