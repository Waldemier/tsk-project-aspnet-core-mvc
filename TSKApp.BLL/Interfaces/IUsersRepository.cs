using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.DAL.Models;

namespace TSKApp.BLL.Interfaces
{
    public interface IUsersRepository
    {
        AppUser GetUserById(string userId);

        string GetIdByName(string Name);
        void UpdateUser(AppUser user);
    }
}
