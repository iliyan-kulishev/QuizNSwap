using System.Collections.Generic;

namespace QuizNSwap.Models
{
    public class Quiz
    {
        public long Id { get; set; }
        public ICollection<Question> Questions { get; set; }

    }
}