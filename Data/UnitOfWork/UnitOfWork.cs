using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizNSwap.Data.Repositories;

namespace QuizNSwap.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuizNSwapContext context;

        public IFolderRepository Folders { get; set; }
        public ITopicRepository Topics { get; set; }
        public IQuestionCardRepository QuestionCards { get; set; }
        public IUserRepository Users { get; set; }

        public UnitOfWork(QuizNSwapContext context) 
        {
            /*this.context = context;
            Folders = new FolderRepository(context);
            Topics = new TopicRepository(context);
            QuestionCard = new QuestionCardRepository(context);
            Users = new UserRepository(context);*/
        }

        public int Complete() 
        {
            return context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }
}
