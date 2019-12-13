using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNSwap.Areas.Dashboard.ViewModels
{
    public class TopicViewModel
    {
        string Name { get; set; }
        int QuestionCardCount { get; set; }

        public class QuestionCard
        {
            long Id { get; set; }
            string Question { get; set; }
        }
    }
}
