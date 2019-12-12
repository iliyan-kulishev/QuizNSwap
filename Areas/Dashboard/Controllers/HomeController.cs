using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Areas.Dashboard.ViewModels;
using QuizNSwap.Data.Models;
using QuizNSwap.BusinessServices;
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
        /*
        private readonly UserService userService;
        private readonly FolderService folderService;
        private readonly TopicService topicService;
        */
        private readonly QuizNSwapContext dbContext;

        public HomeController(UserManager<User> userManager, SignInManager<User> signInManager, QuizNSwapContext dbContext
            /*UserService userService, 
            FolderService folderService, TopicService topicService*/)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            /*
            this.userService = userService;
            this.folderService = folderService;
            this.topicService = topicService;*/
            this.dbContext = dbContext;
        }
        /*
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) // will give the user's userId
        var userName = User.FindFirstValue(ClaimTypes.Name) // will give the user's userName
        var userEmail = User.FindFirstValue(ClaimTypes.Email) // will give the user's Email
        */
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
                    Name = folder.Name,
                    TopicCount = folder.Count
                });
            }

            foreach (var topic in topicsResult)
            {
                homeViewModel.Topics.Add(new HomeViewModel.Topic
                {
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

        /*
        [HttpPost]
        public IActionResult CreateFolder(HomeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                //check if unique constraint on Folder.Name was violated
                if (!folderService.AddFolder(userId, viewModel.FolderName))
                {
                    ModelState.AddModelError(nameof(HomeViewModel.FolderName),
                        "There exists a folder with that name");
                }
                else
                {
                    //success here
                    return RedirectToAction("Index", "Home", new { area = "Dashboard" });
                }
            }
            //I want to return error message without reload hmm
            return PartialView("_CreateFolderPartial", viewModel);

        }
        */


    }
}
