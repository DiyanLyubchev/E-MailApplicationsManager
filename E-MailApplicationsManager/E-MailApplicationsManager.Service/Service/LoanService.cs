using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.Dto;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System;
using E_MailApplicationsManager.Models.Common;
using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Util;

namespace E_MailApplicationsManager.Service.Service
{
    public class LoanService : ILoanService
    {
        private readonly E_MailApplicationsManagerContext context;

        private readonly IEncodeDecodeService encodeDecodeService;

        private const int rejectLoan = 0;
        private const int approveLoan = 1;

        public LoanService(E_MailApplicationsManagerContext context, IEncodeDecodeService encodeDecodeService)
        {
            this.context = context;
            this.encodeDecodeService = encodeDecodeService;
        }

        public async Task<LoanApplicant> FillInFormForLoanAsync(LoanApplicantDto loanApplicantDto)
        {
            ValidatorLoanService.ValidatorDetailsOfLoanIfAreNull(loanApplicantDto);

            ValidatorLoanService.ValidatorGmailId(loanApplicantDto);

            ValidatorLoanService.ValidatorDetailsOfLoan(loanApplicantDto);

            var isEgnCorrect = CheckEGNForDigit(loanApplicantDto.EGN);

            ValidatorLoanService.ValidatorEGN(isEgnCorrect);

            var user = await this.context.Users
                .Include(l => l.LoanApplicant)
                .Where(userId => userId.Id == loanApplicantDto.UserId)
                .FirstOrDefaultAsync();


            var encodeName = this.encodeDecodeService.Encrypt(loanApplicantDto.Name);
            var encodeEGN = this.encodeDecodeService.Encrypt(loanApplicantDto.EGN);
            var encodePhoneNumber = this.encodeDecodeService.Encrypt(loanApplicantDto.PhoneNumber);


            var email = await this.context.Emails
                .Where(gmailId => gmailId.GmailId == loanApplicantDto.GmailId)
                .SingleOrDefaultAsync();

            var loan = new LoanApplicant
            {
                Name = encodeName,
                EGN = encodeEGN,
                PhoneNumber = encodePhoneNumber,
                UserId = loanApplicantDto.UserId,
                User = user,
                Emails = email,
                GmailId = loanApplicantDto.GmailId
            };

            email.SetCurrentStatus = DateTime.Now;
            email.EmailStatusId = (int)EmailStatusesType.Open;

            await this.context.LoanApplicants.AddAsync(loan);
            await this.context.SaveChangesAsync();
            return loan;
        }

        public async Task<bool> ApproveLoanAsync(ApproveLoanDto approveLoanDto)
        {
            ValidatorLoanService.ValidatorApproveLoan(approveLoanDto);

            int expectedResult = int.Parse(approveLoanDto.IsApprove);

            var loan = await this.context.LoanApplicants
                .Where(gmailId => gmailId.GmailId == approveLoanDto.GmailId)
                .FirstOrDefaultAsync();

            var email = await this.context.Emails
            .Where(gmailId => gmailId.GmailId == approveLoanDto.GmailId)
            .FirstOrDefaultAsync();

            var user = await this.context.Users
                .Where(id => id.Id == approveLoanDto.UserId)
                .SingleOrDefaultAsync();

            if (expectedResult == rejectLoan)
            {
                loan.IsApproved = false;
                loan.User = user;
            }

            if (expectedResult == approveLoan)
            {
                loan.IsApproved = true;
                loan.User = user;
            }

            email.SetCurrentStatus = DateTime.Now;
            email.EmailStatusId = (int)EmailStatusesType.Closed;
            email.SetTerminalState = DateTime.Now;

            await this.context.SaveChangesAsync();

            return true;
        }

        public bool CheckEGNForDigit(string email)
        {
            var egn = "";

            for (int i = 0; i < email.Length; i++)
            {
                if (Char.IsDigit(email[i]))
                {
                    egn.Concat(email[i].ToString());
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
