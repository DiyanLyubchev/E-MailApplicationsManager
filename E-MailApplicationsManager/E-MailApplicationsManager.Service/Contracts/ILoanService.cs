using System.Threading.Tasks;
using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Service.Dto;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface ILoanService
    {
        Task<LoanApplicant> FillInFormForLoanAsync(LoanApplicantDto loanApplicantDto);

        Task<bool> ApproveLoanAsync(ApproveLoanDto approveLoanDto);
    }
}