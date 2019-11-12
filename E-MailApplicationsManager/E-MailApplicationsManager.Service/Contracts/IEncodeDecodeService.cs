using E_MailApplicationsManager.Models;
using System.Collections.Generic;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface IEncodeDecodeService
    {
        string Base64Decode(string base64EncodedData);
        string Base64Encode(string plainText);

        LoanApplicant DecodeLoanApplicant(LoanApplicant loanApplicant);

        IEnumerable<LoanApplicant> DecodeLoanApplicantList(IEnumerable<LoanApplicant> loanApplicant);
    }
}