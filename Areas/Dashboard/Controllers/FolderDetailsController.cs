using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Data;
using QuizNSwap.Areas.Dashboard.ViewModels;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace QuizNSwap.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]

    public class FolderDetailsController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly QuizNSwapContext dbContext;

        public FolderDetailsController(QuizNSwapContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index(int? id)
        {
            FolderDetails folderViewModel = new FolderDetails();

            // will give the user's userId
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //get the particular folder(id, name, topic count) for the user by its id - DONE
            //containing the topics'(id, name + Qcard count)
            var thefolder = await dbContext.Folders.
                Where(f => f.UserId == userId && f.Id == id)
                .Select(f => new
                {
                    f.Id,
                    f.Name,
                    f.Topics.Count
                }).ToListAsync();
                
            var topicsResult = await dbContext.Topics.
                Where(t => t.UserId == userId && t.FolderId == id)
                .Select(t => new
                {
                    t.Id,
                    t.Name,
                    t.QuestionCards.Count
                }).ToListAsync();

            folderViewModel.Id = (int)thefolder.FirstOrDefault().Id;
            folderViewModel.FolderName = thefolder.FirstOrDefault().Name;

            foreach (var topic in topicsResult)
            {
                folderViewModel.Topics.Add(new FolderDetails.Topic
                {
                    Id = (int)topic.Id,
                    Name = topic.Name,
                    QuestionCardCount = topic.Count
                });
            }

            return View(folderViewModel);
        }
    }
}
