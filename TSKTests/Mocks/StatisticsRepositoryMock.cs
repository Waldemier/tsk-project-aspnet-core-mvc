using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Models;

namespace TSKTests.Mocks
{
    public class StatisticsRepositoryMock : IStatisticRepository
    {
        public List<Statistic> GetAllById(int testId)
        {
            throw new NotImplementedException();
        }

        public void SetIntoDb(Statistic statistic)
        {
            throw new NotImplementedException();
        }
    }
}
