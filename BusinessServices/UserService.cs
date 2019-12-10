using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuizNSwap.Data.Models;
using QuizNSwap.Data;
using Microsoft.EntityFrameworkCore;

namespace QuizNSwap.BusinessServices
{
    public class UserService
    {
        private readonly QuizNSwapContext dbContext;

        public UserService(QuizNSwapContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Tuple<long,string>> GetFolderNamesWithIdByUser(string userId)
        {
            var folders = dbContext.Folders.
                Where(f => f.UserId == userId).
                Select(f => new Tuple<long,string>(f.Id,f.Name)).
                ToList();

            return folders;
        }

        public List<Tuple<long, string>> GetTopicNamesWithIdByUser(string userId)
        {
            var topics = dbContext.Topics.
                Where(f => f.UserId == userId).
                Select(f => new Tuple<long, string>(f.Id, f.Name)).
                ToList();

            return topics;
        }
    }
}
