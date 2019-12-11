using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuizNSwap.Areas.Dashboard;
using QuizNSwap.Areas.Dashboard.ViewModels;
using QuizNSwap.BusinessServices;
using QuizNSwap.Data.Models;

namespace QuizNSwap.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class ProfileController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly UserManager<QuizNSwap.Data.Models.User> userManager;

        public ProfileController(UserManager<QuizNSwap.Data.Models.User> userManager)
        {
            this.userManager = userManager;
        }



    }
}
