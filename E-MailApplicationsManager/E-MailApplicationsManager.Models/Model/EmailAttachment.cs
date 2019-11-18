using E_MailApplicationsManager.Models.BaseEntitys;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_MailApplicationsManager.Models.Model
{
    public class EmailAttachment : BaseIdEntity
    {
        public int? EmailId { get; set; }

        public Email Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string GmailId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string FileName { get; set; }

        public double? SizeInKB { get; set; }

    }
}

