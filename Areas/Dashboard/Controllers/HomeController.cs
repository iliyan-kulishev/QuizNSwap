using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Areas.Dashboard.ViewModels;

namespace QuizNSwap.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly Home viewModel;

        public HomeController()
        {
        }

        public IActionResult Index()
        {
            // must get all topics without a folder
            // must get all folder
            Home vmdl = new Home()
            {

            };
            return View(vmdl);
        }
    }
}
