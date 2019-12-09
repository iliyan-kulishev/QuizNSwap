using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using QuizNSwap.Data.Models;


namespace QuizNSwap.Data
{
    public class QuizNSwapContext : IdentityDbContext<User>
    {
        public QuizNSwapContext()
        {
            // 
        }
        public QuizNSwapContext(DbContextOptions<QuizNSwapContext> options) : base(options)
        {
            // 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Topic>()
                .HasOne<Folder>(g => g.Folder)
                .WithMany(s => s.Topics)
                .HasForeignKey(s => s.FolderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Keys of Identity tables are mapped in IdentityDbContext.OnModelCreating method  
            // and if this method is not called, attempting to add migration throws an error
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Folder> Folders { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<QuestionCard> QuestionCards { get; set; }
        
    }
}
