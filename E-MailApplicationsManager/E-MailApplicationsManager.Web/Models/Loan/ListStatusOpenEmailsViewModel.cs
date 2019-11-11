using E_MailApplicationsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Web.Models.Emails
{
    public class ListStatusOpenEmailsViewModel
    {
        public List<StatusOpenEmailsViewModel> Emails { get; set; }

        public ListStatusOpenEmailsViewModel(IEnumerable<LoanApplicant> openStatusEmails)
        {
            this.Emails = new List<StatusOpenEmailsViewModel>();
            foreach (var openStatusEmail in openStatusEmails)
            {
                this.Emails.Add(new StatusOpenEmailsViewModel(openStatusEmail));
            }
        }
    }
}
