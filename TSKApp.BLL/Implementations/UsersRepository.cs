using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Data;
using TSKApp.DAL.Models;

namespace TSKApp.BLL.Implementations
{
    public class UsersRepository: IUsersRepository
    {
        private readonly TSKDbContext _context;
        public UsersRepository(TSKDbContext context)
        {
            _context = context;
        }

        public string GetIdByName(string Name)
        {
            return _context.Users.Where(x => x.UserName == Name).FirstOrDefault().Id.ToString();
        }

        public void UpdateUser(AppUser user)
        {
            var userDb = _context.Users.FirstOrDefault(x => x.Id == user.Id);
            userDb.Avatar = user.Avatar;
            userDb.FirstName = user.FirstName;
            userDb.LastName = user.LastName;
            _context.Users.Update(userDb);
            _context.SaveChanges();
        }
        
        public AppUser GetUserById(string Id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == Id);
            return user;
        }
    }
}
