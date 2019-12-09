using QuizNSwap.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
