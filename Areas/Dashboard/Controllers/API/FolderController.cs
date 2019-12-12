using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Areas.Dashboard.Controllers.API.Models;
using System.Security.Claims;
using QuizNSwap.BusinessServices;
using QuizNSwap.Data;
using QuizNSwap.Data.Models;

namespace QuizNSwap.Areas.Dashboard.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly QuizNSwapContext dbContext;

        public FolderController(FolderService folderService, QuizNSwapContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFolder([FromBody] FolderDTO folder)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var dbFolder = new Folder
            {
                Name = folder.Name,
                UserId = userId
            };

            dbContext.Folders.Add(dbFolder);

            var result = await dbContext.SaveChangesAsync();

            if (result > 0)
            {
                return Ok();
            }
            else return BadRequest();
        }


    }
}
