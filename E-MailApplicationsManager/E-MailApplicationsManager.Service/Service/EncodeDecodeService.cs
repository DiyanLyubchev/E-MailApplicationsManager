using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_MailApplicationsManager.Service.Service
{
    public class EncodeDecodeService : IEncodeDecodeService
    {

        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        public LoanApplicant DecodeLoanApplicant(LoanApplicant loanApplicant)
        {
            var name = Base64Decode(loanApplicant.Name);
            var egn = Base64Decode(loanApplicant.EGN);
            var phoneNumber = Base64Decode(loanApplicant.PhoneNumber);

            var loan = new LoanApplicant
            {
                Name = name,
                EGN = egn,
                PhoneNumber = phoneNumber,
                GmailId = loanApplicant.GmailId
            };

            return loan;
        }

        public IEnumerable<LoanApplicant> DecodeLoanApplicantList(IEnumerable<LoanApplicant> loanApplicant)
        {
            var loan = new List<LoanApplicant>();

            foreach (var item in loanApplicant)
            {
                var name = Base64Decode(item.Name);
                loan.Add(new LoanApplicant { Name = name, Id = item.Id });
            }
            return loan;
        }

        public string ReplaceSign(string body)
        {
            string codedBody = body.Replace("-", "+");
            codedBody = codedBody.Replace("_", "/");

            return codedBody;
        }
    }
}
