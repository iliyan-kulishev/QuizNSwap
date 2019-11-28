using System.Collections.Generic;

namespace _1_Domain.Entities
{
    public class QuestionSet
    {
        public long Id { get; set; }
        public IEnumerable<QnA> Questions { get; set; }

    }
}