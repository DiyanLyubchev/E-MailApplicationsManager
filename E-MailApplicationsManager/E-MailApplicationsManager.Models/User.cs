﻿using Microsoft.AspNetCore.Identity;

namespace E_MailApplicationsManager.Models
{
    public class User : IdentityUser
    {
        public LoanApplicant LoanApplicant { get; set; }
    }
}
