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
        public List<Folder> Folders { get; set; } = new List<Folder>();
        public List<Topic> Topics { get; set; } = new List<Topic>();

        [Required] // for the creation of new folder
        public string FolderName { get; set; }

        public bool Empty 
        { 
            get 
            { 
                return FoldersEmpty && TopicsEmpty; 
            } 
        } 

        public bool FoldersEmpty
        {
            get
            {
                return Folders.Any();
            }
        }

        public bool TopicsEmpty
        {
            get
            {
                return Topics.Any();
            }
        }

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
