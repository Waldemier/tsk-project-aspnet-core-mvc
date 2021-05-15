using System;
using TSKApp.BLL.Interfaces;

namespace TSKApp.BLL
{
    public class DataManager : IDataManager
    {
        private readonly IAnswersRepository _answersRepository;
        private readonly ITestsRepository _testsRepository;
        private readonly IQuestionsRepository _quesionsRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly ICorrectAnswerRepository _correctAnswerRepository;
        private readonly IUserTestAccessRepository _userTestAccessRepository;
        private readonly IStatisticRepository _statisticRepository;

        public DataManager(IAnswersRepository answersRepository, ITestsRepository testsRepository, IQuestionsRepository quesionsRepository, IUsersRepository usersRepository, ICorrectAnswerRepository correctAnswerRepository, IUserTestAccessRepository userTestAccessRepository, IStatisticRepository statisticRepository)
        {
            _answersRepository = answersRepository;
            _testsRepository = testsRepository;
            _quesionsRepository = quesionsRepository;
            _usersRepository = usersRepository;
            _correctAnswerRepository = correctAnswerRepository;
            _userTestAccessRepository = userTestAccessRepository;
            _statisticRepository = statisticRepository;
        }
        public IAnswersRepository Answers { get { return _answersRepository; } }
        public ITestsRepository Tests { get { return _testsRepository; } }
        public IQuestionsRepository Questions { get { return _quesionsRepository; } }
        public IUsersRepository Users { get { return _usersRepository; } }
        public ICorrectAnswerRepository CorrectAnswers { get { return _correctAnswerRepository; } }
        public IUserTestAccessRepository UserTestAccess { get { return _userTestAccessRepository; } }
        public IStatisticRepository Statistics
        {
            get { return _statisticRepository;  }
        }
    }
}
