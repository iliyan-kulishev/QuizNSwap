using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNSwap.Areas.Dashboard.ViewModels
{
    public class TopicCreateViewModel
    {
        public int QuestionsCounter { get; set; } = 0;
        public string FinalizeButtonText { get; set; } = "Create";
        public string TopicNamePlaceholder { get; set; } = "Your new topic name";
        [Required]
        public string TopicName { get; set; }
        public string HeaderText { get; set; } = "Create a new topic";
        public int InitialCountQuestionCards { get; set; } = 3;
        public List<QuestionCard> QuestionCards { get; set; }

        public class QuestionCard
        {
            public int ListingNumber { get; set; }
            [Required(ErrorMessage = "Folder name is required.")]
            public string Question { get; set; }
        }



    }
}
