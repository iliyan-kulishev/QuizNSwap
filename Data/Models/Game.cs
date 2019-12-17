using System.Collections.Generic;

namespace QuizNSwap.Data.Models
{
    public class Game
    {
        public string Id { get; set; }

        public string Code { get; set; }

        public virtual Topic Topic { get; set; }

        public string State { get; set; }

        public IList<Player> Players { get; set; }

        enum states
        {
            waiting = 1,    
            playing = 2,
            end = 3
        }
    }
}
