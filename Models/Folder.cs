using System;
using System.Collections.Generic;
using System.Text;

namespace QuizNSwap.Models
{
    public class Folder
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public int ParentId { get; set; } // can be null, has to be like self-referencing FK
        public Folder ParentFolder { get; set; }
        //public Folder ChildFolder { get; set; }
        public ICollection<Quiz> Quizzes { get; set; }
    }
}
