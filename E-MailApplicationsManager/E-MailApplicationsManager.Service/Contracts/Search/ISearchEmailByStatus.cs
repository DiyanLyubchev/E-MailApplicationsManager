using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface ISearchEmailByStatus
    {
        Task<int> GetAllNotReviewedEmails();

        Task<IEnumerable<Email>> SearchEamilByStatusIdAsync(EmailStatusIdDto status);

        Task<IEnumerable<LoanApplicant>> GetAllFinishLoanApplicantAsync();

        Task<IEnumerable<LoanApplicant>> ListEmailsWithStatusOpenAsync(LoanApplicantDto loanApplicantDto);
    }
}
