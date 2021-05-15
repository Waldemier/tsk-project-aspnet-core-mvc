using TSKApp.BLL.Interfaces;

namespace TSKTests.Mocks
{
    public class DataManagerMock : IDataManager
    {
        public DataManagerMock(IAnswersRepository answersRepository, ITestsRepository testsRepository,
            IQuestionsRepository questionsRepository, IUsersRepository usersRepository,
            ICorrectAnswerRepository correctAnswerRepository, IUserTestAccessRepository userTestAccess, IStatisticRepository statisticRepository)
        {
            Answers = answersRepository;
            Tests = testsRepository;
            Questions = questionsRepository;
            Users = usersRepository;
            CorrectAnswers = correctAnswerRepository;
            UserTestAccess = userTestAccess;
            Statistics = statisticRepository;
        }

        public IAnswersRepository Answers { get; }

        public ITestsRepository Tests { get; }

        public IQuestionsRepository Questions { get; }

        public IUsersRepository Users { get; }

        public ICorrectAnswerRepository CorrectAnswers { get; }

        public IUserTestAccessRepository UserTestAccess { get; }
        public IStatisticRepository Statistics { get; }
    }
}