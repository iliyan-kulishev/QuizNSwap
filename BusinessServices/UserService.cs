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


    }
}
