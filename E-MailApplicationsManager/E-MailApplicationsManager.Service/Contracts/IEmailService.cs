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

        Task<Email> TakeBody(EmailContentDto emailDto);

        Task<bool> SetEmailStatusInvalidApplication(StatusInvalidApplicationDto dto);

        Task<Email> CheckEmailBody(EmailContentDto emailDto);

        Task<bool> ChangeStatusAsync(EmailStatusIdDto emailStatusId);
    }
}