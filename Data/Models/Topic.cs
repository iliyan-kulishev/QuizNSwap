using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizNSwap.Data.Models
{
    public class Topic
    {
        public long Id { get; set; }
        public long? FolderId { get; set; } // can be null
        //navigation
        public Folder Folder { get; set; }
        //navigation property
        [Required]
        public ICollection<QuestionCard> QuestionCards { get; set; }
    }
}