using System.Collections.Generic;
using TSKApp.DAL.Models;

namespace TSKApp.BLL.Interfaces
{
    public interface IStatisticRepository
    {
        void SetIntoDb(Statistic statistic);
        List<Statistic> GetAllById(int testId);
    }
}