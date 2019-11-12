using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Dto;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface IEmailService
    {
        Task AddMailAsync(EmailDto emailDto);

        Task<Email> AddBodyToCurrentEmailAsync(EmailContentDto emailDto);

        Task AddAttachmentAsync(EmailAttachmentDTO attachmentDTO);

        Task<Email> TakeBodyAsync(EmailContentDto emailDto);

        Task<bool> SetEmailStatusInvalidApplicationAsync(StatusInvalidApplicationDto dto);

        Task<Email> CheckEmailBodyAsync(EmailContentDto emailDto);

        Task<bool> ChangeStatusAsync(EmailStatusIdDto emailStatusId);
    }
}