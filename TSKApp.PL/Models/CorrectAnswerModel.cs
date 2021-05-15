namespace TSKApp.PL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CorrectAnswerViewModel
    {
        [Required]
        public string QuestionName { get; set; }
        [Required]
        public bool Correct { get; set; }
    }

    public class CorrectAnswerEditModel
    {
        [Required]
        public int TestId { get; set; }
        [Required]
        public int QuestionId { get; set; }
        [Required]
        public int AnswerId { get; set; }
        [Required]
        public bool Correct { get;set; }
    }
}
