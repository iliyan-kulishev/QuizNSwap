using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Areas.Users.ViewModels;
using Microsoft.AspNetCore.Identity;
using QuizNSwap.Data.Models;
using QuizNSwap.Data.UnitOfWork;

namespace QuizNSwap.Areas.Users.Controllers
{
    [Area("Users")]
    public class RegistrationController : Controller
    {
        private UserManager<User> userManager;

        private IUnitOfWork UnitOfWork;

        public RegistrationController(UserManager<User> usrMngr, IUnitOfWork untfwrk) 
        {
            userManager = usrMngr;
            UnitOfWork = untfwrk;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Registration model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = model.Name,
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