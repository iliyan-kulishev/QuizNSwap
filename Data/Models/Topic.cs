using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace QuizNSwap.Data.Models
{
    public class Topic
    {
        public long Id { get; set; }
        /*
        [Required]
        public string UserId {get; set;}
        //navigation
        public IdentityUser User { get; set; } //the type is IDENTITY USER. Important.
        */
        [Required]
        public string Name {get; set;}
        public long? FolderId { get; set; } // can be null, not every topic is in a folder
        //navigation
        public Folder Folder { get; set; }

        //navigation property
        [Required]
        public ICollection<QuestionCard> QuestionCards { get; set; }
    }
}