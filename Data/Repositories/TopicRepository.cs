using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNSwap.Data.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly QuizNSwapContext context;

        public TopicRepository(QuizNSwapContext context)
        {
            this.context = context;
        }

    }
}
