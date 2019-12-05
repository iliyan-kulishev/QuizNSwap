using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QuizNSwap.Areas.Gameplay.Controllers
{
    [Area("Gameplay")]
    public class EnterNameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}