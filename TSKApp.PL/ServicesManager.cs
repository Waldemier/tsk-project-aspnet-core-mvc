using Microsoft.AspNetCore.Identity;
using System;
using TSKApp.BLL;
using TSKApp.DAL.Models;
using TSKApp.PL.Services;

namespace TSKApp.PL
{
    public class ServicesManager
    {
        private readonly DataManager _dataManager;
        private readonly AnswerService _answerService;
        private readonly TestService _testService;
        private readonly QuestionService _questionService;
        private readonly UserService _userService;
        private readonly CorrectAnswerService _correctAnswerService;
        private readonly UserTestAccessService _userTestAccessService;
        private readonly StatisticService _statisticService;

        public ServicesManager(DataManager dataManager)
        {
            _dataManager = dataManager;
            _statisticService = new StatisticService(dataManager);
            _answerService = new AnswerService(_dataManager);
            _testService = new TestService(_dataManager);
            _questionService = new QuestionService(_dataManager);
            _userService = new UserService(_dataManager);
            _correctAnswerService = new CorrectAnswerService(_dataManager);
            _userTestAccessService = new UserTestAccessService(_dataManager);
        }

        public AnswerService Answers { get { return _answerService; } }
        public TestService Tests { get { return _testService; } }
        public QuestionService Questions { get { return _questionService; } }
        public UserService Users { get { return _userService; } }
        public CorrectAnswerService CorrectAnswers { get { return _correctAnswerService; } }
        public UserTestAccessService UserTestAccess { get { return _userTestAccessService; } }
        public StatisticService Statistics
        {
            get { return _statisticService; }
        }
    }
}
