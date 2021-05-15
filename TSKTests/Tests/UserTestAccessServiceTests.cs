using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.DAL.Models;
using TSKApp.PL.Models;
using TSKApp.PL.Services;
using TSKTests.Mocks;
using Xunit;

namespace TSKTests.Tests
{
    public class UserTestAccessServiceTests
    {
        [Fact]
        public void GetAllAllowTestsByUserEmailTest()
        {
            var managerMock = new DataManagerMock(new AnswersRepositoryMock(), new TestsRepositoryMock(),
                new QuestionsRepositoryMock(), new UsersRepositoryMock(), new CorrectAnswerRepositoryMock(), new UserTestAccessRepositoryMock(), new StatisticsRepositoryMock());
            var userTestAccessService = new UserTestAccessService(managerMock);
            var expected = new List<TestViewModel>()
            {
                new TestViewModel(){Id = 1, Name = "Test1", PassToDate = DateTime.Today, User = new UserViewModel () { FirstName = "Name1",
                LastName = "Name2" } },
                new TestViewModel(){Id = 2, Name = "Test2", PassToDate = DateTime.Today, User = new UserViewModel () { FirstName = "Name1",
                LastName = "Name2" } }
            };

            var actual = userTestAccessService.GetAllAllowTestsByUserEmail("email");

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
        public void SetAllowTest()
        {
            var userTestAccessRepositoryMock = new UserTestAccessRepositoryMock();
            var managerMock = new DataManagerMock(new AnswersRepositoryMock(), new TestsRepositoryMock(),
                new QuestionsRepositoryMock(), new UsersRepositoryMock(), new CorrectAnswerRepositoryMock(), userTestAccessRepositoryMock, new StatisticsRepositoryMock());
            var userTestAccessService = new UserTestAccessService(managerMock);

            userTestAccessService.SetAllow(1, "1");

            Assert.True(userTestAccessRepositoryMock.IsSetAllow);
        }
    }
}
