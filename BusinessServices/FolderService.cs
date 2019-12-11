using Microsoft.EntityFrameworkCore;
using QuizNSwap.Data;
using QuizNSwap.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Data.Common;


namespace QuizNSwap.BusinessServices
{
    public class FolderService
    {
        private readonly QuizNSwapContext dbContext;

        public FolderService(QuizNSwapContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int GetNumberTopicsPerFolder(long folderId)
        {
            return dbContext.Topics.Count(x => x.FolderId == folderId);
        }

        //returning int for the called to know if unique constraint was violated
        public bool AddFolder(string userId, string name)
        {
            using (dbContext)
            {
                var folder = new Folder
                {
                    Name = name,
                    UserId = userId
                };

                dbContext.Folders.Add(folder);
                try
                {
                    dbContext.SaveChanges();
                }
                catch(DbUpdateException e)
                {
                    var dbException = e.InnerException as SqliteException;
                    //this should be the error code for violated unique constraint
                    if (dbException.SqliteErrorCode == 2067)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
