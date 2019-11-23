using E_MailApplicationsManager.Models.Common;
using E_MailApplicationsManager.Models.Model;

namespace E_MailApplicationsManager.Web.Models.Emails
{
    public class EmailChartViewModel
    {
        public EmailChartViewModel(Email email)
        {
            this.Id = email.Id;
            this.StatusId = email.EmailStatusId;
            this.EmailStatus = ((EmailStatusesType)email.EmailStatusId).ToString();
        }

        public int Id { get; set; }

        public string EmailStatus { get; set; }

        public int StatusId { get; set; }

    }
}
