using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service
{
    public class EmailService : IEmailService
    {
        private readonly E_MailApplicationsManagerContext context;

        public EmailService(E_MailApplicationsManagerContext context)
        {
            this.context = context;
        }

        public  void AddMail(EmailDto emailDto)
        {
            if (emailDto.Body == null || emailDto.DateReceived == null ||
                emailDto.Sender == null || emailDto.Subject == null)
            {
                throw new Exception("");
            }

            var email = new Email
            {
                Sender = emailDto.Sender,
                DateReceived = emailDto.DateReceived,
                Subject = emailDto.Subject,
                Body = emailDto.Body
            };

            this.context.Emails.Add(email);
            this.context.SaveChanges();

        }
    }
}
