using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Model;
using System.Collections.Generic;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface IEncodeDecodeService
    {
        string Base64Decode(string base64EncodedData);

        string ReplaceSign(string body);

        LoanApplicant DecodeLoanApplicant(LoanApplicant loanApplicant);

        IEnumerable<LoanApplicant> DecodeLoanApplicantList(IEnumerable<LoanApplicant> loanApplicant);

        string Encrypt(string clearText);

        string Decrypt(string cipherText);
    }
}