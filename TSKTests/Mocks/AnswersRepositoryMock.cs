using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Models;

namespace TSKTests.Mocks
{
    class AnswersRepositoryMock : IAnswersRepository
    {
        public bool IsSaveAnswer { get; set; }
        public void SaveAnswer(Answer _answer)
        {
            if(_answer.Text == "AnsText")
            {
                IsSaveAnswer = true;
            }
            else if(_answer.Text == "AnsText2")
            {
                IsSaveAnswer = true;
            }
            else
            {
                IsSaveAnswer = false;
            }
        }
    }
}
