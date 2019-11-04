using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Service
{
    public class EmailService : IEmailService
    {
        private readonly E_MailApplicationsManagerContext context;


        public EmailService(E_MailApplicationsManagerContext context)
        {
            this.context = context;
        }

        public void AddMail(Dto.ReceivedEmailDto emailDto)
        {
            if (emailDto.DateReceived == null ||
                emailDto.Sender == null || emailDto.Subject == null)
            {
                throw new EmailExeption(""); // TODO: IF data is n ot full set status
            }

            var gmaiId = this.context.ReceivedEmails
                .FirstOrDefault(id => id.GmailId == emailDto.GmailId);

            if (gmaiId == null)
            {
                var email = new ReceivedEmail
                {
                    GmailId = emailDto.GmailId,
                    Sender = emailDto.Sender,
                    DateReceived = emailDto.DateReceived,
                    Subject = emailDto.Subject,
                    FileName = emailDto.FileName,
                    SizeInMb = emailDto.SizeInMb
                };

                this.context.ReceivedEmails.Add(email);
                this.context.SaveChanges();
            }
        }
    }
}
