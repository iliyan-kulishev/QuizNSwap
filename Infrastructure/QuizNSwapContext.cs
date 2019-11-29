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

        public DbSet<Folder> Folders { get; set; }
        public DbSet<Question> QnAs { get; set; }
        public DbSet<Quiz> QuestionSets { get; set; }



    }
}
