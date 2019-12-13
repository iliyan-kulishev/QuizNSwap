using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Data;
using QuizNSwap.Areas.Dashboard.ViewModels;

namespace QuizNSwap.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class TopicController : Controller
    {
        private readonly QuizNSwapContext dbContext;

        public TopicController(QuizNSwapContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            TopicViewModel topicViewModel = new TopicViewModel();

            return View();
        }


        
    }
}
