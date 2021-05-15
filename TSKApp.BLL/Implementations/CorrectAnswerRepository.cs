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
    public class CorrectAnswerRepository: ICorrectAnswerRepository
    {
        private readonly TSKDbContext _context;
        public CorrectAnswerRepository(TSKDbContext context)
        {
            _context = context;
        }
        public void SetCorrectAnswerIntoDb(CorrectAnswer correct)
        {
            _context.CorrectAnswers.Add(correct);
            _context.SaveChanges();
        }
        public List<CorrectAnswer> GetAllCorrectAnswersByQuestionId(int Id)
        {
            return _context.CorrectAnswers.Include(x => x.Answer).Include(x => x.Question).ThenInclude(x => x.Answers).Where(x => x.QuestionId == Id).ToList();
        }
    }
}
