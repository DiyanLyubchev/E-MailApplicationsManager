using E_MailApplicationsManager.Models.BaseEntitys;
using E_MailApplicationsManager.Models.Common;
using System;
using System.Collections.Generic;

namespace E_MailApplicationsManager.Models
{
    public class Email : BaseIdEntity
    {
        public string GmailId { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string Sender { get; set; }

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
