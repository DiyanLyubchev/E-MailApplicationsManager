﻿using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Contracts;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Service
{
    public class ConcreteMailService : IConcreteMailService
    {
        private readonly IEncodeDecodeService encodeDecodeService;
        private readonly IMapperService mapper;
        private const int kbDivider = 1024;
        public ConcreteMailService(IEncodeDecodeService encodeDecodeService, IMapperService mapper)
        {
            this.encodeDecodeService = encodeDecodeService;
            this.mapper = mapper;
        }

        static string[] Scopes = { GmailService.Scope.GmailModify };
        static string ApplicationName = "Gmail API .NET Quickstart";

        public async Task QuickStartAsync()
        {
            var emails = await ListMessages("UNREAD");
            var service = await Service();

            if (emails.Messages == null)
            {
                return;
            }

            foreach (var currentEmail in emails.Messages)
            {
                var requestMail = service.Users.Messages.Get("bobidiyantelerik@gmail.com", currentEmail.Id);

                var responseMail = await requestMail.ExecuteAsync();

                var mailAttach = responseMail.Payload.Parts[0];


                if (mailAttach.MimeType == "text/plain")
                {
                    await TakeDataFromGmail(responseMail);
                }
                else
                {
                    await TakeDataWithAttachment(responseMail);
                }
            }
        }

        public async Task<Email> GetEmailByIdAsync(string id, string userId)
        {

            var emails = await ListMessages("INBOX");
            var service = await Service();

            var foundEmail = emails.Messages.Where(m => m.Id == id).FirstOrDefault();
            var currentEmail = await (service.Users.Messages.Get("bobidiyantelerik@gmail.com", foundEmail.Id)).ExecuteAsync();

            var email = new Email();
            var mailAttach = currentEmail.Payload.Parts[0];

            if (mailAttach.MimeType == "text/plain")
            {
                string body = currentEmail.Payload.Parts[0].Body.Data;

                var codedBody = this.encodeDecodeService.ReplaceSign(body);

                email = await this.mapper.MappGmailBodyIntoEmailBody(id, codedBody, userId);
            }
            else
            {
                string body = currentEmail.Payload.Parts[0].Parts[0].Body.Data;

                var codedBody = this.encodeDecodeService.ReplaceSign(body);

                email = await this.mapper.MappGmailBodyIntoEmailBody(id, codedBody, userId);
            }

            return email;

        }

        private async Task<UserCredential> Credential()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true));
            }

            return credential;
        }

        private async Task<ListMessagesResponse> ListMessages(string label)
        {

            var service = await Service();
            // Define parameters of request.
            UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");

            var allListMails = service.Users.Messages.List("bobidiyantelerik@gmail.com");
            allListMails.LabelIds = label;    // take data only from inbox
            allListMails.IncludeSpamTrash = false;  // not take data from spam

            return await allListMails.ExecuteAsync();
        }

        private async Task<GmailService> Service()
        {
            var credential = await Credential();

            // Create Gmail API service.
            return new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

        }
        private async Task TakeDataFromGmail(Message responseMail)
        {
            var service = await Service();
            string gmailId = responseMail.Id;

            string subjectOfEmail = responseMail.Payload.Headers
                 .FirstOrDefault(subject => subject.Name == "Subject").Value;

            string dateOfEmail = responseMail.Payload.Headers
                 .FirstOrDefault(date => date.Name == "Date").Value;

            string senderOfEmail = responseMail.Payload.Headers
                  .FirstOrDefault(sender => sender.Name == "From").Value;

            await this.mapper.MappGmailDataIntoEmailData(gmailId, subjectOfEmail, senderOfEmail, dateOfEmail);

            var changeEmailStatus = new ModifyMessageRequest { RemoveLabelIds = new List<string> { "UNREAD" } };
            await service.Users.Messages.Modify(changeEmailStatus, "bobidiyantelerik@gmail.com", gmailId).ExecuteAsync();
        }

        private async Task TakeDataWithAttachment(Message responseMail)
        {
            var service = await Service();

            string gmailId = responseMail.Id;

            string subjectOfEmail = responseMail.Payload.Headers
                  .FirstOrDefault(s => s.Name == "Subject").Value;

            string dateOfEmail = responseMail.Payload.Headers
                 .FirstOrDefault(s => s.Name == "Date").Value;

            string senderOfEmail = responseMail.Payload.Headers
                  .FirstOrDefault(s => s.Name == "From").Value;

            var attachmentLists = responseMail.Payload.Parts.Skip(1).ToList();

            if (attachmentLists.Any())
            {

                foreach (var attachment in attachmentLists)
                {
                    string fileName = attachment.Filename;
                    double fileSize = double.Parse(attachment.Body.Size.ToString());
                    fileSize /= kbDivider;

                    await this.mapper.MappGmailAttachmentIntoEmailAttachment(gmailId, fileName, fileSize);
                }

                await this.mapper.MappGmailDataIntoEmailData(gmailId, subjectOfEmail, senderOfEmail, dateOfEmail);

                var changeEmailStatus = new ModifyMessageRequest { RemoveLabelIds = new List<string> { "UNREAD" } };
                await service.Users.Messages.Modify(changeEmailStatus, "bobidiyantelerik@gmail.com", gmailId).ExecuteAsync();
            }
        }
    }
}