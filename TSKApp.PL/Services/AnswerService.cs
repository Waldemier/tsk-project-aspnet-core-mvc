using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL;

namespace TSKApp.PL.Services
{
    public class AnswerService
    {
        private readonly DataManager _dataManager;
        public AnswerService(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
    }
}
