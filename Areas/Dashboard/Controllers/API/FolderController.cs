using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Areas.Dashboard.Controllers.API.Models;
using System.Security.Claims;
using QuizNSwap.BusinessServices;

namespace QuizNSwap.Areas.Dashboard.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly FolderService folderService;

        public FolderController(FolderService folderService)
        {
            this.folderService = folderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFolder(/*[FromBody]*/ string folderName)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var success = await folderService.AddFolder(userId, folderName);

            if (success > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
