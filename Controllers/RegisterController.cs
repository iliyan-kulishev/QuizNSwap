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
        private readonly SignInManager<QuizNSwap.Data.Models.User> signInManager;

        public RegisterController(UserManager<QuizNSwap.Data.Models.User> userMgr, SignInManager<QuizNSwap.Data.Models.User> signInManager)
        {
            userManager = userMgr;
            this.signInManager = signInManager;
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
                    await signInManager.SignInAsync(user, isPersistent: false);                   
                   return RedirectToAction("Index", "Home", new { area = "Dashboard" });      
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
