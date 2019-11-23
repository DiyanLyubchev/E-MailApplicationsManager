using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Dto;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface IEmailService : IEmailSetStatusService , IEmailBodyHolder
    {
        Task<Email> AddMailAsync(EmailDto emailDto);

        Task AddAttachmentAsync(EmailAttachmentDTO attachmentDTO);
    }
}