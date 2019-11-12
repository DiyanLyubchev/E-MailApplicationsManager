using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_MailApplicationsManager.UnitTests
{
    public static class LoanGeneratorUtil
    {
        public static LoanApplicant GenerateLoan()
        {
            var gmailId = "TestgmailId";
            var name = "TestName";
            var egn = "TestEgn";
            var phoneNumber = "TestPhoneNumber";
            var userId = "c23c3678-6194-4b7e-a928-09614190eb62";

            var loan = new LoanApplicant
            {
                Name = name,
                EGN = egn,
                PhoneNumber = phoneNumber,
                UserId = userId,
                GmailId = gmailId
            };

            return loan;
        }
    }
}
