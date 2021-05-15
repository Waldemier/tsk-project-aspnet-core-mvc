namespace TSKApp.PL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class TestViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PassToDate { get; set; }
        public UserViewModel User { get; set; }
        public DateTime Created { get; set; }
    }
    public class TestEditModel
    {
        [DefaultValue(0)]
        public int Id { get; set; }
        [Required]
        [DefaultValue("")]
        public string Name { get; set; }
        [DefaultValue(null)]
        public DateTime PassToDate { get; set; }
    }
}
