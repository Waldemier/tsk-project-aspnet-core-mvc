using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Data;
using TSKApp.DAL.Models;

namespace TSKApp.BLL.Implementations
{
    public class StatisticRepository: IStatisticRepository
    {
        private readonly TSKDbContext _context;
        public StatisticRepository(TSKDbContext context)
        {
            this._context = context;
        }

        public void SetIntoDb(Statistic statistic)
        {
            _context.Statistics.Add(statistic);
            _context.SaveChanges();
        }


        
        public List<Statistic> GetAllById(int testId)
        {
            var stat = _context.Statistics.Include(x => x.Test).Include(x=> x.User).Where(x => x.Test.Id == testId).ToList();
            return stat;
        }
    }
}