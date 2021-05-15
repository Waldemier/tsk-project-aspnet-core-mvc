namespace TSKApp.BLL.Interfaces
{
    public interface IDataManager
    {
        IAnswersRepository Answers { get; }
        ITestsRepository Tests { get; }
        IQuestionsRepository Questions { get; }
        IUsersRepository Users { get; }
        ICorrectAnswerRepository CorrectAnswers { get; }
        IUserTestAccessRepository UserTestAccess { get; }
        IStatisticRepository Statistics { get; }
    }
}