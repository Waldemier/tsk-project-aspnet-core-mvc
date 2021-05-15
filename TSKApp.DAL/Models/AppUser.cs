using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TSKApp.DAL.Models
{
    public class AppUser: IdentityUser
    {
        [PersonalData]
        public string FirstName { get; set; }
        
        [PersonalData]
        public string LastName { get; set; }
        
        [PersonalData]
        [DefaultValue(null)]
        public byte[] Avatar { get; set; }
    }
}
