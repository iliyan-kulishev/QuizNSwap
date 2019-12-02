using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace QuizNSwap.Data.Repositories
{
    public class Repository
    {
        protected readonly DbContext Context;

        public Repository(DbContext context) 
        {
            Context = context;
        }
    }
}
