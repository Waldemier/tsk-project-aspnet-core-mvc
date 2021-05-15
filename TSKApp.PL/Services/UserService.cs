using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL;
using TSKApp.DAL.Models;
using TSKApp.PL.Models;

namespace TSKApp.PL.Services
{
    public class UserService
    {
        private readonly DataManager _dataManager;
        public UserService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public void UpdateUserModel(UserViewModel model)
        {
            AppUser user = new AppUser() { Id = model.Id, FirstName = model.FirstName, LastName = model.LastName, Avatar = model.Avatar };
            _dataManager.Users.UpdateUser(user);
        }
        public UserViewModel GetUserById(string Id)
        {
            var user = _dataManager.Users.GetUserById(Id);
            UserViewModel model = new UserViewModel();
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Avatar = user.Avatar;
            model.Id = Id;
            return model;
        }
    }
}
