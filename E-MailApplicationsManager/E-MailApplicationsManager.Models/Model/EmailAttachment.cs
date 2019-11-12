using E_MailApplicationsManager.Models.BaseEntitys;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_MailApplicationsManager.Models.Model
{
    public class EmailAttachment : BaseIdEntity
    {
        public int? EmailId { get; set; }

        public Email Email { get; set; }

        public string GmailId { get; set; }

        public string FileName { get; set; }

        public double? SizeInKB { get; set; }

    }
}

