using System.ComponentModel.DataAnnotations;

namespace E_MailApplicationsManager.Models.Common
{
    public enum EmailStatusesType
    {
        [Display(Name = "Not Reviewed")]
        NotReviewed = 1,

        [Display(Name = "Invalid Application")]
        InvalidApplication = 2,

        [Display(Name = "New")]
        New = 3,

        [Display(Name = "Open")]
        Open = 4,

        [Display(Name = "Closed")]
        Closed = 5
    }
}
