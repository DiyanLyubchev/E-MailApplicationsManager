using System.Collections.Generic;
using System.Threading.Tasks;
using E_MailApplicationsManager.Models;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface ISearchService
    {
        Task<Email> FindEmailAsync(int id);
        Task<IEnumerable<Email>> GetAllEmailAsync(string name);
        Task<IEnumerable<Email>> GetAllEmailsAsync();
    }
}