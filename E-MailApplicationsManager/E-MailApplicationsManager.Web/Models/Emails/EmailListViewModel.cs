using E_MailApplicationsManager.Models;
using System.Collections.Generic;

namespace E_MailApplicationsManager.Web.Models.Emails
{
    public class EmailListViewModel
    {
        public List<EmailViewModel> Emails { get; set; }

        public EmailListViewModel(IEnumerable<Email> emails)
        {
            this.Emails = new List<EmailViewModel>();
            foreach (var email in emails)
            {
                this.Emails.Add(new EmailViewModel(email));
            }
        }
    }
}
