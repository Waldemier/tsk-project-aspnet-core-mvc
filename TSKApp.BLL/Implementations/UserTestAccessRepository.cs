using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Data;
using TSKApp.DAL.Models;

namespace TSKApp.BLL.Implementations
{
    public class UserTestAccessRepository : IUserTestAccessRepository
    {
        private readonly TSKDbContext _context;
        public UserTestAccessRepository(TSKDbContext context)
        {
            _context = context;
        }
        public List<UserTestAccess> GetAllByUserEmail(string email)
        {
            return _context.UserTestAccesses.Include(x => x.User).Include(x => x.Test).ThenInclude(x => x.User).Where(x => x.User.Email == email).ToList();
        }

        public void RemoveAccessByUserIdAndTestId(string userId, int testId)
        {
            var access = _context.UserTestAccesses.FirstOrDefault(x => x.UserId == userId && x.TestId == testId);
            _context.UserTestAccesses.Remove(access);
            _context.SaveChanges();
        }
        
        public void SetAllow(UserTestAccess userTestAccess)
        {
            var check = _context.UserTestAccesses.Where(x => (x.TestId == userTestAccess.TestId && x.UserId == userTestAccess.UserId)).FirstOrDefault();
            if(userTestAccess.Id != 0 || check != null)
            {
                _context.Entry(userTestAccess).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                _context.UserTestAccesses.Add(userTestAccess);
            }
            _context.SaveChanges();
        }
    }
}
