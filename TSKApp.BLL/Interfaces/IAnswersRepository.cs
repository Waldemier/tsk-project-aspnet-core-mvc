using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.DAL.Models;

namespace TSKApp.BLL.Interfaces
{
    public interface IAnswersRepository
    {
        void SaveAnswer(Answer _answer);
    }
}
