using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Data.Models;
using QuizNSwap.Data.UnitOfWork;
using QuizNSwap.Areas.User.ViewModels;

namespace QuizNSwap.Areas.User.Controllers
{
    /*
    * Controllers that manage user
   accounts contain functionality that should be available only to authenticated users, such as password
   reset, for example. To that end, I have applied the Authorize attribute to the controller class and then
   used the AllowAnonymous attribute on the individual action methods. This restricts action methods to
   authenticated users by default but allows unauthenticated users to log into the application. I applied the
   ValidateAntiForgeryToken attribute, which I described in Chapter 24 and which works in conjunction with
   the form element tag helper to protect against cross-site request forgery.
    */
    [Area("User")]
    [Authorize]
    public class SignInController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<QuizNSwap.Data.Models.User> userManager;
        private readonly SignInManager<QuizNSwap.Data.Models.User> signInManager;

        public SignInController(IUnitOfWork unitOfWork, UserManager<QuizNSwap.Data.Models.User> userMgr, SignInManager<QuizNSwap.Data.Models.User> signinMgr)
        {
            this.unitOfWork = unitOfWork;
            userManager = userMgr;
            signInManager = signinMgr;
        }

        [AllowAnonymous]
        public IActionResult Index(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(SignIn details, string returnUrl)
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
                ModelState.AddModelError(nameof(ViewModels.SignIn.Email),
                "Invalid user or password");
                /*
                 * As part of the authentication process, Identity adds a cookie to the response, which the browser then
includes in any subsequent request and which is used to identify the user’s session and the account that is
associated with it. We don’t have to create or manage the cookie directly, as it is handled automatically by
the Identity middleware.
                 */
            }
            return View("Index", details);
        }
    }
}