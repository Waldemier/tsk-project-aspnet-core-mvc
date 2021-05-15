using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSKApp.DAL.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int TestId { get; set; }
        public Test Test { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
