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
            var email = "TestEmail";

            var options = TestUtilities.GetOptions(nameof(ThrowException_IfPasswordIsLessThenFiveSymbols));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var accountDto = new RegisterAccountDto
                {
                    UserName = username,
                    Password = password,
                    Role = role,
                    Email = email
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
            var email = "TestEmail";

            var options = TestUtilities.GetOptions(nameof(ThrowException_IfRoleIsInvalid));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var accountDto = new RegisterAccountDto
                {
                    UserName = username,
                    Password = password,
                    Role = role,
                    Email = email

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
            var email = "TestEmail";

            var options = TestUtilities.GetOptions(nameof(ThrowException_IfUsernameIsLessThanThreeSymbols));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var accountDto = new RegisterAccountDto
                {
                    UserName = username,
                    Password = password,
                    Role = role,
                    Email = email
                };

                var accountService = new UserService(actContext, null);

                await accountService.RegisterAccountAsync(accountDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(UserExeption))]
        public async Task ThrowException_IfUsernameIsТaken()
        {
            var username = "TestUsername";
            var password = "TestPassword";
            var role = "TestRole";
            var email = "TestEmail";

            var options = TestUtilities.GetOptions(nameof(ThrowException_IfUsernameIsТaken));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var user = await actContext.Users.AddAsync(
                    new User
                    {
                        UserName = username,
                        NormalizedUserName = username.ToUpper(),
                        LockoutEnabled = true
                    });

                await actContext.SaveChangesAsync();

                var accountDto = new RegisterAccountDto
                {
                    UserName = username,
                    Password = password,
                    Role = role,
                    Email = email
                };

                var accountService = new UserService(actContext, null);

                await accountService.RegisterAccountAsync(accountDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(UserExeption))]
        public async Task ThrowException_IfEmailIsNull()
        {
            var username = "TestUsername";
            var password = "TestPassword";
            var role = "TestRole";
            string email = null;

            var options = TestUtilities.GetOptions(nameof(ThrowException_IfEmailIsNull));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var accountDto = new RegisterAccountDto
                {
                    UserName = username,
                    Password = password,
                    Role = role,
                    Email = email
                };

                var accountService = new UserService(actContext, null);

                await accountService.RegisterAccountAsync(accountDto);
            }
        }

        [TestMethod]
        public async Task FindUserByUserId_Test()
        {
            string id = "2456Test";

            var options = TestUtilities.GetOptions(nameof(FindUserByUserId_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.Users.AddAsync(new User { Id = id });
                await actContext.SaveChangesAsync();

            }


            using (var assertContext = new E_MailApplicationsManagerContext(options))
            {
                var sut = new UserService(assertContext, null);
                var findUser = await sut.GetUserAsync(id);

                Assert.IsInstanceOfType(findUser, typeof(User));
            }

        }
    }
}
