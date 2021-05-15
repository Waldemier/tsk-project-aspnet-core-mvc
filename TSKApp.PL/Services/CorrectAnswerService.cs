namespace TSKApp.PL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using TSKApp.BLL;
    using TSKApp.BLL.Interfaces;
    using TSKApp.DAL.Models;
    using TSKApp.PL.Models;

    public class CorrectAnswerService
    {
        private readonly IDataManager _dataManager;
        public CorrectAnswerService(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public bool GetCorrectPropertyByQuestionAndAnswerIds(int questionId,int answerId)
        {
            List<CorrectAnswer> _answers = _dataManager.CorrectAnswers.GetAllCorrectAnswersByQuestionId(questionId);
            CorrectAnswer currentAnswer = _answers.Find(x => x.AnswerId == answerId);
            bool correct = currentAnswer != null ? true : false;
            return correct;
        }
        public List<CorrectAnswerViewModel> GetModelsFromEditToView(List<CorrectAnswerEditModel> _questionResults)
        {
            List<CorrectAnswerViewModel> models = new List<CorrectAnswerViewModel>();
            foreach (var questionRes in _questionResults)
            {
                Question question = _dataManager.Questions.GetQuestionsById(questionRes.QuestionId);
                models.Add(new CorrectAnswerViewModel() { QuestionName = question.Text, Correct = questionRes.Correct });
            }
            return models;
        }
    }
}
