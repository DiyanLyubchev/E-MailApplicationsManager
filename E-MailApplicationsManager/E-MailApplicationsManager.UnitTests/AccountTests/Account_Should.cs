using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Models.Model;
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
            var email = "TestEmail";
            var role = "Manager";

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
            var email = "TestEmail";
            var role = "TestRole";

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
            var email = "TestEmail";
            var role = "TestRole";

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
            var email = "TestEmail";
            var role = "TestRole";

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
        [TestMethod]
        public async Task ChangePassword_Test()
        {
            var newPassword = "TestPassword2";
            var user = UserGeneratorUtil.GenerateUser();

            var options = TestUtilities.GetOptions(nameof(ChangePassword_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.Users.AddAsync(user);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new E_MailApplicationsManagerContext(options))
            {
                var dto = new ChangePasswordDto
                {
                    NewPassword = newPassword,
                    OldPassword = user.PasswordHash,
                    UserId = user.Id
                };

                var sut = new UserService(assertContext, null);
                var result = await sut.ChangePasswordAsync(dto);

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(UserExeption))]
        public async Task ThrowExeptionWhenOldPassworDtoIsNull_ChangePassword_Test()
        {
            var newPassword = "TestPassword2";
            var user = UserGeneratorUtil.GenerateUser();

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenOldPassworDtoIsNull_ChangePassword_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.Users.AddAsync(user);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new E_MailApplicationsManagerContext(options))
            {
                var dto = new ChangePasswordDto
                {
                    NewPassword = newPassword,
                    OldPassword = null,
                    UserId = user.Id
                };

                var sut = new UserService(assertContext, null);
                await sut.ChangePasswordAsync(dto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(UserExeption))]
        public async Task ThrowExeptionWhenNewPassworDtoIsNull_ChangePassword_Test()
        {
            string newPassword = null;
            var user = UserGeneratorUtil.GenerateUser();

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenNewPassworDtoIsNull_ChangePassword_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.Users.AddAsync(user);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new E_MailApplicationsManagerContext(options))
            {
                var dto = new ChangePasswordDto
                {
                    NewPassword = newPassword,
                    OldPassword = user.PasswordHash,
                    UserId = user.Id
                };

                var sut = new UserService(assertContext, null);
                await sut.ChangePasswordAsync(dto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(UserExeption))]
        public async Task ThrowExeptionWhenUserIsNull_ChangePassword_Test()
        {
            string newPassword = null;
            var user = UserGeneratorUtil.GenerateUser();

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenUserIsNull_ChangePassword_Test));

            using (var assertContext = new E_MailApplicationsManagerContext(options))
            {
                var dto = new ChangePasswordDto
                {
                    NewPassword = newPassword,
                    OldPassword = user.PasswordHash,
                    UserId = user.Id
                };

                var sut = new UserService(assertContext, null);
                await sut.ChangePasswordAsync(dto);
            }
        }
    }
}
