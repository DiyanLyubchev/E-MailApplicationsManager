using E_MailApplicationsManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Web.Models.Email
{
    public class EmailViewModel
    {
        public EmailViewModel(ReceivedEmail receivedEmail)
        {
            this.Id = receivedEmail.Id;
            this.Subject = receivedEmail.Subject;
            this.Sender = receivedEmail.Sender;
            this.DateReceived = receivedEmail.DateReceived;
        }

        public EmailViewModel()
        {

        }

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Subject { get; set; }
        public string Sender { get; set; }

        public string DateReceived { get; set; }
    }
}
