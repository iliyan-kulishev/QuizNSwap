using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Areas.Dashboard.Controllers.API.Models;
using System.Security.Claims;
using QuizNSwap.Data;
using QuizNSwap.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace QuizNSwap.Areas.Dashboard.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly QuizNSwapContext dbContext;

        public FolderController(QuizNSwapContext dbContext)
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


        [HttpDelete("{id}")]
        public IActionResult DeleteFolder(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var folderResult = dbContext.Folders.FirstOrDefault(f => f.Id == id && f.UserId == userId);

            if(folderResult == null)
            {
                return NotFound();
            }

            dbContext.Folders.Remove(folderResult);

            dbContext.SaveChangesAsync();

            return Ok();
        }



        
        [HttpPut]
        public async Task<IActionResult> PutTodoItem([FromQuery(Name = "id")]long id, [FromQuery(Name = "folderName")]string folderName)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var folderIfExists = dbContext.Folders.FirstOrDefault(f => f.Id == id && f.UserId == userId);

            /*
            if (id != folder.Id)
            {
                return BadRequest();
            }*/

            folderIfExists.Name = folderName;


            dbContext.Entry(folderIfExists).State = EntityState.Modified;

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (folderIfExists==null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }





    }
}
