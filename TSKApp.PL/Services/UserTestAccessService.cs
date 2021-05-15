namespace TSKApp.PL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.AspNetCore.Identity;
    using TSKApp.BLL;
    using TSKApp.BLL.Interfaces;
    using TSKApp.DAL.Models;
    using TSKApp.PL.Models;

    public class UserTestAccessService
    {
        private readonly IDataManager _dataManager;
        public UserTestAccessService(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }
        public void SetAllow(int testId, string userId)
        {
            var userTestAccess = new UserTestAccess() { TestId = testId, UserId = userId };
            _dataManager.UserTestAccess.SetAllow(userTestAccess);
        }

        public void RemoveAccessByUserIdAndTestId(string userId, int testId)
        {
            _dataManager.UserTestAccess.RemoveAccessByUserIdAndTestId(userId, testId);
        }

        public List<TestViewModel> GetAllAllowTestsByUserEmail(string userEmail)
        {
            List<TestViewModel> testViewModels = new List<TestViewModel>();
            List<UserTestAccess> _dbModelsAccess = _dataManager.UserTestAccess.GetAllByUserEmail(userEmail);
            foreach(var access in _dbModelsAccess)
            {
                UserViewModel user = new UserViewModel() { Id= access.UserId, FirstName = access.Test.User.FirstName, LastName = access.Test.User.LastName };
                testViewModels.Add(new TestViewModel() { Id = access.TestId, Name = access.Test.Name, PassToDate = access.Test.PassToDate, User = user });
            }
            return testViewModels;
        }
    }
}
