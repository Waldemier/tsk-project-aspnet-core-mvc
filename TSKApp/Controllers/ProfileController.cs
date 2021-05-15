using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TSKApp.BLL;
using TSKApp.DAL.Models;
using TSKApp.PL;
using TSKApp.PL.Models;

namespace TSKApp.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;
        private readonly DataManager _dataManager;
        private readonly ServicesManager _serviceManager;
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(ILogger<ProfileController> logger, DataManager dataManager,
            UserManager<AppUser> userManager)
        {
            _logger = logger;
            _dataManager = dataManager;
            _serviceManager = new ServicesManager(_dataManager);
            _userManager = userManager;
        }
        // GET
        public IActionResult Index()
        {
            var user = _serviceManager.Users.GetUserById(_userManager.FindByEmailAsync(User.Identity.Name).Result.Id);
            return View(user);
        }

        public IActionResult Edit(UserViewModel model, IFormFile avatar)
        {
            if (avatar != null)
            {
                byte[] imageData = null;
                using (var binaryReader = new BinaryReader(avatar.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)avatar.Length);
                }
                model.Avatar = imageData;
            }
            
            _serviceManager.Users.UpdateUserModel(model);    

            return RedirectToAction(nameof(Index));
        }
    }
}