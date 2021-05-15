using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.DAL.Models;

namespace TSKApp.BLL.Interfaces
{
    public interface ICorrectAnswerRepository
    {
        void SetCorrectAnswerIntoDb(CorrectAnswer correct);
        List<CorrectAnswer> GetAllCorrectAnswersByQuestionId(int Id);
    }
}
