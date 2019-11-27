using E_MailApplicationsManager.Models.BaseEntitys;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_MailApplicationsManager.Models.Model
{
    public class LoanApplicant : BaseIdEntity
    {
        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8)]
        public string PhoneNumber { get; set; }

        [Required]
        public string EGN { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string GmailId { get; set; }

        public bool IsApproved { get; set; } 

        public User User { get; set; }

        public string UserId { get; set; }

        [ForeignKey("Email")]
        public int? EmailId { get; set; }

        public virtual Email Emails { get; set; }

    }
}
