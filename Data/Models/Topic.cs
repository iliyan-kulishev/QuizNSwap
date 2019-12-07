using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace QuizNSwap.Data.Models
{
    public class Topic
    {
        public long Id { get; set; }

        public User User { get; set; }


        public long? FolderId { get; set; } // can be null, not every topic is in a folder
        //navigation
        public Folder Folder { get; set; }

        //navigation property
        [Required]
        public ICollection<QuestionCard> QuestionCards { get; set; }
    }
}