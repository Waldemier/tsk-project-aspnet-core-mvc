using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Models;

namespace TSKTests.Mocks
{
    class TestsRepositoryMock : ITestsRepository
    {
        public List<Test> GetAllTests()
        {
            return new List<Test>()
            {
                new Test() {Id = 1, Name = "Test1", PassToDate = DateTime.Today, User = new AppUser() {FirstName = "Name1", LastName = "Name2"} },
                new Test() {Id = 2, Name = "Test2", PassToDate = DateTime.Today, User = new AppUser() {FirstName = "Name3", LastName = "Name4"} }
            };
        }

        public Test GetTestById(int Id)
        {
           return new Test() { Id = 1, Name = "Test1", PassToDate = DateTime.Today, User = new AppUser() { FirstName = "Name1", LastName = "Name2" } };
        }

        public List<Test> GetTestsByUserId(string Id)
        {
            return new List<Test>();
        }

        public void RemoveTestById(int Id)
        {
            throw new NotImplementedException();
        }

        public void SetTestIntoDb(Test test)
        {
            // do nothing
        }
    }
}
