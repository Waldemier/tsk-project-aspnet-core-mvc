using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Models;

namespace TSKTests.Mocks
{
    public class UserTestAccessRepositoryMock : IUserTestAccessRepository
    {
        public bool IsSetAllow { get; set; }
        public List<UserTestAccess> GetAllByUserEmail(string email)
        {
            var appUser = new AppUser()
            {
                Email = "email",
                Id = "1",
                FirstName = "Name1",
                LastName = "Name2",
                AccessFailedCount = 0,
                ConcurrencyStamp = "concurrency",
                EmailConfirmed = true,
                LockoutEnabled = false
            };
            return new List<UserTestAccess>()
            {
                new UserTestAccess(){ Id = 1, TestId = 1, UserId = "1" , Test = new Test() 
                {
                    Id = 1,
                    Name = "Test1",
                    Questions = new List<Question>(),
                    PassToDate = DateTime.Today,
                    User = appUser,
                    UserId = appUser.Id
                } },
                new UserTestAccess(){ Id = 2, TestId = 2, UserId = "1" , Test = new Test()
                {
                    Id = 2,
                    Name = "Test2",
                    Questions = new List<Question>(),
                    PassToDate = DateTime.Today,
                    User = appUser,
                    UserId = appUser.Id
                } }
            };
        }

        public void SetAllow(UserTestAccess userTestAccess)
        {
           IsSetAllow = userTestAccess != null;
        }

        public void RemoveAccessByUserIdAndTestId(string userId, int testI)
        {
            throw new NotImplementedException();
        }
    }
}
