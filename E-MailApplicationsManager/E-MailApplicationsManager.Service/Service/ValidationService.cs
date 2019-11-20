using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using System;
using System.Linq;
namespace E_MailApplicationsManager.Service.Service
{
    public class ValidationService
    {
        public LoanApplicantDto ValidationMethodFillFormForLoan(LoanApplicantDto loanApplicantDto)
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

            return loanApplicantDto;
        }

        public bool CheckEmailForDigit(string email)
        {
            var egn = email;

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
