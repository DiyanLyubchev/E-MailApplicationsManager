using E_MailApplicationsManager.Models.BaseEntitys;
using E_MailApplicationsManager.Models.Common;

namespace E_MailApplicationsManager.Models
{
    public class ReceivedEmail : BaseIdEntity
    {
        public EmailStatusesType Status { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int EmailId { get; set; }
        public Email Email { get; set; }

    }
}
