using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Service.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface IEmailService
    {
        void AddMail(EmailDto emailDto);

        void AddBodyToCurrentEmail(EmailDto emailDto);

        Task<IEnumerable<Email>> GetAllEmailAsync(string name);

        void AddAttachment(AttachmentDTO attachmentDTO);
    }
}