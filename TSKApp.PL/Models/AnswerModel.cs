using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSKApp.PL.Models
{
    public class AnswerViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool Correct { get; set; }
    }

    public class AnswerEditModel
    {
        [Required]
        [DisplayName("Answer")]
        public string Name { get; set; }
        [DefaultValue(null)]
        public int questionId { get; set; }
        [DefaultValue(false)]
        public bool Correct { get; set; }
    }
}
