﻿using E_MailApplicationsManager.Models.Common;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Service
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> logger;
        private readonly E_MailApplicationsManagerContext context;
        private readonly IEncodeDecodeService encodeDecodeService;



        public EmailService(E_MailApplicationsManagerContext context, ILogger<EmailService> logger,
            IEncodeDecodeService encodeDecodeService)
        {
            this.context = context;
            this.logger = logger;
            this.encodeDecodeService = encodeDecodeService;
        }

        public async Task<Email> AddMailAsync(EmailDto emailDto)
        {
            if (emailDto.DateReceived == null ||
                emailDto.Sender == null || emailDto.Subject == null)
            {
                throw new EmailExeption("Email does not exist!");
            }

            if (emailDto.GmailId.Length < 5 || emailDto.GmailId.Length > 100)
            {
                throw new EmailExeption("The length of GmailId is not correct!");
            }

            if (emailDto.Subject.Length < 3 || emailDto.Subject.Length > 100)
            {
                throw new EmailExeption("The length of Subject is not correct!");
            }

            if (emailDto.Sender.Length < 5 || emailDto.Sender.Length > 50)
            {
                throw new EmailExeption("The length of Sender is not correct!");
            }

            var gmailId = await this.context.Emails
                .FirstOrDefaultAsync(id => id.GmailId == emailDto.GmailId);

            if (gmailId == null)
            {
                var email = new Email
                {
                    GmailId = emailDto.GmailId,
                    Sender = emailDto.Sender,
                    InitialRegistrationInData = DateTime.Now,
                    DateReceived = emailDto.DateReceived,
                    Subject = emailDto.Subject,
                };

                await this.context.Emails.AddAsync(email);
                await this.context.SaveChangesAsync();

                return email;
            }
            return null;
        }

        public async Task<bool> ChangeStatusAsync(EmailStatusIdDto emailStatusId)
        {
            if (emailStatusId.StatusId == null || emailStatusId.GmailId == null)
            {
                throw new EmailExeption("Status id or Gmail id cannot be null");
            }

            int status = int.Parse(emailStatusId.StatusId);

            var email = await this.context.Emails
                .Where(gmailId => gmailId.GmailId == emailStatusId.GmailId)
                .SingleOrDefaultAsync();

            var currentUser = await this.context.Users
               .Where(id => id.Id == emailStatusId.UserId)
               .SingleOrDefaultAsync();

            if (status == 1)
            {
                email.User = currentUser;
                email.UserId = emailStatusId.UserId;
                email.EmailStatusId = status;
                email.SetCurrentStatus = DateTime.Now;
                email.IsSeen = false;
                email.Body = null;

                await this.context.SaveChangesAsync();

                return true;
            }
            else if (status == 2)
            {
                email.EmailStatusId = status;
                email.SetCurrentStatus = DateTime.Now;
                email.IsSeen = false;
                email.Body = null;
                await this.context.SaveChangesAsync();

                return true;
            }

            logger.LogInformation($"Status successfully updated by {currentUser.UserName}.");
            return true;
        }

        public async Task AddAttachmentAsync(EmailAttachmentDTO attachmentDTO)
        {
            if (attachmentDTO.FileName.Length < 5 || attachmentDTO.FileName.Length > 100)
            {
                throw new EmailExeption("The attachment's name lenght is not correct!");
            }

            if (attachmentDTO.GmailId.Length < 5 || attachmentDTO.GmailId.Length > 100)
            {
                throw new EmailExeption("The Gmail's id lenght is not correct!");
            }

            var gmaiId = await this.context.Emails
               .FirstOrDefaultAsync(id => id.GmailId == attachmentDTO.GmailId);

            if (gmaiId == null)
            {
                var attachment = new EmailAttachment
                {
                    FileName = attachmentDTO.FileName,
                    SizeInKB = attachmentDTO.SizeInKB,
                    GmailId = attachmentDTO.GmailId
                };

                await this.context.EmailAttachments.AddAsync(attachment);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task<Email> AddBodyToCurrentEmailAsync(EmailContentDto emailDto)
        {
            var email = await this.context.Emails
                .Include(u => u.User)
                .Where(gMail => gMail.GmailId == emailDto.GmailId)
                .SingleOrDefaultAsync();

            var currentUser = await this.context.Users
                .Where(id => id.Id == emailDto.UserId)
                .SingleOrDefaultAsync();

            if (emailDto.Body == null)
            {
                throw new EmailExeption($"Email with the following id {emailDto.GmailId} does not exist");
            }

            if (emailDto.Body.Length > 1000)
            {
                throw new EmailExeption($"Body of email is to long!");
            }

            if (email.Body != null)
            {
                throw new EmailExeption($"Email with the following id {emailDto.GmailId} contains body");
            }

            var encodeBody = this.encodeDecodeService.Base64Decode(emailDto.Body);
         
            var encriptBody = this.encodeDecodeService.Encrypt(encodeBody);

            if (email.Body == null)
            {
                email.Body = encriptBody;
                email.User = currentUser;
                email.UserId = emailDto.UserId;
                email.IsSeen = true;
                await this.context.SaveChangesAsync();
            }
            return email;
        }

        public async Task<Email> CheckEmailBodyAsync(EmailContentDto emailDto)
        {
            var email = await this.context.Emails
                .Where(gMail => gMail.GmailId == emailDto.GmailId)
                .SingleOrDefaultAsync();

            if (email.Body == null)
            {
                throw new EmailExeption("Email body is empty");
            }

            var currentUser = await this.context.Users
                .Where(userId => userId.Id == emailDto.UserId)
                .Select(user => user.UserName)
                .SingleOrDefaultAsync();

            email.EmailStatusId = (int)EmailStatusesType.New;
            email.SetCurrentStatus = DateTime.Now;
            await this.context.SaveChangesAsync();

            logger.LogInformation($"Changed email status to New by {currentUser}");
            return email;
        }

        public async Task<Email> TakeBodyAsync(EmailContentDto emailDto)
        {
            var email = await this.context.Emails
                .Where(gMail => gMail.GmailId == emailDto.GmailId)
                .SingleOrDefaultAsync();

            return email;
        }

        public async Task<bool> SetEmailStatusInvalidApplicationAsync(StatusInvalidApplicationDto dto)
        {
            if (dto.GmailId == null)
            {
                throw new EmailExeption($"Email with the following id {dto.GmailId} does not exist!");
            }

            var email = await this.context.Emails
                .Include(u => u.User)
                .Where(emailId => emailId.GmailId == dto.GmailId)
                .FirstOrDefaultAsync();

            var currentUser = await this.context.Users
               .Where(id => id.Id == dto.UserId)
               .SingleOrDefaultAsync();

            email.User = currentUser;
            email.UserId = dto.UserId;
            email.EmailStatusId = (int)EmailStatusesType.InvalidApplication;
            await this.context.SaveChangesAsync();

            logger.LogInformation($"Changed email status to Invalid Application by {currentUser.UserName}");
            return true;
        }


    }
}
