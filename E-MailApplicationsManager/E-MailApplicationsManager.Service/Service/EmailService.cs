using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.Dto;
using System;
using System.Linq;

namespace E_MailApplicationsManager.Service.Service
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

            var gmaiId = this.context.Emails
                .FirstOrDefault(id => id.GmailId == emailDto.GmailId);

            if (gmaiId == null)
            {
                var email = new Email
                {
                    GmailId = emailDto.GmailId,
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
}
