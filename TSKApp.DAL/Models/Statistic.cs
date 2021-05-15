using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TSKApp.DAL.Models
{
    public class Statistic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public AppUser User { get; set; }
        [Required]
        public int TestId { get; set; }
        public Test Test { get; set; }
        [Required]
        public int Result { get; set; }
        [DefaultValue(null)]
        public DateTime PassedDate { get; set; }
    }
}