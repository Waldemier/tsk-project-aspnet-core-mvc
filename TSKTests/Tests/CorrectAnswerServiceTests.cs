using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.PL.Models;
using TSKApp.PL.Services;
using TSKTests.Mocks;
using Xunit;

namespace TSKTests.Tests
{
    public class CorrectAnswerServiceTests
    {
        [Fact]
        public void GetCorrectPropertyByQuestionAndAnswerIdsTest()
        {
            var managerMock = new DataManagerMock(new AnswersRepositoryMock(), new TestsRepositoryMock(),
                new QuestionsRepositoryMock(), new UsersRepositoryMock(), new CorrectAnswerRepositoryMock(), new UserTestAccessRepositoryMock(), new StatisticsRepositoryMock());
            var correctAnswerService = new CorrectAnswerService(managerMock);

            Assert.True(correctAnswerService.GetCorrectPropertyByQuestionAndAnswerIds(1, 1));
            Assert.False(correctAnswerService.GetCorrectPropertyByQuestionAndAnswerIds(2, 3));
        }

        [Fact]
        public void GetModelsFromEditToViewTest()
        {
            var managerMock = new DataManagerMock(new AnswersRepositoryMock(), new TestsRepositoryMock(),
                new QuestionsRepositoryMock(), new UsersRepositoryMock(), new CorrectAnswerRepositoryMock(), new UserTestAccessRepositoryMock(), new StatisticsRepositoryMock());
            var correctAnswerService = new CorrectAnswerService(managerMock);
            var answerEditModelResults = new List<CorrectAnswerEditModel>()
            {
                new CorrectAnswerEditModel() {AnswerId = 1, Correct = true, QuestionId = 1, TestId = 1},
                new CorrectAnswerEditModel() {AnswerId = 5, Correct = true, QuestionId = 2, TestId = 1}
            };
            var expected = new List<CorrectAnswerViewModel>()
            {
                new CorrectAnswerViewModel() {Correct = true, QuestionName = "Question1"},
                new CorrectAnswerViewModel() {Correct = true, QuestionName = "Question2"}
            };

            var actual = correctAnswerService.GetModelsFromEditToView(answerEditModelResults);

            Assert.Equal(expected.Count, actual.Count);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.Equal(expected[i].QuestionName, actual[i].QuestionName);
                Assert.Equal(expected[i].Correct, actual[i].Correct);
            }
        }
    }
}
