using System;
using System.Collections.Generic;
using System.Text;

namespace QuizNSwap.Models.Repositories
{
    interface IUnitOfWork: IDisposable
    {
        ISomeClassRepository SomeClasses { get; }
        int Complete();
    }
}
