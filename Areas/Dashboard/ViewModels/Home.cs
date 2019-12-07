using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using QuizNSwap.Data.Models;


namespace QuizNSwap.Areas.Dashboard.ViewModels
{
    public class Home
    {

        IEnumerable<FolderPersistenceModel> UserFolders {get; set;}
        IEnumerable<TopicPersistenceModel> UserTopicsLoose {get;set;}

        public class FolderPersistenceModel
        {
            public string FolderName {get;set;}
            public int TopicsCount {get; set;}
        } 

        public class TopicPersistenceModel
        {
            public int QuestionCardsCount { get; set; }
            public string TopicName {get; set; }
        }
        
    }
}