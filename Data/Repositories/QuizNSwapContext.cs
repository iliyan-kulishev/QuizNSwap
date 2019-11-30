using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QuizNSwap.Data
{
    public class QuizNSwapContext : DbContext
    {
        public QuizNSwapContext()
        {
        }
        public QuizNSwapContext(DbContextOptions<QuizNSwapContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=./QuizNSwapDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*modelBuilder.Entity<Folder>().
                HasIndex(p => new { p.ParentFolderId }).IsUnique(true);*/
                
            modelBuilder.Entity<Topic>()
                .HasOne<Folder>(g => g.Folder)
                .WithMany(s => s.Topics)
                .HasForeignKey(s => s.FolderId)
                .OnDelete(DeleteBehavior.Cascade); 
        }

        public DbSet<Folder> Folders { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<QuestionCard> QuestionCards { get; set; }





    }
}
