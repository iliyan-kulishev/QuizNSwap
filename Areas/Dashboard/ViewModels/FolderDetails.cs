using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNSwap.Areas.Dashboard.ViewModels
{
    public class FolderDetails
    {
        public int Id { get; set; } // for applying changes
        public string FolderName { get; set; }
        public int TopicCount { get; set; }
        public List<Topic> Topics {get; set;} = new List<Topic>();

        public class Topic
        {
            public int Id { get; set; } // for redirection
            public string Name { get; set; }
            public int QuestionCardCount { get; set; }

        }


    }
}
