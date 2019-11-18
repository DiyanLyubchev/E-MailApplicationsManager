using System.Threading.Tasks;
using E_MailApplicationsManager.Models.Model;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface IMapperService
    {
        Task<Email> MappGmailBodyIntoEmailBody(string id, string codedBody, string userId);
        Task MappGmailDataIntoEmailData(string gmailId, string subjectOfEmail,
            string senderOfEmail, string dateOfEmail);

       Task MappGmailAttachmentIntoEmailAttachment(string gmailId, string fileName, double fileSize);
    }
}