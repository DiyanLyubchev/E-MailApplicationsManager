using E_MailApplicationsManager.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_MailApplicationsManager.UnitTests.Util
{
    public static class LoanAplicantEncodeUtil
    {
        public static LoanApplicant GenerateLoanApplicantEncode()
        {
            var name = "RXZnZW5pIEV2Z2VuaWV2";
            var phoneNumber = "MDk4OS8yNTUtMzQ1";
            var egn = "MDk4OS8yNTUtMzQ1";
            var gmailId = "TestGmailId";

            var encodeLoan = new LoanApplicant
            {
                Name = name,
                PhoneNumber = phoneNumber,
                EGN = egn,
                GmailId = gmailId
            };

            return encodeLoan;
        }
    }
}
