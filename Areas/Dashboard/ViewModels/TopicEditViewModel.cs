using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNSwap.Areas.Dashboard.ViewModels
{
    public class TopicEditViewModel
    {
        public string Name { get; set; }
        public string Placeholder { get; set; } = "Your new topic name";
        public int QuestionCardCount { get; set; }

        public class QuestionCard
        {
            public long Id { get; set; }
            public string Question { get; set; }
        }
    }
}
