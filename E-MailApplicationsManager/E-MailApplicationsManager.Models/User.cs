using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace E_MailApplicationsManager.Models
{
    public class User : IdentityUser
    {
        public ICollection<LoanApplicant> LoanApplicant { get; set; } = new List<LoanApplicant>();

        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
    }
}
