using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNSwap.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly QuizNSwapContext context;

        public UserRepository(QuizNSwapContext context)
        {
            this.context = context;
        }

    }
}
