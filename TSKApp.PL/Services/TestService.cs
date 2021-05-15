using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using TSKApp.BLL;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Models;
using TSKApp.PL.Models;

namespace TSKApp.PL.Services
{
    public class TestService
    {
        private readonly IDataManager _dataManager;
        public TestService(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public List<TestViewModel> GetTestsList()
        {
            var tests = _dataManager.Tests.GetAllTests();
            List<TestViewModel> models = new List<TestViewModel>();
            foreach(var test in tests)
            {
                models.Add(new TestViewModel() { Id = test.Id, Name = test.Name, User = new UserViewModel() { Id = test.User.Id, FirstName = test.User.FirstName, LastName = test.User.LastName }, PassToDate = test.PassToDate, Created = test.Created });
            }
            return models;
        }

        public void RemoveTestById(int Id)
        {
            _dataManager.Tests.RemoveTestById(Id);
        }
        public TestViewModel GetTestById(int testId)
        {
            var test = _dataManager.Tests.GetTestById(testId);
            UserViewModel umodel = new UserViewModel() { Id = test.UserId, FirstName = test.User.FirstName, LastName = test.User.LastName, Avatar = test.User.Avatar };
            TestViewModel tmodel = new TestViewModel() { Id = test.Id, Name = test.Name, PassToDate = test.PassToDate, User = umodel, Created = test.Created };
            return tmodel;
        }

        public int SetTestEditModelIntoDb(TestEditModel _model, string adminName)
        {
            Test test;
            if (_model.Id != 0)
            {
                test = _dataManager.Tests.GetTestById(_model.Id);
                test.Name = _model.Name;
                test.PassToDate = _model.PassToDate;
            }
            else
            {
                string userId = _dataManager.Users.GetIdByName(adminName);
                test = new Test()
                {
                    Name = _model.Name,
                    UserId = userId,
                    PassToDate = _model.PassToDate,
                };
            }
            _dataManager.Tests.SetTestIntoDb(test);

            return test.Id;
        }
    }
}
