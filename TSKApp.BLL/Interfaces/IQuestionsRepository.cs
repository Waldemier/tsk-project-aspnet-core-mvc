using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.DAL.Models;

namespace TSKApp.BLL.Interfaces
{
    public interface IQuestionsRepository
    {
        List<Question> GetQuestionsByTestId(int Id);
        void SetQuestionIntoDb(Question question);
        Question GetQuestionsById(int questionId);
    }
}
