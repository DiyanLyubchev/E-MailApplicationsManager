using E_MailApplicationsManager.Models.BaseEntitys;
using E_MailApplicationsManager.Models.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_MailApplicationsManager.Models.Model
{
    public class Email : BaseIdEntity
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string GmailId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Subject { get; set; }

       
        [StringLength(1000)]
        public string Body { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Sender { get; set; }

        [Required]
        public string DateReceived { get; set; }

        public DateTime? InitialRegistrationInData { get; set; }

        public DateTime? SetCurrentStatus { get; set; }

        public DateTime? SetTerminalState { get; set; }

        public ICollection<EmailAttachment> EmailAttachments { get; set; } = new List<EmailAttachment>();

        public bool IsSeen { get; set; } 

        public EmailStatus Status { get; set; }

        public int EmailStatusId { get; set; } = (int)EmailStatusesType.NotReviewed;

        public User User { get; set; }

        public string UserId { get; set; }

        public LoanApplicant LoanApplicant { get; set; }
    }
}
