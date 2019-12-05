using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace QuizNSwap.Areas.Dashboard.Controllers
{
    public class FolderDetailsController : Microsoft.AspNetCore.Mvc.Controller
    {
        [Area("Dashboard")]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}