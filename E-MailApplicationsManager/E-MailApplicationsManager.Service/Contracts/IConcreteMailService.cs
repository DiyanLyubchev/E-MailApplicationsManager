using E_MailApplicationsManager.Models.Model;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface IConcreteMailService
    {
        Task QuickStartAsync();

        Task<Email> GetEmailByIdAsync(string id, string userId);
    }
}