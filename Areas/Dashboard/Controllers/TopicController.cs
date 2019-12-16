using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Data;
using QuizNSwap.Areas.Dashboard.ViewModels;
using QuizNSwap.Data.Models;
using System.Security.Claims;

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

        [HttpGet]
        public IActionResult Add()
        {
            TopicCreateViewModel topicCreateViewModel = new TopicCreateViewModel();

            return View("Add", topicCreateViewModel);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            TopicEditViewModel topicEditViewModel = new TopicEditViewModel();

            return View("Edit", topicEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTopic(TopicCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var topic = new Topic()
                {
                    Name = viewModel.TopicName,
                    UserId = userId
                };
                foreach (TopicCreateViewModel.QuestionCard qcard in viewModel.QuestionCards)
                {
                    topic.QuestionCards.Add(new QuestionCard()
                    {
                        Question = qcard.Question,
                        UserId = userId
                    });
                }

                dbContext.Topics.Add(topic);
                var result = await dbContext.SaveChangesAsync();

                if (result > 0)//success
                {
                }
                else { }
            }

            return View("Add", viewModel);
        }




    }
}
