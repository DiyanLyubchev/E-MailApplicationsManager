﻿using System;
using System.Collections.Generic;
using System.Text;

namespace E_MailApplicationsManager.Service.Dto
{
    public class EmailDto
    {
        public string GmailId { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string Sender { get; set; }

        public string DateReceived { get; set; }
    }
}
