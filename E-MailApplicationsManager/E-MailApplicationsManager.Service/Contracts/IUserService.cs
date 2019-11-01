using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Service.Dto;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service
{
    public interface IUserService
    {
        Task RegisterAccountAsync(RegisterAccountDto registerAccountDto);

        Task<User> GetUserAsync(string userId);
    }
}