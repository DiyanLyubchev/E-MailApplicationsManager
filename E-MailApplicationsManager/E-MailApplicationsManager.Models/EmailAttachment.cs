using E_MailApplicationsManager.Models.BaseEntitys;

namespace E_MailApplicationsManager.Models
{
    public class EmailAttachment : BaseIdEntity
    {
        public int EmailId { get; set; }

        public Email Email { get; set; }

        public string FileName { get; set; }

        public double? SizeInMb { get; set; }
    }
}
