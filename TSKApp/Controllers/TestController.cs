namespace TSKApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using TSKApp.BLL;
    using TSKApp.DAL.Models;
    using TSKApp.PL;
    using TSKApp.PL.Models;
    using static TSKApp.Enums.Helpers;

    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;
        private readonly DataManager _dataManager;
        private readonly ServicesManager _serviceManager;
        private readonly UserManager<AppUser> _userManager;
        private IHttpContextAccessor _httpContextAccessor;

        public TestController(ILogger<TestController> logger, DataManager dataManager, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _dataManager = dataManager;
            _serviceManager = new ServicesManager(_dataManager);
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        /*public IActionResult Index()
        {
            return View();
        }*/

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult MyTests(string error = null)
        {
            ViewBag.AllowError = error;
            var tests = _serviceManager.Tests.GetTestsList();
            return View(tests);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("/Test/Delete/{Id:int}")]
        public IActionResult Delete(int Id)
        {
            _serviceManager.Tests.RemoveTestById(Id);
            return Ok();
        }
        
        [HttpGet]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> TestPassed(int totalMarks)
        {
            List<CorrectAnswerEditModel> rememberPreviousQuestionResult = _httpContextAccessor.HttpContext.Session.Get<List<CorrectAnswerEditModel>>("ListOfQuestionsResult");
            _httpContextAccessor.HttpContext.Session.Remove("ListOfQuestionsResult");

            var testId = rememberPreviousQuestionResult[0].TestId;
            var test = _serviceManager.Tests.GetTestById(testId);
            
            AppUser user = await _userManager.FindByEmailAsync(User.Identity.Name);
            StatisticModel statModel = new StatisticModel(){ Test = test, User = user, Result = totalMarks };
            _serviceManager.Statistics.SetIntoDb(statModel);

            _serviceManager.UserTestAccess.RemoveAccessByUserIdAndTestId(user.Id, testId);
            
            ViewBag.TotalMarks = totalMarks;
            ViewBag.TestId = testId; //not used
            ViewBag.TestTitle = test.Name;
            
            var models = _serviceManager.CorrectAnswers.GetModelsFromEditToView(rememberPreviousQuestionResult);
            return View(models);
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        public IActionResult TestPassing(int testId, int questionIndex = 0, int totalMarks = 0)
        {
            var questions = _serviceManager.Questions.GetQuestionsByTestId(testId);

            //For remember prev questions result
            List<CorrectAnswerEditModel> rememberPreviousQuestionResult = _httpContextAccessor.HttpContext.Session.Get<List<CorrectAnswerEditModel>>("ListOfQuestionsResult") ?? new List<CorrectAnswerEditModel>();

            ViewBag.TotalMarks = totalMarks;
            if (questionIndex > questions.Count - 1)
            {
                return RedirectToAction("TestPassed", new { totalMarks, rememberPreviousQuestionResult });
            }

            _httpContextAccessor.HttpContext.Session.Set("ListOfQuestionsResult", rememberPreviousQuestionResult);

            var testTitle = _serviceManager.Tests.GetTestById(testId).Name;
            var currentQuestion = questions[questionIndex];
            ViewBag.testId = testId;
            ViewBag.Questions = questions;
            ViewBag.CurrentQuestion = questionIndex + 1;
            ViewBag.QuestionIndex = questionIndex;
            ViewBag.TestTitle = testTitle;

            return View(currentQuestion);
        }

        [HttpPost]
        [Authorize(Roles = "Student")]
        public RedirectToActionResult TestPassingAct(int testId, int questionId, int answerId, int questionIndex, int totalMarks, TestPassingActions actionType/*, List<CorrectAnswerEditModel> rememberPreviousQuestionResult*/)
        {
            var rememberPreviousQuestionResult = _httpContextAccessor.HttpContext.Session.Get<List<CorrectAnswerEditModel>>("ListOfQuestionsResult");
            switch (actionType)
            {
                case TestPassingActions.NextQuestion:
                    bool correct = _serviceManager.CorrectAnswers.GetCorrectPropertyByQuestionAndAnswerIds(questionId, answerId);
                    totalMarks = correct ? totalMarks + 1 : totalMarks;
                    rememberPreviousQuestionResult.Add(new CorrectAnswerEditModel() { TestId = testId, QuestionId = questionId, AnswerId = answerId, Correct = correct });
                    _httpContextAccessor.HttpContext.Session.Set("ListOfQuestionsResult", rememberPreviousQuestionResult);
                    questionIndex++;
                    break;
                default:
                    //Maybe use in future
                    break;
            }
            return RedirectToAction("TestPassing", new { testId, questionIndex, totalMarks });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult CreateTest()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        public IActionResult BeginTestPassing(int testId, string title)
        {
            ViewBag.testId = testId;
            ViewBag.Title = title;
            TestViewModel model = _serviceManager.Tests.GetTestById(testId);
            return View(model);
        }

        [HttpGet]
        [Route("/Allow/{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Allow(int id)
        {
            ViewBag.testId = id;
            return PartialView("_AllowStudentPartial");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Allow(int testId, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            string error = null;
            if (user == null)
            {
                error = "Student not found"; 
            }
            else
            {
                _serviceManager.UserTestAccess.SetAllow(testId, user.Id);
            }
            return RedirectToAction("MyTests", new { error = error });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public RedirectToActionResult CreateTest(TestEditModel _model)
        {
            string adminName = User.Identity.Name;
            int testId = _serviceManager.Tests.SetTestEditModelIntoDb(_model, adminName);
            return RedirectToAction("StartCreateQuestion", new { testId });
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult StartCreateQuestion(int testId)
        {
            //ViewBag.testId = testId;
            var _Model = new QuestionEditModel();
            _Model.Id = testId;
            return View(_Model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult StartCreateQuestion(QuestionEditModel _model, Actions actionType, int removingAnswerId)
        {
            int truthCheckCounter = 0;
            foreach (var prop in _model.AnswerEditModels)
            {
                if (prop.Correct)
                {
                    truthCheckCounter++;
                }
                if (truthCheckCounter > 1)
                {
                    ModelState.AddModelError("Truth answers greater then 1", "There can be only one correct answer");
                    return View(_model);
                }
            }
            //this.ViewBag.testId = testId;
            //_model.Id = testId;
            switch (actionType)
            {
                case Actions.MoreQuestion:
                    if (truthCheckCounter == 0)
                    {
                        ModelState.AddModelError("Correct not selected", "The correct answer is not selected");
                        return View(_model);
                    }
                    _serviceManager.Questions.SaveQuestionEditModelIntoDb(_model);
                    _model = new QuestionEditModel() { Id = _model.Id };
                    ModelState.Clear();
                    break;
                case Actions.MoreAnswer:
                    _model.AnswerEditModels.Add(new AnswerEditModel());
                    break;
                case Actions.RemoveAnswer:
                    AnswerEditModel _answerToDelete = _model.AnswerEditModels[removingAnswerId];
                    if (_model.AnswerEditModels.Count > 1)
                    {
                        _model.AnswerEditModels.Remove(_answerToDelete);
                        ModelState.Clear();
                    }
                    break;
                case Actions.End:
                    if (truthCheckCounter == 0)
                    {
                        ModelState.AddModelError("Correct not selected", "The correct answer is not selected");
                        return View(_model);
                    }
                    _serviceManager.Questions.SaveQuestionEditModelIntoDb(_model);
                    //return RedirectToAction("EndCreating", new { testId=_model.Id });
                    return RedirectToAction("MyTests");
                    break;
                default:
                    break;
            }
            return View(_model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EndCreating(int testId)
        {
            return View();
        }
    }
}
