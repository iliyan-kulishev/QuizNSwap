using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNSwap.Areas.Dashboard.ViewModels
{
    public class TopicCreateViewModel
    {
        public Header HeaderContainer { get; set; } = new Header();

        public Wrapper WrapperContainer { get; set; } = new Wrapper();

        public class Header
        {
            public int QuestionsCounter { get; set; } = 0;
            public string HeaderText { get; set; } = "Create a new topic";
            public string FinalizeButtonText { get; set; } = "Create";
            public string TopicNamePlaceholder { get; set; } = "Your new topic name";
        }


        public class Wrapper
        {
            [Required]
            public string TopicName { get; set; }//for persistence
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
}
