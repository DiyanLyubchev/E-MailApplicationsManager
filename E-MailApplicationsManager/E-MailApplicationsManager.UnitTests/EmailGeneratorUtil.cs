using E_MailApplicationsManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_MailApplicationsManager.UnitTests
{
    public static class EmailGeneratorUtil
    {
        public static Email GenerateEmailFirst()
        {
            var subject = "TestSubject";
            var dateReceived = "TestDateReceived";
            var sender = "TestSender";
            var gmailId = "TestgmailId";
            var userId = "34234452";

            var email = new Email
            {
                Sender = sender,
                GmailId = gmailId,
                Subject = subject,
                DateReceived = dateReceived,
                IsSeen = false,
                UserId = userId

            };

            return email;
        }

        public static Email GenerateEmailSecond()
        {
            var subject = "TestSubject2";
            var dateReceived = "TestDateReceived2";
            var sender = "TestSender2";
            var gmailId = "TestgmailId2";
            var userId = "34234452";

            var email = new Email
            {
                Sender = sender,
                GmailId = gmailId,
                Subject = subject,
                DateReceived = dateReceived,
                IsSeen = false,
                UserId = userId
            };

            return email;
        }
    }
}
