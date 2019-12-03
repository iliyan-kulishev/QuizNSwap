using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Data.Models;
using QuizNSwap.Data.UnitOfWork;

namespace QuizNSwap.Areas.Users.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IUnitOfWork unitOfWork;

        public LoginController(SignInManager<User> signInManager, UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {

            return View();
        }

        /* SNIPPET
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.UserIDOrLogonName, Input.Password, Input.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(Input.Email);
                    var userId = user.Id;
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
            }
            /// more stuff
        }*/
    }
}