﻿using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.Dto;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace E_MailApplicationsManager.Service.Service
{
    public class ConcreteMailService : IConcreteMailService
    {
        private readonly IEmailService emailService;

        public ConcreteMailService(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/gmail-dotnet-quickstart.json
        static string[] Scopes = { GmailService.Scope.GmailReadonly };
        static string ApplicationName = "Gmail API .NET Quickstart";

        public void QuickStart()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");

            var allListMails = service.Users.Messages.List("bobidiyantelerik@gmail.com");
            allListMails.LabelIds = "INBOX";    // take data only from inbox
            allListMails.IncludeSpamTrash = false;  // not take data from spam

            var emails = allListMails.ExecuteAsync().Result;

            string subject = null;
            string date = null;
            string from = null;
            string id = null;

            foreach (var currentEmail in emails.Messages)
            {
                var requestMail = service.Users.Messages.Get("bobidiyantelerik@gmail.com", currentEmail.Id);

                var responseMail = requestMail.ExecuteAsync().Result;

                if (responseMail != null)
                {
                    id = responseMail.Id;

                    subject = responseMail.Payload.Headers
                        .FirstOrDefault(s => s.Name == "Subject").Value;

                    date = responseMail.Payload.Headers
                        .FirstOrDefault(s => s.Name == "Date").Value;

                    from = responseMail.Payload.Headers
                        .FirstOrDefault(s => s.Name == "From").Value;
                }

                var emailDto = new ReceivedEmailDto
                {
                    GmailId = id,
                    Subject = subject,
                    Sender = from,
                    DateReceived = date,
                };

                this.emailService.AddMail(emailDto);
            }
        }

        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public void GetEmailById(string id)
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");

            var allListMails = service.Users.Messages.List("bobidiyantelerik@gmail.com");
            allListMails.LabelIds = "INBOX";    
            allListMails.IncludeSpamTrash = false; 

            var emails = allListMails.ExecuteAsync().Result;
            string subject = null;
            string date = null;
            string from = null;
            string body = null;
            var convertBody = new StringBuilder();

            foreach (var currentEmail in emails.Messages)
            {
                var requestMail = service.Users.Messages.Get("bobidiyantelerik@gmail.com", currentEmail.Id);

                var responseMail = requestMail.ExecuteAsync().Result;

                if (responseMail != null && responseMail.Id == id)
                {
                    subject = responseMail.Payload.Headers
                        .FirstOrDefault(s => s.Name == "Subject").Value;

                    date = responseMail.Payload.Headers
                        .FirstOrDefault(s => s.Name == "Date").Value;

                    from = responseMail.Payload.Headers
                        .FirstOrDefault(s => s.Name == "From").Value;

                    body = responseMail.Payload.Parts[0].Body.Data;

                    var result = Base64Decode(body);

                    convertBody.Append(result);

                    // responseMail.Payload.Parts[0].Parts[0].Body.Data;  // with attachment
                }
            }
        }
    }
}