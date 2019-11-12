using E_MailApplicationsManager.Models.BaseEntitys;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_MailApplicationsManager.Models.Model
{
    public class LoanApplicant : BaseIdEntity
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string EGN { get; set; }

        public string GmailId { get; set; }

        public bool IsApproved { get; set; } 

        public User User { get; set; }

        public string UserId { get; set; }

        [ForeignKey("Email")]
        public int? EmailId { get; set; }

        public virtual Email Emails { get; set; }
    }
}
