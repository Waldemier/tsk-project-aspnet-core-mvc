using System;
using System.Collections.Generic;
using System.Text;
using TSKApp.BLL;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Models;
using TSKApp.PL.Models;

namespace TSKApp.PL.Services
{
    public class QuestionService
    {
        private readonly IDataManager _dataManager;
        public QuestionService(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }
        
        public List<QuestionViewModel> GetQuestionsByTestId(int testId)
        {
            List<QuestionViewModel> models = new List<QuestionViewModel>();
            List<Question> _dbQuestions = _dataManager.Questions.GetQuestionsByTestId(testId);
            foreach(var question in _dbQuestions)
            {
                List<AnswerViewModel> _answerViewModels = new List<AnswerViewModel>();
                foreach(var answer in question.Answers)
                {
                    //[0] because own tests has 1 correct answer
                    var ansId = _dataManager.CorrectAnswers.GetAllCorrectAnswersByQuestionId(question.Id)[0].AnswerId;
                    var correct = (ansId == answer.Id) ? true : false;
                    _answerViewModels.Add(new AnswerViewModel() { Id = answer.Id, Name = answer.Text, Correct = correct });
                }
                models.Add(new QuestionViewModel() { Id = question.Id, Name = question.Text, AnswerViewModels = _answerViewModels });
            }
            return models;
        }

        public void SaveQuestionEditModelIntoDb(QuestionEditModel _model)
        {
            Question _question;
            Answer _answer;
            CorrectAnswer _correctAnswer;
            List<Answer> _answers;

            _question = new Question()
            {
                Text = _model.Name,
                TestId = _model.Id,
            };
            _dataManager.Questions.SetQuestionIntoDb(_question);

            for (int i = 0; i < _model.AnswerEditModels.Count; i++)
            {
                _answer = new Answer();
                _answer.Text = _model.AnswerEditModels[i].Name;
                _answer.QuestionId = _question.Id;
                _dataManager.Answers.SaveAnswer(_answer);

                if (_model.AnswerEditModels[i].Correct)
                {
                    _correctAnswer = new CorrectAnswer()
                    {
                        QuestionId = _question.Id,
                        AnswerId = _answer.Id,
                    };
                    _dataManager.CorrectAnswers.SetCorrectAnswerIntoDb(_correctAnswer);
                }
            }
        }
    }
}
