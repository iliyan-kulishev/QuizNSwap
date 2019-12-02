using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Data.UnitOfWork;

namespace QuizNSwap.Areas.Users.Controllers
{
    public class ProfileController : Controller
    {
        private IUnitOfWork UnitOfWork;

        public ProfileController(IUnitOfWork untOfWrk)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}