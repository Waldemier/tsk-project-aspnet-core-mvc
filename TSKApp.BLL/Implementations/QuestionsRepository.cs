using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL.Data;
using TSKApp.DAL.Models;

namespace TSKApp.BLL.Implementations
{
    public class QuestionsRepository: IQuestionsRepository
    {
        private readonly TSKDbContext _context;
        public QuestionsRepository(TSKDbContext context)
        {
            _context = context;
        }

        public List<Question> GetQuestionsByTestId(int Id)
        {
            return _context.Questions.Include(x => x.Answers).Where(x => x.TestId == Id).ToList();
        }
        public Question GetQuestionsById(int questionId)
        {
            return _context.Questions.Where(x => x.Id == questionId).FirstOrDefault();
        }
        public void SetQuestionIntoDb(Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
        }
    }
}
