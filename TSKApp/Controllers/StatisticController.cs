using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TSKApp.BLL;
using TSKApp.DAL.Models;
using TSKApp.PL;
using TSKApp.PL.Models;

namespace TSKApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StatisticController : Controller
    {
        private readonly ILogger<StatisticController> _logger;
        private readonly DataManager _dataManager;
        private readonly ServicesManager _serviceManager;
        private readonly UserManager<AppUser> _userManager;

        public StatisticController(ILogger<StatisticController> logger, DataManager dataManager,
            UserManager<AppUser> userManager)
        {
            _logger = logger;
            _dataManager = dataManager;
            _serviceManager = new ServicesManager(_dataManager);
            _userManager = userManager;
        }

        // GET
        public IActionResult Index(int testId)
        {
            //List<TestViewModel> model = _serviceManager.Tests.GetTestsList().Where(x=>x.User.Id == _userManager.FindByEmailAsync(User.Identity.Name).Result.Id).ToList();
            List<StatisticModel> model = _serviceManager.Statistics.GetAllByTestId(testId);
            return View(model);
        }
    }
}