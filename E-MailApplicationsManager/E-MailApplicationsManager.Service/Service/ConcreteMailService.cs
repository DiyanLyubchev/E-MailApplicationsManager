using E_MailApplicationsManager.Models.Model;
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
        public ConcreteMailService(IEncodeDecodeService encodeDecodeService, IMapperService mapper)
        {
            this.encodeDecodeService = encodeDecodeService;
            this.mapper = mapper;
        }

        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/gmail-dotnet-quickstart.json
        static string[] Scopes = { GmailService.Scope.GmailModify };
        static string ApplicationName = "Gmail API .NET Quickstart";

        public async Task QuickStartAsync()
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

            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            UsersResource.LabelsResource.ListRequest request = service.Users.Labels.List("me");

            var allListMails = service.Users.Messages.List("bobidiyantelerik@gmail.com");
            allListMails.LabelIds = "UNREAD";    // take data only from inbox
            allListMails.IncludeSpamTrash = false;  // not take data from spam

            var emails = await allListMails.ExecuteAsync();

            if (emails.Messages == null)
            {
                return;
            }

            string subjectOfEmail = null;
            string dateOfEmail = null;
            string senderOfEmail = null;
            string gmailId = null;

            foreach (var currentEmail in emails.Messages)
            {
                var requestMail = service.Users.Messages.Get("bobidiyantelerik@gmail.com", currentEmail.Id);

                var responseMail = await requestMail.ExecuteAsync();

                var mailAttach = responseMail.Payload.Parts[0];


                if (mailAttach.MimeType == "text/plain")
                {
                    gmailId = responseMail.Id;

                    subjectOfEmail = responseMail.Payload.Headers
                        .FirstOrDefault(subject => subject.Name == "Subject").Value;

                    dateOfEmail = responseMail.Payload.Headers
                        .FirstOrDefault(date => date.Name == "Date").Value;

                    senderOfEmail = responseMail.Payload.Headers
                        .FirstOrDefault(sender => sender.Name == "From").Value;

                   await this.mapper.MappGmailDataIntoEmailData(gmailId, subjectOfEmail, senderOfEmail, dateOfEmail);

                    var changeEmailStatus = new ModifyMessageRequest { RemoveLabelIds = new List<string> { "UNREAD" } };
                    await service.Users.Messages.Modify(changeEmailStatus, "bobidiyantelerik@gmail.com", gmailId).ExecuteAsync();
                }
                else
                {
                    gmailId = responseMail.Id;

                    subjectOfEmail = responseMail.Payload.Headers
                        .FirstOrDefault(s => s.Name == "Subject").Value;

                    dateOfEmail = responseMail.Payload.Headers
                        .FirstOrDefault(s => s.Name == "Date").Value;

                    senderOfEmail = responseMail.Payload.Headers
                        .FirstOrDefault(s => s.Name == "From").Value;

                    var attachmentLists = responseMail.Payload.Parts.Skip(1).ToList();

                    if (attachmentLists.Any())
                    {

                        foreach (var attachment in attachmentLists)
                        {
                            string fileName = attachment.Filename;
                            double fileSize = double.Parse(attachment.Body.Size.ToString());
                            fileSize /= 1024;

                            await this.mapper.MappGmailAttachmentIntoEmailAttachment(gmailId, fileName, fileSize);
                        }

                        await this.mapper.MappGmailDataIntoEmailData(gmailId, subjectOfEmail, senderOfEmail, dateOfEmail);

                        var changeEmailStatus = new ModifyMessageRequest { RemoveLabelIds = new List<string> { "UNREAD" } };
                        await service.Users.Messages.Modify(changeEmailStatus, "bobidiyantelerik@gmail.com", gmailId).ExecuteAsync();
                    }
                }
            }
        }

        public async Task<Email> GetEmailByIdAsync(string id, string userId)
        {
            UserCredential credential;

            using (var stream =
                new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true));
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

            var emails = await allListMails.ExecuteAsync();

            var foundEmail = emails.Messages.Where(m => m.Id == id).FirstOrDefault();
            var currentEmail = await (service.Users.Messages.Get("bobidiyantelerik@gmail.com", foundEmail.Id)).ExecuteAsync();

            var email = new Email();
            var mailAttach = currentEmail.Payload.Parts[0];

            if (mailAttach.MimeType == "text/plain")
            {
                string body = currentEmail.Payload.Parts[1].Body.Data;

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
    }
}