using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QuizNSwap.Areas.Play.Controllers
{
    [Area("Play")]
    public class PlayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}