using E_MailApplicationsManager.Models;

namespace E_MailApplicationsManager.Web.Models.Emails
{
    public class EmailBodyViewModel
    {
        public EmailBodyViewModel(string gmailId, string body)
        {
            this.GmailId = gmailId;
            this.Body = body;
        }

        public string GmailId { get; set; }
        public string Body { get; set; }
    }
}
