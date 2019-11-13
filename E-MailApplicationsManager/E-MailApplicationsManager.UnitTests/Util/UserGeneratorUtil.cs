using E_MailApplicationsManager.Models.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_MailApplicationsManager.UnitTests
{
    public static class UserGeneratorUtil
    {
        public static User GenerateUser()
        {
            var username = "TestUsername";
            var password = "TestPassword";
            var email = "TestEmail";

            var user = new User
            {
                UserName = username,
                PasswordHash = password,
                Email = email
            };

            return user;
        }
    }
}
