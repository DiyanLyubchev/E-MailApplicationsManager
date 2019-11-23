using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface ISearchLoanApplicant
    {
        Task<LoanApplicant> FindLoansByIdAsync(int id);
    
        Task<string> FindByIdNameOfEmployeeAsync(int id);

        Task<DateTime?> FindByIdDateOfTerminalAsync(int id);

        Task<string> FindByIDIsApproveOrNotAsync(int id);
    }
}
