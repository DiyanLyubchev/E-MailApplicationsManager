using System;
using System.Collections.Generic;
using System.Text;

namespace E_MailApplicationsManager.Service.Dto
{
    public class AttachmentDTO
    {
        public string FileName { get; set; }

        public double SizeInKB { get; set; }

        public string GmailId { get; set; }
    }
}
