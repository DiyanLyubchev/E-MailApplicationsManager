﻿using E_MailApplicationsManager.Models.BaseEntitys;
using E_MailApplicationsManager.Models.Common;

namespace E_MailApplicationsManager.Models
{
    public class ReceivedEmail : BaseIdEntity
    {
        public EmailStatusesType Status { get; set; } = EmailStatusesType.NotReviewed;
        public string GmailId { get; set; }

        public string Subject { get; set; }

        public string Sender { get; set; }

        public string DateReceived { get; set; }

    }
}
