using System.Collections.Generic;

namespace QuizNSwap.Models
{
    public class QuestionSet
    {
        public long Id { get; set; }
        public IEnumerable<QnA> Questions { get; set; }

    }
}