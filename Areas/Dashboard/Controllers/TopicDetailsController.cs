using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QuizNSwap.Areas.Dashboard.Controllers
{
    public class TopicDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
