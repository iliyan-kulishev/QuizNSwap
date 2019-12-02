using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuizNSwap.Data.Models
{
    public class Folder
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Topic> Topics { get; set; }
        /*
        public long? ParentFolderId { get; set; } // can be null, but has to be unique (job for Fluent API)
        //navigation property
        //public Folder ParentFolder { get; set; }
        */
        //navigation property


        /*TODO: Automatically storing of creation date - slightly different code for update date
         * 
         * 1. Prepare some asbtract class
         * 
         * public class BaseFolder
         * { 
         *      [Required]
                public DateTime DateCreated { get; set; }
           }
         * 2. Make Folder inherit from BaseFolder
         * 
         * 4. In the Context class:
         * 
         * public override int SaveChanges()
            {
                var entries = ChangeTracker
                    .Entries()
                    .Where(e => e.Entity is BaseFolder && (
                            e.State == EntityState.Added));

                foreach (var entityEntry in entries)
                {
                    if (entityEntry.State == EntityState.Added)
                    {
                        ((BaseFolder)entityEntry.Entity).CreatedDate = DateTime.Now;
                    }
                }

                return base.SaveChanges();
            }
         */
    }
}
