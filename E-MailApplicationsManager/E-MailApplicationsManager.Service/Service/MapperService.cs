using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.Dto;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Service
{
    public class MapperService : IMapperService
    {

        private readonly IEmailService emailService;

        public MapperService(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public async Task<Email> MappGmailBodyIntoEmailBody(string id, string codedBody, string userId)
        {
            var emailDto = new EmailContentDto
            {
                GmailId = id,
                Body = codedBody,
                UserId = userId

            };

            return await this.emailService.AddBodyToCurrentEmailAsync(emailDto);
        }

        public async Task MappGmailDataIntoEmailData(string gmailId, string subjectOfEmail,
            string senderOfEmail, string dateOfEmail)
        {
            var emailDto = new EmailDto
            {
                GmailId = gmailId,
                Subject = subjectOfEmail,
                Sender = senderOfEmail,
                DateReceived = dateOfEmail,
            };

            await this.emailService.AddMailAsync(emailDto);
        }

        public async Task MappGmailAttachmentIntoEmailAttachment(string gmailId,string fileName,double fileSize)
        {
            var attachmentDto = new EmailAttachmentDTO
            {
                GmailId = gmailId,
                FileName = fileName,
                SizeInKB = fileSize
            };

            await this.emailService.AddAttachmentAsync(attachmentDto);
        }
    }
}
