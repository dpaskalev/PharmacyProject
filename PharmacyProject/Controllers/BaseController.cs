using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PharmacyProject.Data.DataModels;
using PharmacyProject.Servises;
using PharmacyProject.Servises.Interfaces;
using PharmacyProject.VewModels;
using System;

namespace PharmacyProject.Controllers
{
    public class BaseController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public BaseController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        protected string GetUserId()
        {
            var userId = _userManager.GetUserId(User);

            return userId;
        }
    }
}
