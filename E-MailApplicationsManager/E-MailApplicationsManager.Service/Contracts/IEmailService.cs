using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Service.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface IEmailService
    {
        Task AddMailAsync(EmailDto emailDto);

        Task<Email> AddBodyToCurrentEmailAsync(EmailContentDto emailDto);

        Task AddAttachmentAsync(EmailAttachmentDTO attachmentDTO);

        string Base64Decode(string base64EncodedData);

        string Base64Encode(string plainText);
     
    }
}