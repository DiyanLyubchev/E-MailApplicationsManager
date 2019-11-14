using E_MailApplicationsManager.Models.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Web.Models.Loan
{
    public class StatusCloseEmailViewModel
    {
        public StatusCloseEmailViewModel(LoanApplicant loanApplicant)
        {
            this.Id = loanApplicant.Id;
            this.ClienName = loanApplicant.Name;
            this.PhoneNumber = loanApplicant.PhoneNumber;
            this.GmailId = loanApplicant.GmailId;
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]   
        public string ClienName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string GmailId { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        public DateTime? TerminalDate { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
