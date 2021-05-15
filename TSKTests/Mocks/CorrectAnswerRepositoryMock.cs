using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Models;

namespace TSKTests.Mocks
{
    class CorrectAnswerRepositoryMock : ICorrectAnswerRepository
    {
        public bool IsSetCorrectAnswerIntoDb { get; set; }
        public List<CorrectAnswer> GetAllCorrectAnswersByQuestionId(int Id)
        {
            if(Id == 1)
            {
                return new List<CorrectAnswer>() { new CorrectAnswer() { Id = 1, QuestionId = 1, AnswerId = 1 } };
            }
            else
            {
                return new List<CorrectAnswer>() { new CorrectAnswer() { Id = 2, QuestionId = 2, AnswerId = 5 } };
            }
        }

        public void SetCorrectAnswerIntoDb(CorrectAnswer correct)
        {
            if(correct.QuestionId == 0 && correct.AnswerId == 0)
            {
                IsSetCorrectAnswerIntoDb = true;
            }
            else
            {
                IsSetCorrectAnswerIntoDb = false;
            }
        }
    }
}
