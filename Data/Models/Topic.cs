using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;


namespace QuizNSwap.Data.Models
{
    public class Topic
    {
        public long Id { get; set; }

        [Required]
        public string UserId {get; set;} // By default the Id in the generated Identity table is textual
        //navigation
        public User User { get; set; }
        
        [Required]
        public string Name {get; set; } // making this unique with Fluent API in the context class
        public long? FolderId { get; set; } // can be null, not every topic is in a folder
        //navigation
        public Folder Folder { get; set; }

        //navigation property
        [Required]
        public ICollection<QuestionCard> QuestionCards { get; set; }
    }
}
