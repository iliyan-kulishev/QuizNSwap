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
    [Area("")]
    public class UserController : Controller
    {
        private readonly UserManager<QuizNSwap.Data.Models.User> userManager;
        private readonly SignInManager<QuizNSwap.Data.Models.User> signInManager;

        public UserController(UserManager<QuizNSwap.Data.Models.User> userMgr, SignInManager<QuizNSwap.Data.Models.User> signinMgr)
        {
            userManager = userMgr;
            signInManager = signinMgr;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(UserRegistration model)
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


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLogin details, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                QuizNSwap.Data.Models.User user = await userManager.FindByEmailAsync(details.Email);
                if (user != null)
                {
                    //This method cancels any existing session that the user has
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result =
                    /*The arguments for the PasswordSignInAsync method are the user
                    object, the password that the user has provided, a bool argument that controls whether the authentication
                    cookie is persistent(which I disabled) and whether the account should be locked out if the password is
                    correct(which I also disabled).*/
                    await signInManager.PasswordSignInAsync(
                    user, details.Password, false, false);
                    if (result.Succeeded)
                    {
                        //redirect the user to the returnUrl location if it is true
                        return Redirect(returnUrl ?? "/dashboard/home");
                    }
                }
                //add a validation error and redisplay the Login view to the user so they can try again
                ModelState.AddModelError(nameof(UserLogin.Email),
                "Invalid user or password");
                /*
                 * As part of the authentication process, Identity adds a cookie to the response, which the browser then
includes in any subsequent request and which is used to identify the user’s session and the account that is
associated with it. We don’t have to create or manage the cookie directly, as it is handled automatically by
the Identity middleware.
                 */
            }
            return View("Index");
        }


    }
}