using System.Collections.Generic;
using System.Threading.Tasks;
using E_MailApplicationsManager.Models.Model;

namespace E_MailApplicationsManager.Service.Аuxiliary
{
    public interface IAuxiliaryMethods
    {
        Task<User> GetCurrentUserAsync(string userId);

        Task<Email> GetEmailByGmailId(string gmailId);

        Task<IEnumerable<LoanApplicant>> GetLoanApplicantWithOpenStatus(string userId);

        Task<LoanApplicant> GetLoanByGmailIdAsync(string gmailId);

        Task<string> GetUser_UserNameAsync(string userName);

        Task<Email> GetEmailIncludeUserByGmailIdAsync(string id);

        Task<User> GetUserIncludeLoanByUserIdAsync(string id);
    }
}