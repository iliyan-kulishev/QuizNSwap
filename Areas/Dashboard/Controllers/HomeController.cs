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

namespace QuizNSwap.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly UserService userService;
        private readonly FolderService folderService;
        private readonly TopicService topicService;

        public HomeController(UserManager<User> userManager, SignInManager<User> signInManager, UserService userService, 
            FolderService folderService, TopicService topicService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.userService = userService;
            this.folderService = folderService;
            this.topicService = topicService;
        }
        /*
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) // will give the user's userId
        var userName = User.FindFirstValue(ClaimTypes.Name) // will give the user's userName
        var userEmail = User.FindFirstValue(ClaimTypes.Email) // will give the user's Email
        */
        public IActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();

            // will give the user's userId
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            #region prepare folders info
            var folderNamesWithId = userService.GetFolderNamesWithIdByUser(userId);
            
            foreach (Tuple<long, string> pair in folderNamesWithId)
            {
                var folder = new HomeViewModel.Folder()
                {
                    Name = pair.Item2,
                    TopicCount = folderService.GetNumberTopicsPerFolder(pair.Item1) 
                };
                homeViewModel.Folders.Add(folder);
            }
            #endregion

            #region prepare the topics info
            var topicsNamesWithId = userService.GetTopicNamesWithIdByUser(userId);

            foreach (Tuple<long, string> pair in topicsNamesWithId)
            {
                var topic = new HomeViewModel.Topic()
                {
                    Name = pair.Item2,
                    QuestionCardCount = topicService.GetNumberQuestionCardsPerTopic(pair.Item1)
                };
                homeViewModel.Topics.Add(topic);
            }
            #endregion

            return View(homeViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Signout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "User");
        }

    }
}
