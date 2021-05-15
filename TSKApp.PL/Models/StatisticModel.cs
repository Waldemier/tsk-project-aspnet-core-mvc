using System;
using System.ComponentModel;
using TSKApp.DAL.Models;

namespace TSKApp.PL.Models
{
    public class StatisticModel
    {
        [DefaultValue(null)]
        public int Id { get; set; }
        public AppUser User { get; set; }
        public TestViewModel Test { get; set; }
        public int Result { get; set; }
        public DateTime PassTo { get; set; }
        public DateTime PassedDate { get; set; }
    }
}