using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using QuizNSwap.Areas.Dashboard.ViewModels;

namespace QuizNSwap.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class HomeController : Controller
    {

        /*
         * The key tool in Identity for restricting
           access to action methods is the Authorize attribute, which tells MVC that only requests from authenticated
           users should be processed.
         */
        
        public IActionResult Index()
        {
            return View();
        }
    }
}