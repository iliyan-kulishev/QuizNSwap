using QuizNSwap.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizNSwap.BusinessServices
{
    public class TopicService
    {
        private readonly QuizNSwapContext dbContext;
        public TopicService(QuizNSwapContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int GetNumberQuestionCardsPerTopic(long topicId)
        {
            return dbContext.Topics.FirstOrDefault(t => t.Id == topicId).QuestionCards.Count;
        }
    }
}
