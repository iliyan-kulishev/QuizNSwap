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
            [Required]
            public string TopicName { get; set; }//for persistence

        }


        public class Wrapper
        {
            public int InitialCountQuestionCards { get; set; } = 1;
            public List<QuestionCard> QuestionCards { get; set; }



            public class QuestionCard
            {
                public int ListingNumber { get; set; } = 1;
                //[Required(ErrorMessage = "Question text is required.")]
                [Required]
                public string Question { get; set; } // for display
                //I don't want to be after the user for generating whole bunch
                //of question cards - empty with missing content and so on.
                //Will just specify here what's the minimum requirement for the content
                //inside the question card to be valid for inserion
                //and the POST handler will check with this
                public bool IsJunkContent { get; set; } //for persistence

                
            }
        }




    }
}
