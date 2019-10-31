using E_MailApplicationsManager.Models.BaseEntitys;
using System;

namespace E_MailApplicationsManager.Models
{
    public class AuditLog : BaseIdEntity
    {
        public DateTime Date { get; set; }

        public string InfoLog { get; set; }

        public User User { get; set; }

        public string UserId { get; set; }

        public Email Email { get; set; }

        public int EmailId { get; set; }

        public string LastStatusInfo { get; set; }

        public string NewStatusInfo { get; set; }
    }
}
