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

        public async Task<List<Folder>> GetFoldersByUser(string userId)
        {
            return await dbContext.Folders.Where(f => f.UserId == userId).ToListAsync();
        }

        public async Task<List<Topic>> GetTopicsNotInFolderByUser(string userId)
        {
            return await dbContext.Topics.
                Where(t => t.UserId == userId && t.FolderId == null).ToListAsync();
        }

        
        public int GetNumberTopicsPerFolder(string userId, long folderId)
        {
            return dbContext.Topics.Count(x => x.FolderId == folderId && x.UserId == userId);
        }
        

        //returning int for the called to know if unique constraint was violated
        public async Task<int> AddFolder(string userId, string name)
        {
            /*
             The lifetime of the context begins when the instance is created and ends when the instance
             is either disposed or garbage-collected. Use using if you want all the resources that the
             context controls to be disposed at the end of the block. When you use using, the compiler
             automatically creates a try/finally block and calls dispose in the finally block.*/
            using (dbContext)
            {
                var folder = new Folder
                {
                    Name = name,
                    UserId = userId
                };

                dbContext.Folders.Add(folder);
                return await dbContext.SaveChangesAsync();
            }
        }
    }
}
