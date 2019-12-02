using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Configuration;
using QuizNSwap.Data.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace QuizNSwap.Data
{
    public class QuizNSwapContext : IdentityDbContext<User>
    {
        public QuizNSwapContext()
        {
        }
        public QuizNSwapContext(DbContextOptions<QuizNSwapContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
            /*
            //the whole idea below is to configure the conn string here
            //not from startup
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlite(connectionString); */
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /*modelBuilder.Entity<Folder>().
                HasIndex(p => new { p.ParentFolderId }).IsUnique(true);*/
                
            modelBuilder.Entity<Topic>()
                .HasOne<Folder>(g => g.Folder)
                .WithMany(s => s.Topics)
                .HasForeignKey(s => s.FolderId)
                .OnDelete(DeleteBehavior.Cascade);

            //keys of Identity tables are mapped in OnModelCreating method of IdentityDbContext 
            //and if this method is not called attempting to add migration slaps me with an error
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Folder> Folders { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<QuestionCard> QuestionCards { get; set; }





    }
}
