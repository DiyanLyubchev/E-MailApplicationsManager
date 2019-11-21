using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System;
using E_MailApplicationsManager.Models.Common;
using E_MailApplicationsManager.Models.Model;

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
            if (loanApplicantDto.Name == null ||
              loanApplicantDto.EGN == null
              || loanApplicantDto.PhoneNumber == null)
            {
                throw new LoanExeption("Тhe details of the loan request have not been filled in correctly");
            }

            if (loanApplicantDto.GmailId == null)
            {
                throw new LoanExeption($"Email with ID {loanApplicantDto.GmailId} does not exist!");
            }

            if (loanApplicantDto.EGN.Length != 10)
            {
                throw new LoanExeption("The EGN of the client must be exactly 10 digits!");
            }

            if (loanApplicantDto.Name.Length < 3 || loanApplicantDto.Name.Length > 50)
            {
                throw new LoanExeption("The length of the client's name is not correct!");
            }
            if (loanApplicantDto.PhoneNumber.Length < 3 || loanApplicantDto.PhoneNumber.Length > 50)
            {
                throw new LoanExeption("The length of the client's phone number is not correct!");
            }

            var isEgnCorrect = CheckEGNForDigit(loanApplicantDto.EGN);

            if (isEgnCorrect == false)
            {
                throw new LoanExeption("EGN cannot contains digits");
            }

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

            if (approveLoanDto.GmailId == null || approveLoanDto.IsApprove == null)
            {
                throw new LoanExeption($"Тhe details of the loan request are invalid");
            }

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
