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
    public class TestsRepository: ITestsRepository
    {
        private readonly TSKDbContext _context;
        public TestsRepository(TSKDbContext context)
        {
            _context = context;
        }

        public void RemoveTestById(int Id)
        {
            var test = _context.Tests.FirstOrDefault(x => x.Id == Id);
            _context.Tests.Remove(test);
            _context.SaveChanges();
        }

        public List<Test> GetAllTests()
        {
            return _context.Tests.Include(x => x.User).Include(x => x.Questions).ThenInclude(x => x.Answers).ToList();
        }

        public Test GetTestById(int Id)
        {
            return _context.Tests.Include(x => x.Questions).ThenInclude(x => x.Answers).Include(x => x.User).Where(x => x.Id == Id).FirstOrDefault();
        }

        public List<Test> GetTestsByUserId(string Id)
        {
            return _context.Tests.Include(x => x.Questions).ThenInclude(x => x.Answers).Where(x => x.UserId == Id).ToList();
        }
        public void SetTestIntoDb(Test test)
        {
            if (test.Id == 0)
            {
                test.Created = DateTime.Now;
                _context.Tests.Add(test);
            }
            else
            {
                _context.Entry(test).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            _context.SaveChanges();
        }
    }
}
