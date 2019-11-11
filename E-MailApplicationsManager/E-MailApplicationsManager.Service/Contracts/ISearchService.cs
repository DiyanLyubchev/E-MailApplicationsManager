using System.Collections.Generic;
using System.Threading.Tasks;
using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Service.Dto;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface ISearchService
    {
        Task<Email> FindEmailAsync(int id);

        Task<IEnumerable<Email>> SearchEamilByStatusId(EmailStatusIdDto status);

        Task<IEnumerable<Email>> GetAllEmailsAsync();

        Task<IEnumerable<Email>> GetAllUserWorkingOnEmail(EmailContentDto userIdDto);

        //Task<IEnumerable<Email>> ListEmailsWithStatusOpenAsync(LoanApplicantDto loanApplicantDto);

        Task<IEnumerable<Email>> GetAllEmailsForManagerAsync();
    }
}