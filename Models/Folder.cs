using System;
using System.Collections.Generic;
using System.Text;

namespace QuizNSwap.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public Folder Parent { get; set; }
        public Folder ChildFolder { get; set; }
    }
}
