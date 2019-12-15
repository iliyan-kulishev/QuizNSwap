using System.ComponentModel.DataAnnotations;

namespace QuizNSwap.Data.Models
{
    public class QuestionCard
    {
        public long Id { get; set; }

        [Required]
        public string UserId { get; set; } // By default the Id in the generated Identity table is textual
                                           //navigation
        public User User { get; set; }

        [Required]
        public long TopicId { get; set; }//should be required
        public Topic Topic { get; set; }

        [Required]
        public string Question { get; set; }

        public string Answer { get; set; }

        [Required]
        public bool IsImportant { get; set; }

        /*TODO: Storing images in QuestionCard table
         * 
         * - will be commaseparated
         * 
         * public string[]? ImagePaths { get; set; } 
         * 
         * modelBuilder.Entity<QuestionCard>()
            .Property(e => e.ImagePaths)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
         */



    }
}
