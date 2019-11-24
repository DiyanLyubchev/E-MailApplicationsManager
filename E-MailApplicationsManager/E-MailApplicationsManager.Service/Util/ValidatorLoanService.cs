using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;

namespace E_MailApplicationsManager.Service.Util
{
    public static class ValidatorLoanService
    {
        public static void ValidatorDetailsOfLoanIfAreNull(LoanApplicantDto loanApplicantDto)
        {
            if (loanApplicantDto.Name == null ||
               loanApplicantDto.EGN == null
               || loanApplicantDto.PhoneNumber == null)
            {
                throw new LoanExeption("Тhe details of the loan request have not been filled in correctly");
            }
        }

        public static void ValidatorGmailId(LoanApplicantDto loanApplicantDto)
        {
            if (loanApplicantDto.GmailId == null)
            {
                throw new LoanExeption($"Email with ID {loanApplicantDto.GmailId} does not exist!");
            }
        }

        public static void ValidatorDetailsOfLoan(LoanApplicantDto loanApplicantDto)
        {
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
        }

        public static void ValidatorEGN(bool isEgnCorrect)
        {
            if (isEgnCorrect == false)
            {
                throw new LoanExeption("EGN cannot contains digits");
            }
        }

        public static void ValidatorApproveLoan(ApproveLoanDto approveLoanDto)
        {
            if (approveLoanDto.GmailId == null || approveLoanDto.IsApprove == null)
            {
                throw new LoanExeption($"Тhe details of the loan request are invalid");
            }
        }
    }
}
