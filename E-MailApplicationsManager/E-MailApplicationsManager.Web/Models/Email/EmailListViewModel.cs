using E_MailApplicationsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Web.Models.Email
{
    public class EmailListViewModel
    {
        public List<EmailViewModel> Emails { get; set; }
        public EmailListViewModel(IEnumerable<ReceivedEmail> email)
        {
            this.Emails = new List<EmailViewModel>();
            foreach (var emails in email)
            {
                this.Emails.Add(new EmailViewModel(emails));
            }
        }
    }
}
