﻿using E_MailApplicationsManager.Models.BaseEntitys;
using System;
using System.Collections.Generic;

namespace E_MailApplicationsManager.Models
{
    public class Email : BaseIdEntity
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public string Sender { get; set; }

        public DateTime DateReceived { get; set; }

        public DateTime? InitialRegistrationInData { get; set; }

        public DateTime SetCurrentStatus { get; set; }

        public DateTime? SetTerminalState { get; set; }

        public ICollection<EmailAttachment> EmailAttachments { get; set; } = new List<EmailAttachment>();

        public string FileName { get; set; }

        public double? SizeInMb { get; set; }
    }
}
