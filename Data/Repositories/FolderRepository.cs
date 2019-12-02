using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNSwap.Data.Repositories
{
    public class FolderRepository : Repository , IFolderRepository
    {
        public FolderRepository(QuizNSwapContext context) : base(context)
        { }
    }
}
