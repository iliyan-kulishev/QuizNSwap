using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuizNSwap.Data.Models;

namespace QuizNSwap.Data
{
    public class QuizNSwapContext : IdentityDbContext<User>
    {
        public QuizNSwapContext(DbContextOptions<QuizNSwapContext> options) :
            base(options)
        {
            //
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Topic>()
                .HasOne<Folder>(g => g.Folder)
                .WithMany(s => s.Topics)
                .HasForeignKey(s => s.FolderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Folder>().HasIndex(u => u.Name).IsUnique();

            modelBuilder.Entity<Player>().HasOne<Game>(p => p.Game);

            modelBuilder.Entity<Folder>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<Topic>()
                .HasIndex(u => u.Name)
                .IsUnique();

            modelBuilder.Entity<QuestionCard>()
            .Property(q => q.IsImportant)
            .HasDefaultValue(0);


            // Keys of Identity tables are mapped in IdentityDbContext.OnModelCreating method  
            modelBuilder.Entity<Game>().HasOne<Topic>(g => g.Topic);

            modelBuilder.Entity<Game>().HasMany<Player>(g => g.Players);

            // Keys of Identity tables are mapped in IdentityDbContext.OnModelCreating method
            // and if this method is not called, attempting to add migration throws an error
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Folder> Folders { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<QuestionCard> QuestionCards { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }
    }
}
