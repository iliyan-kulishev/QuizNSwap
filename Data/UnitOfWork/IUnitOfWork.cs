using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizNSwap.Data.Repositories;

namespace QuizNSwap.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IFolderRepository Folders { get; set; }
        public ITopicRepository Topics { get; set; }
        public IQuestionCardRepository QuestionCards { get; set; }
        public IUserRepository Users { get; set; }

    }
}
