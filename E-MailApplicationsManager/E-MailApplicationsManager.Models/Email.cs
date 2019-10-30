using E_MailApplicationsManager.Models.BaseEntitys;
using System;
using System.Collections.Generic;

namespace E_MailApplicationsManager.Models
{
    public class Email : BaseIdEntity
    {
        public string Content { get; set; }

        public DateTime DateReceived { get; set; }

        public ICollection<EmailAttachment> EmailAttachments { get; set; } = new List<EmailAttachment>();
    }
}
