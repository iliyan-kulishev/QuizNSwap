using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Areas.Gameplay.ViewModels;

namespace QuizNSwap.Areas.Gameplay.Controllers
{
    [Area("Gameplay")]
    public class EnterCodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(EnterCode model)
        {
            return View();
        }
    }
}