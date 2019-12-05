using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Data.Models;
using QuizNSwap.Data.UnitOfWork;
using QuizNSwap.Areas.Dashboard;

namespace QuizNSwap.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class ProfileController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<QuizNSwap.Data.Models.User> userManager;
        public ProfileController(IUnitOfWork unitOfWork, UserManager<QuizNSwap.Data.Models.User> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {

            return View();
        }
    }
}