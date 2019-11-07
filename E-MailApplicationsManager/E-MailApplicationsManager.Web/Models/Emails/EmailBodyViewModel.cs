using E_MailApplicationsManager.Models;

namespace E_MailApplicationsManager.Web.Models.Emails
{
    public class EmailBodyViewModel
    {
        public EmailBodyViewModel(string body)
        {
            this.Body = body;
        }

        public string Body { get; set; }
    }
}
