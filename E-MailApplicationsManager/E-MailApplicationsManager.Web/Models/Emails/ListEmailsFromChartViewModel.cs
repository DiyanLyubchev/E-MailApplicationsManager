using E_MailApplicationsManager.Models.Model;
using System.Collections.Generic;

namespace E_MailApplicationsManager.Web.Models.Emails
{
    public class ListEmailsFromChartViewModel
    {
        public List<EmailChartViewModel> Emails { get; set; }

        public ListEmailsFromChartViewModel(IEnumerable<Email> emails)
        {
            this.Emails = new List<EmailChartViewModel>();
            foreach (var email in emails)
            {
                this.Emails.Add(new EmailChartViewModel(email));
            }
        }
    }
}
