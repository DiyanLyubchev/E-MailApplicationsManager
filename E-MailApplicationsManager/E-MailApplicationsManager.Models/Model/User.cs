using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace E_MailApplicationsManager.Models.Model
{
    public class User : IdentityUser
    {
        public ICollection<LoanApplicant> LoanApplicant { get; set; } = new List<LoanApplicant>();

        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();

        public ICollection<Email> Emails { get; set; } = new List<Email>();

        public bool FirstLog { get; set; }

        public DateTime? LastLog { get; set; }

    }
}
