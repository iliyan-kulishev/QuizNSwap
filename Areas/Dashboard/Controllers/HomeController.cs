using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Areas.Dashboard.ViewModels;
using QuizNSwap.Data;
using QuizNSwap.Data.Models;

namespace QuizNSwap.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly UserManager<User> userManager;

        public HomeController()
        {
        }
        /*
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) // will give the user's userId
        var userName = User.FindFirstValue(ClaimTypes.Name) // will give the user's userName
        var userEmail = User.FindFirstValue(ClaimTypes.Email) // will give the user's Email
        */
        public IActionResult Index()
        {
            return View(PopulateViewModel());
        }

        private Home PopulateViewModel()
        {
            Home viewModel = new Home();

            using (var context = new QuizNSwapContext())
            {

            }



            return viewModel;
        }
    }
}
