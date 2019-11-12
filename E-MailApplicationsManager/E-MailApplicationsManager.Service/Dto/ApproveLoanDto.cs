using System;
using System.Collections.Generic;
using System.Text;

namespace E_MailApplicationsManager.Service.Dto
{
    public class ApproveLoanDto
    {
        public string UserId { get; set; }
        
        public string IsApprove { get; set; }

        public string GmailId { get; set; }
    }
}
