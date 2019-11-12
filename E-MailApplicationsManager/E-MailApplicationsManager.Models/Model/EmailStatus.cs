using E_MailApplicationsManager.Models.BaseEntitys;
using System.Collections.Generic;

namespace E_MailApplicationsManager.Models.Model
{
    public class EmailStatus : BaseIdEntity
    {
        public string Status { get; set; }

        public ICollection<Email> Emails { get; set; } 
        
    }
}
