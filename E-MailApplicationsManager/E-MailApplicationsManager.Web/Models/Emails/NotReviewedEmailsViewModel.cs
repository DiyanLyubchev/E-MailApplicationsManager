using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Web.Models.Emails
{
    public class NotReviewedEmailsViewModel
    {
        public NotReviewedEmailsViewModel(int notReviewedEmails)
        {
            this.NotReviewedEmails = notReviewedEmails;
        }
        public int NotReviewedEmails { get; set; }
    }
}
