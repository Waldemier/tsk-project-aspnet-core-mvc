using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.DAL.Models;

namespace TSKApp.BLL.Interfaces
{
    public interface ITestsRepository
    {
        Test GetTestById(int Id);
        List<Test> GetTestsByUserId(string Id);
        List<Test> GetAllTests();
        void SetTestIntoDb(Test test);
        void RemoveTestById(int Id);
    }
}
