﻿using E_MailApplicationsManager.Models;
using System.ComponentModel.DataAnnotations;

namespace E_MailApplicationsManager.Web.Models.Emails
{
    public class EmailViewModel
    {

        public EmailViewModel(Email email)
        {
            this.Id = email.Id;
            this.GmailId = email.GmailId;
            this.Sender = email.Sender;
            this.Subject = email.Subject;
            this.DateReceived = email.DateReceived;
            this.IsSeen = email.IsSeen;
        }

        public EmailViewModel()
        {

        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        public string GmailId { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Sender { get; set; }

        [Required]
        public string DateReceived { get; set; }

        [ScaffoldColumn(false)]
        public bool IsSeen { get; set; }
    }
}
