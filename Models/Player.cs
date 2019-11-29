using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNSwap.Models
{
    public class Player
    {

        public int Id { get; set; } // just int here not long, could be even smaller range numeric type I guess
        public string Nickname { get; set; }
        public int IdPairedWith { get; set; }
        public Player PairedWith { get; set; }


    }
}
