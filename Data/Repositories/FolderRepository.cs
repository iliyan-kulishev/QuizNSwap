using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNSwap.Data.Repositories
{
    public class FolderRepository : IFolderRepository
    {
        private readonly QuizNSwapContext context;

        public FolderRepository(QuizNSwapContext context)
        {
            this.context = context;
        }
    }
}
