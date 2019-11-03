using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Service.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.UnitTests
{
    [TestClass]
    public class Account_Should
    {
        [TestMethod]
        [ExpectedException(typeof(UserExeption))]
        public async Task ThrowException_IfPasswordIsLessThenFiveSymbols()
        {
            var username = "TestUsername";
            var password = "Tp";
            var role = "Manager";

            var options = TestUtilities.GetOptions(nameof(ThrowException_IfPasswordIsLessThenFiveSymbols));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {                
                var accountDto = new RegisterAccountDto
                {
                    UserName = username,
                    Password = password,
                    Role = role
                };

                var accountService = new UserService(actContext, null);

                await accountService.RegisterAccountAsync(accountDto);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(UserExeption))]
        public async Task ThrowException_IfRoleIsInvalid()
        {
            var username = "TestUsername";
            var password = "TestPassword";
            var role = "TestRole";

            var options = TestUtilities.GetOptions(nameof(ThrowException_IfRoleIsInvalid));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var accountDto = new RegisterAccountDto
                {
                    UserName = username,
                    Password = password,
                    Role = role
                };

                var accountService = new UserService(actContext, null);

                await accountService.RegisterAccountAsync(accountDto);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(UserExeption))]
        public async Task ThrowException_IfUsernameIsLessThanThreeSymbols()
        {
            var username = "Tu";
            var password = "TestPassword";
            var role = "TestRole";

            var options = TestUtilities.GetOptions(nameof(ThrowException_IfUsernameIsLessThanThreeSymbols));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var accountDto = new RegisterAccountDto
                {
                    UserName = username,
                    Password = password,
                    Role = role
                };

                var accountService = new UserService(actContext, null);

                await accountService.RegisterAccountAsync(accountDto);
            }
        }
    }
}
