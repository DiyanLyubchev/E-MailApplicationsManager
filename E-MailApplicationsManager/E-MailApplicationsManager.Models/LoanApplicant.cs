using E_MailApplicationsManager.Models.BaseEntitys;

namespace E_MailApplicationsManager.Models
{
    public class LoanApplicant : BaseIdEntity
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string EGN { get; set; }

        public Email Email { get; set; }

        public bool IsApproved { get; set; } 

    }
}
