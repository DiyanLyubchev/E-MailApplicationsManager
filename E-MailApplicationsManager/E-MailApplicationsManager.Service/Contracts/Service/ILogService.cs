using System.Threading.Tasks;
using E_MailApplicationsManager.Models.Model;

namespace E_MailApplicationsManager.Service.Service
{
    public interface ILogService
    {
        Task<bool> SaveLastLoginUser(User user);
    }
}