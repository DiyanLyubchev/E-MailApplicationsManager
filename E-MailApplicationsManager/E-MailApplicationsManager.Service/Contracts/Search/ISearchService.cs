using System.Collections.Generic;
using System.Threading.Tasks;
using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Dto;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface ISearchService : ISearchLoanApplicant , ISearchEmailByStatus
    {
        Task<Email> FindEmailAsync(int id);

        Task<IEnumerable<Email>> GetAllEmailsAsync();

        Task<IEnumerable<Email>> GetAllUserWorkingOnEmailAsync(EmailContentDto userIdDto);

        Task<IEnumerable<Email>> GetAllEmailsForManagerAsync();

        Task<IEnumerable<EmailStatus>> GetEmailsForChart();
       
    }
}