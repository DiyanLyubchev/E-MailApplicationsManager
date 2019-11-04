using System;
using System.Collections.Generic;
using System.Text;

namespace E_MailApplicationsManager.Service.Dto
{
    public class ReceivedEmailDto
    {
        public string GmailId { get; set; }

        public string Subject { get; set; }

        public string Sender { get; set; }

        public string DateReceived { get; set; }

        public string FileName { get; set; }

        public double? SizeInMb { get; set; }
    }
}
