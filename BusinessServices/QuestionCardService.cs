using QuizNSwap.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNSwap.BusinessServices
{
    public class QuestionCardService
    {
        private readonly QuizNSwapContext dbContext;

        public QuestionCardService(QuizNSwapContext dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}
