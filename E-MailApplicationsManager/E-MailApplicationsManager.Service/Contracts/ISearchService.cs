using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Dto;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface ISearchService
    {
        Task<Email> FindEmailAsync(int id);

        Task<IEnumerable<Email>> SearchEamilByStatusIdAsync(EmailStatusIdDto status);

        Task<IEnumerable<Email>> GetAllEmailsAsync();

        Task<IEnumerable<Email>> GetAllUserWorkingOnEmailAsync(EmailContentDto userIdDto);

        Task<IEnumerable<LoanApplicant>> ListEmailsWithStatusOpenAsync(LoanApplicantDto loanApplicantDto);

        Task<IEnumerable<Email>> GetAllEmailsForManagerAsync();

        Task<LoanApplicant> FindLoansByIdAsync(int id);

        Task<IEnumerable<LoanApplicant>> GetAllFinishLoanApplicantAsync();

        Task<string> FindByIdAndOfEmployeeAsync(int id);

        Task<DateTime?> FindByIdDateOfTerminalAsync(int id);
    }
}