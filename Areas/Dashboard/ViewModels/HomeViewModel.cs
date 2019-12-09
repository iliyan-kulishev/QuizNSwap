using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using QuizNSwap.Data.Models;


namespace QuizNSwap.Areas.Dashboard.ViewModels
{
    public class HomeViewModel
    {
        public List<Folder> Folders {get; set;}
        public List<Topic> Topics {get;set;}

        public class Folder
        {
            public string Name {get;set;}
            public int TopicCount {get; set;}
        } 

        public class Topic
        {
            public string Name { get; set; }
            public int QuestionCardCount { get; set; }
        }

    }
}