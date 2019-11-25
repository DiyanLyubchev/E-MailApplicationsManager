using E_MailApplicationsManager.Service.Dto;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface IEmailSetStatusService
    {
        Task<bool> ChangeStatusAsync(EmailStatusIdDto emailStatusId);

        Task<bool> SetEmailStatusInvalidApplicationAsync(StatusInvalidApplicationDto dto);

         Task<string> ChangeEmailStatusFromClose(EmailDto emailDto);
    }
}
