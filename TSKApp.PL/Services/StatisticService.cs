using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Routing.Constraints;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Models;
using TSKApp.PL.Models;

namespace TSKApp.PL.Services
{
    public class StatisticService
    {
        private readonly IDataManager _dataManager;
        public StatisticService(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public List<StatisticModel> GetAllByTestId(int testId)
        {
            var statistics = _dataManager.Statistics.GetAllById(testId);
            List<StatisticModel> models = new List<StatisticModel>();
            if (statistics.Count != 0)
            {
                var test = _dataManager.Tests.GetTestById(testId);
            
                UserViewModel userVM = new UserViewModel();
                userVM.Id = statistics.First().User.Id;
                userVM.FirstName = statistics.First().User.FirstName;
                userVM.LastName = statistics.First().User.LastName;
            
                TestViewModel testVM = new TestViewModel();
                testVM.Id = test.Id;
                testVM.Name = test.Name;
                testVM.PassToDate = test.PassToDate;
                testVM.User = userVM;
                testVM.Created = test.Created;

                foreach (var stat in statistics)
                {
                    StatisticModel model = new StatisticModel();
                    model.User = stat.User;
                    model.Test = testVM;
                    model.Result = stat.Result;
                    model.Id = stat.Id;
                    model.PassTo = stat.Test.PassToDate;
                    model.PassedDate = stat.PassedDate;
                    models.Add(model);
                }
            }
            return models;
        }

        public void SetIntoDb(StatisticModel model)
        {
            Statistic statistic = new Statistic();
            var test = _dataManager.Tests.GetTestById(model.Id);
            statistic.UserId = model.User.Id;
            statistic.User = model.User;
            statistic.TestId = model.Test.Id;
            statistic.Test = test;
            statistic.PassedDate = DateTime.Now;
            statistic.Result = model.Result;
            
            _dataManager.Statistics.SetIntoDb(statistic);
        }
    }
}