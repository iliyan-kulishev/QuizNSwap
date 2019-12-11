using System.Collections.Generic;

namespace QuizNSwap.Data.Models
{
    public class Game
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string TopicId { get; set; }
        public virtual Topic Topic { get; set; }
        public string State { get; set; }

        public IList<Player> Players { get; set; }
    
        enum gameStates {
            waiting = 1,
            playing = 2,
            end = 3
        };
    }
}