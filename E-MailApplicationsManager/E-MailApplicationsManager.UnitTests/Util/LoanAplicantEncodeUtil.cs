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
            var name = "CWH8UP++GqTltbMfA8MSxcCoU5GBP37sx9t0XlXPhsA=";
            var phoneNumber = "AVQDF1p2qex5Ci7o4hYP4xTkH/hkZ8HUYaOBZsNF3dY=";
            var egn = "GUc/E+NAzZ/zl/4tRAxDP60AvFOdAAXYZ41L8/ANRtQ=";
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
