using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Areas.Dashboard.ViewModels;
using QuizNSwap.Data.Models;
using System.Security.Claims;
using QuizNSwap.Data;
using Microsoft.EntityFrameworkCore;

namespace QuizNSwap.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly QuizNSwapContext dbContext;

        public HomeController(UserManager<User> userManager, SignInManager<User> signInManager, QuizNSwapContext dbContext)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();

            // will give the user's userId
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //get user folders + topics count
            var foldersResult = await dbContext.Folders.Where(f => f.UserId == userId)
                            .Select(f => new
                            {
                                f.Id,
                                f.Name,
                                f.Topics.Count
                            }).ToListAsync();

            //get user topics NOT IN folder + count of questions
            var topicsResult = await dbContext.Topics.
                Where(t => t.UserId == userId && t.FolderId == null)
                .Select( t => new
                {
                    t.Id,
                    t.Name,
                    t.QuestionCards.Count
                })
                .ToListAsync();

            foreach (var folder in foldersResult)
            {
                homeViewModel.Folders.Add(new HomeViewModel.Folder
                {
                    Id = (int)folder.Id,
                    Name = folder.Name,
                    TopicCount = folder.Count
                });
            }

            foreach (var topic in topicsResult)
            {
                homeViewModel.Topics.Add(new HomeViewModel.Topic
                {
                    Id = (int)topic.Id,
                    Name = topic.Name,
                    QuestionCardCount = topic.Count
                });
            }

            return View(homeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Signout()
        {
            await signInManager.SignOutAsync();
            return RedirectToRoute("start", new { controller = "User", action = "Index" });
        }



    }
}
