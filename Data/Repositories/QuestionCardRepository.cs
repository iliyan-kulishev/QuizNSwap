using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNSwap.Data.Repositories
{
    public class QuestionCardRepository : IQuestionCardRepository
    {
        private readonly QuizNSwapContext context;

        public QuestionCardRepository(QuizNSwapContext context)
        {
            this.context = context;
        }

    }
}
