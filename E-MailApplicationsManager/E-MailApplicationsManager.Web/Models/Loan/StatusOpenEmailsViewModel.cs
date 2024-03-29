﻿using E_MailApplicationsManager.Models.Model;
using System.ComponentModel.DataAnnotations;

namespace E_MailApplicationsManager.Web.Models.Emails
{
    public class StatusOpenEmailsViewModel
    {
        public StatusOpenEmailsViewModel()
        {

        }

        public StatusOpenEmailsViewModel(LoanApplicant loanApplicant)
        {
            this.Id = loanApplicant.Id;
            this.GmailId = loanApplicant.GmailId;
            this.Name = loanApplicant.Name;
            this.EGN = loanApplicant.EGN;
            this.PhoneNumber = loanApplicant.PhoneNumber;
        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public string GmailId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string EGN { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
    }
}
