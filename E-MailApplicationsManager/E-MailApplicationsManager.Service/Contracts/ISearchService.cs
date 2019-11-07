using System.Collections.Generic;
using System.Threading.Tasks;
using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Service.Dto;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface ISearchService
    {
        Task<Email> FindEmailAsync(int id);
        Task<IEnumerable<Email>> GetAllEmailAsync(string name);
        Task<IEnumerable<Email>> GetAllEmailsAsync();

        Task<IEnumerable<Email>> GetAllUserWorkingOnEmail(EmailContentDto userIdDto);
    }
}