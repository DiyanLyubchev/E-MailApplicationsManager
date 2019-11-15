using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Common;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Service
{
    public class SearchService : ISearchService
    {
        private readonly E_MailApplicationsManagerContext context;

        public SearchService(E_MailApplicationsManagerContext context)
        {
            this.context = context;
        }


        public async Task<IEnumerable<Email>> SearchEamilByStatusIdAsync(EmailStatusIdDto status)
        {
            int numberStatus = int.Parse(status.StatusId);

            var emailList = await this.context.Emails
               .Where(mail => mail.EmailStatusId == numberStatus)
               .Select(email => email)
               .ToListAsync();

            return emailList;
        }

        public async Task<Email> FindEmailAsync(int id)
        {
            return await this.context.Emails
                 .FirstOrDefaultAsync(email => email.Id == id);
        }

        public async Task<IEnumerable<Email>> GetAllEmailsAsync()
        {
            return await this.context.Emails
                .Where(email => email.IsSeen == false
                && email.EmailStatusId != (int)EmailStatusesType.InvalidApplication)
                .OrderBy(email => email.DateReceived)
                .ToListAsync();
        }

        public async Task<IEnumerable<Email>> GetAllEmailsForManagerAsync()
        {
            return await this.context.Emails
                .Where(email => email.EmailStatusId != (int)EmailStatusesType.Closed)
                .OrderBy(email => email.DateReceived)
                .ToListAsync();
        }

        public async Task<IEnumerable<Email>> GetAllUserWorkingOnEmailAsync(EmailContentDto userIdDto)
        {
            var userId = await this.context.Users
                .FirstOrDefaultAsync(uId => uId.Id == userIdDto.UserId);

            var email = await this.context.Emails
                .Include(u => u.User)
                .Where(workingOnEmail => workingOnEmail.UserId == userIdDto.UserId
                && workingOnEmail.EmailStatusId != (int)EmailStatusesType.Closed)
                .Select(emails => emails)
                .ToListAsync();

            return email;
        }

        public async Task<IEnumerable<LoanApplicant>> ListEmailsWithStatusOpenAsync(LoanApplicantDto loanApplicantDto)
        {
            var loanList = await this.context.LoanApplicants
             .Include(u => u.User)
             .Include(eMail => eMail.Emails)
             .Where(currentUser => currentUser.UserId == loanApplicantDto.UserId
              && currentUser.Emails.EmailStatusId == (int)EmailStatusesType.Open)
             .ToListAsync();

            return loanList;
        }

        public async Task<LoanApplicant> FindLoansByIdAsync(int id)
        {
            return await this.context.LoanApplicants
                 .FirstOrDefaultAsync(loan => loan.Id == id);
        }

        public async Task<IEnumerable<LoanApplicant>> GetAllFinishLoanApplicantAsync()
        {
            var loanList = await this.context.LoanApplicants
             .Include(u => u.User)
             .Include(eMail => eMail.Emails)
             .Where(finishLoan => finishLoan.Emails.EmailStatusId == (int)EmailStatusesType.Closed)
             .ToListAsync();

            return loanList;
        }

        public async Task<string> FindByIdNameOfEmployeeAsync(int id)
        {
            var eName = await this.context.LoanApplicants
                .Include(user => user.User)
                .Where(loan => loan.Id == id)
                .Select(name => name.User.UserName)
                .FirstOrDefaultAsync();

            return eName;
        }

        public async Task<DateTime?> FindByIdDateOfTerminalAsync(int id)
        {
            var dateTerminal = await this.context.LoanApplicants
                .Include(email => email.Emails)
                .Where(loan => loan.Id == id)
                .Select(date => date.Emails.SetTerminalState)
                .FirstOrDefaultAsync();

            return dateTerminal;
        }

        public async Task<string> FindByIDIsApproveOrNotAsync(int id)
        {
            var loanApplicant = await this.context.LoanApplicants
                .Where(loan => loan.Id == id)
                .Select(name => name.IsApproved)
                .FirstOrDefaultAsync();

            string result = null; 

            if (loanApplicant == false)
            {
                result = "Reject";
            }

            if (loanApplicant == true)
            {
                result = "Approve";
            }

            return result;
        }

    }
}
