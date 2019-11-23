using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Dto;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface IUserService
    {
        Task RegisterAccountAsync(RegisterAccountDto registerAccountDto);

        Task<User> GetUserAsync(string userId);

        Task<bool> ChangePasswordAsync(ChangePasswordDto changePasswordDto);

    }
}