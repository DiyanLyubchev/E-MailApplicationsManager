using E_MailApplicationsManager.Models.Model;
using System.Collections.Generic;

namespace E_MailApplicationsManager.Web.Models.Loan
{
    public class ListStatusCloseEmailViewModel
    {
        public List<StatusCloseEmailViewModel> Emails { get; set; }

        public ListStatusCloseEmailViewModel(IEnumerable<LoanApplicant> closeStatusEmails)
        {
            this.Emails = new List<StatusCloseEmailViewModel>();
            foreach (var closeStatusEmail in closeStatusEmails)
            {
                this.Emails.Add(new StatusCloseEmailViewModel(closeStatusEmail));
            }
        }
    }
}
