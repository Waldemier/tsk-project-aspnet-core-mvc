using System;
using System.Collections.Generic;
using TSKApp.PL.Models;
using TSKApp.PL.Services;
using TSKTests.Mocks;
using Xunit;

namespace TSKTests.Tests
{
    public class TestServiceTests
    {
        private const int testId = 1;
        [Fact]
        public void SetTestEditModelIntoDbTest()
        {
            var managerMock = new DataManagerMock(new AnswersRepositoryMock(), new TestsRepositoryMock(),
                new QuestionsRepositoryMock(), new UsersRepositoryMock(), new CorrectAnswerRepositoryMock(), new UserTestAccessRepositoryMock(), new StatisticsRepositoryMock());
            var testService = new TestService(managerMock);
            var testEditModel = new TestEditModel {Id = 1, PassToDate = DateTime.Today, Name = "Fake"};
            var adminName = "admin";
            var expectedTestId = 1;

            var actual = testService.SetTestEditModelIntoDb(testEditModel, adminName);

            Assert.Equal(expectedTestId, actual);

            testEditModel.Id = 0;
            expectedTestId = 0;
            actual = testService.SetTestEditModelIntoDb(testEditModel, adminName);

            Assert.Equal(expectedTestId, actual);
        }

        [Fact]
        public void GetTestsListTest()
        {
            var managerMock = new DataManagerMock(new AnswersRepositoryMock(), new TestsRepositoryMock(),
                new QuestionsRepositoryMock(), new UsersRepositoryMock(), new CorrectAnswerRepositoryMock(), new UserTestAccessRepositoryMock(), new StatisticsRepositoryMock());
            var testService = new TestService(managerMock);
            List<TestViewModel> expected = new List<TestViewModel>()
            {
                new TestViewModel() {Id = 1, Name = "Test1", PassToDate = DateTime.Today, User = new UserViewModel() {FirstName = "Name1", LastName = "Name2"} },
                new TestViewModel() {Id = 2, Name = "Test2", PassToDate = DateTime.Today, User = new UserViewModel() {FirstName = "Name3", LastName = "Name4"} }
            };

            var actual = testService.GetTestsList();

            Assert.Equal(expected.Count, actual.Count);

            for (int i = 0; i < actual.Count; i++)
            {
                Assert.Equal(expected[i].Id, actual[i].Id);
                Assert.Equal(expected[i].Name, actual[i].Name);
                Assert.Equal(expected[i].PassToDate, actual[i].PassToDate);
                Assert.Equal(expected[i].User.FirstName, actual[i].User.FirstName);
                Assert.Equal(expected[i].User.LastName, actual[i].User.LastName);
            }

        }

        [Fact]
        public void GetTestByIdTest()
        {
            var managerMock = new DataManagerMock(new AnswersRepositoryMock(), new TestsRepositoryMock(),
                new QuestionsRepositoryMock(), new UsersRepositoryMock(), new CorrectAnswerRepositoryMock(), new UserTestAccessRepositoryMock(), new StatisticsRepositoryMock());
            var testService = new TestService(managerMock);
            var expected = new TestViewModel() { Id = 1, Name = "Test1", PassToDate = DateTime.Today, User = new UserViewModel() { FirstName = "Name1", LastName = "Name2" } };

            var actual = testService.GetTestById(testId);

            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.PassToDate, actual.PassToDate);
            Assert.Equal(expected.User.FirstName, actual.User.FirstName);
            Assert.Equal(expected.User.LastName, actual.User.LastName);

        }
    }
}