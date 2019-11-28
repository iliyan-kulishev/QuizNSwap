using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuizNSwap.Models;

namespace QuizNSwap.Infrastructure
{
    public class QuizNSwapContext : DbContext
    {

        public QuizNSwapContext(DbContextOptions<QuizNSwapContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = QuizNSwapDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Folder> Folders { get; set; }
        public DbSet<QnA> QnAs { get; set; }
        public DbSet<QuestionSet> QuestionSets { get; set; }



    }
}
