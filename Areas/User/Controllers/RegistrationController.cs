using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Areas.User.ViewModels;
using Microsoft.AspNetCore.Identity;
using QuizNSwap.Data.Models;
using QuizNSwap.Data.UnitOfWork;

namespace QuizNSwap.Areas.User.Controllers
{
    [Area("User")]
    public class RegistrationController : Controller
    {
        private UserManager<QuizNSwap.Data.Models.User> userManager;

        private IUnitOfWork UnitOfWork;

        public RegistrationController(UserManager<QuizNSwap.Data.Models.User> usrMngr, IUnitOfWork untfwrk) 
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
                QuizNSwap.Data.Models.User user = new QuizNSwap.Data.Models.User
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