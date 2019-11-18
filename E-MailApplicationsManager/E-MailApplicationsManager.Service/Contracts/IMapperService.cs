using System.Threading.Tasks;
using E_MailApplicationsManager.Models.Model;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface IMapperService
    {
        Task<Email> MappGmailBodyIntoEmailBodyAsync(string id, string codedBody, string userId);
        Task MappGmailDataIntoEmailDataAsync(string gmailId, string subjectOfEmail,
            string senderOfEmail, string dateOfEmail);

       Task MappGmailAttachmentIntoEmailAttachmentAsync(string gmailId, string fileName, double fileSize);
    }
}