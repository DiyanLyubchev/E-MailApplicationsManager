﻿using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Service
{
    public class EmailService : IEmailService
    {
        private readonly E_MailApplicationsManagerContext context;

        public DateTime? DtaeTime { get; private set; }

        public EmailService(E_MailApplicationsManagerContext context)
        {
            this.context = context;
        }

        public async Task AddMailAsync(EmailDto emailDto)
        {
            if (emailDto.DateReceived == null ||
                emailDto.Sender == null || emailDto.Subject == null)
            {
                throw new EmailExeption(""); // TODO: IF data is n ot full set status
            }

            var gmaiId =await this.context.Emails
                .FirstOrDefaultAsync(id => id.GmailId == emailDto.GmailId);

            if (gmaiId == null && gmaiId.IsSeen == false)
            {
                var email = new Email
                {
                    GmailId = emailDto.GmailId,
                    Sender = emailDto.Sender,
                    DateReceived = emailDto.DateReceived,
                    Subject = emailDto.Subject,
                };

               await this.context.Emails.AddAsync(email);
               await this.context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Email>> GetAllEmailAsync(string name)
        {
            var emailList = await this.context.Emails
               .Where(mail => mail.Sender.Contains(name))
               .Select(email => email)
               .ToListAsync();

            return emailList;
        }

        public void AddAttachment(AttachmentDTO attachmentDTO)
        {

            var gmaiId = this.context.Emails
               .FirstOrDefault(id => id.GmailId == attachmentDTO.GmailId);

            if (gmaiId == null)
            {
                var attachment = new EmailAttachment
                {
                    FileName = attachmentDTO.FileName,
                    SizeInKB = attachmentDTO.SizeInKB,
                    GmailId = attachmentDTO.GmailId
                };

                this.context.EmailAttachments.Add(attachment);
                this.context.SaveChanges();
            }
        }

        public async Task<Email> AddBodyToCurrentEmailAsync(EmailContentDto emailDto)
        {
            var email = await this.context.Emails
                .Where(gMail => gMail.GmailId == emailDto.GmailId)
                .FirstOrDefaultAsync();

            if (emailDto.Body == null)
            {
                throw new EmailExeption($"Email with the following id {emailDto.GmailId} does not exist");
            }

            if (email.Body.Any())
            {
                throw new EmailExeption($"Email with the following id {emailDto.GmailId} contains body");
            }

            if (email.Body == null)
            {
                email.Body = emailDto.Body;
                email.InitialRegistrationInData = DateTime.Now;
                email.IsSeen = true;
                await this.context.SaveChangesAsync();
            }

            return email;
        }

        public  string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public  string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
