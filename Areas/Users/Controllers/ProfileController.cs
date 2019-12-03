using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Data.Models;
using QuizNSwap.Data.UnitOfWork;

namespace QuizNSwap.Areas.Users.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<User> userManager;
        public ProfileController(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {

            return View();
        }
    }
}