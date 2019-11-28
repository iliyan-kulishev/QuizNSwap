using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Domain.Entities
{
    public class Folder
    {
        public Folder()
        {
            Children = new List<Folder>();
        }

        public string Name { get; set; }
        public int Id { get; set; }

        public int? ParentId { get; set; }
        public Folder Parent { get; set; }

        public IEnumerable<Folder> Children { get; set; }
    }
}
