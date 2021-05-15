using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSKApp.DAL.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DefaultValue(null)]
        public DateTime PassToDate { get; set; }
        [Required]
        public string UserId { get; set; }
        public AppUser User { get; set; }
        [DefaultValue(null)]
        public DateTime Created { get; set; }
        public List<Question> Questions { get; set; }
    }
}
