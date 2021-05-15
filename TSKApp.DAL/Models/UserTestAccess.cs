using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TSKApp.DAL.Models
{
    public class UserTestAccess
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TestId { get; set; }
        public Test Test { get; set; }
        [Required]
        public string UserId { get; set; }
        public AppUser User { get; set; }

    }
}
