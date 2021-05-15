using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.DAL.Models;

namespace TSKApp.BLL.Interfaces
{
    public interface IUserTestAccessRepository
    {
        List<UserTestAccess> GetAllByUserEmail(string email);
        void SetAllow(UserTestAccess userTestAccess); 
        void RemoveAccessByUserIdAndTestId(string userId, int testI);
    }
}
