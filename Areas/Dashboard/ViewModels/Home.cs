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
        IEnumerable<Folder> UserFolders {get; set;}
        IEnumerable<Topic> TopicsNotInFolder {get;set;}

        public class Folder
        {
            public string FolderName {get;set;}
            public int TopicsCount {get; set;}
        } 

        public class Topic
        {
            public int QuestionCardsCount { get; set; }
            public string TopicName {get; set; }
        }
        
    }
}