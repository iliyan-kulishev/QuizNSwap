using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Areas.Dashboard.Controllers.API.Models;

namespace QuizNSwap.Areas.Dashboard.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        [HttpPost]
        public HttpResponseMessage CreateFolder(Folder folderModel)
        {
            /*
            _context.TodoItems.Add(folderModel);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
            */
            if (ModelState.IsValid)
            {
                // Do something with the product (not shown).
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

        }
    }
}
