using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.ViewModels;

namespace QuizNSwap.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<QuizNSwap.Data.Models.User> userManager;

        public RegisterController(UserManager<QuizNSwap.Data.Models.User> userMgr)
        {
            userManager = userMgr;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                QuizNSwap.Data.Models.User user = new QuizNSwap.Data.Models.User
                {
                    UserName = model.UserName,
                    Email = model.Email
                };
                IdentityResult result
                = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View("Index");
        }




    }
}
