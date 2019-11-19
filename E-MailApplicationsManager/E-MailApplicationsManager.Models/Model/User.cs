using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace E_MailApplicationsManager.Models.Model
{
    public class User : IdentityUser
    {
        public ICollection<LoanApplicant> LoanApplicant { get; set; } 

        public ICollection<Email> Emails { get; set; }

        public bool FirstLog { get; set; }

        public DateTime? LastLog { get; set; }

    }
}
