using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Models;

namespace TSKTests.Mocks
{
    class UsersRepositoryMock : IUsersRepository
    {
        public string GetIdByName(string Name)
        {
            return "";
        }

        public void UpdateUser(AppUser user)
        {
            throw new NotImplementedException();
        }

        public void GetUserById(int userId)
        {
            // do nothing
        }

        public AppUser GetUserById(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
