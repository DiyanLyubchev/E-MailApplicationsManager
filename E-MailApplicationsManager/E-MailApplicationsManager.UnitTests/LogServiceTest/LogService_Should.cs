using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.UnitTests.LogServiceTest
{
    [TestClass]
    public class LogService_Should
    {
        [TestMethod]
        public async Task SaveLastLoginUser_Test()
        {
            var user = UserGeneratorUtil.GenerateUser();

            var options = TestUtilities.GetOptions(nameof(SaveLastLoginUser_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.Users.AddAsync(user);
                await actContext.SaveChangesAsync();

                var sut = new LogService(actContext);
                var result =await sut.SaveLastLoginUser(user);
                Assert.IsTrue(result);
            }
           
        }

        [TestMethod]
        public async Task SaveLastLoginUserReturFalseWhenUserIsNull_Test()
        {
            var user = UserGeneratorUtil.GenerateUser();
            user = null;

            var options = TestUtilities.GetOptions(nameof(SaveLastLoginUserReturFalseWhenUserIsNull_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var sut = new LogService(actContext);
                var result = await sut.SaveLastLoginUser(user);
                Assert.IsFalse(result);
            }

        }
    }
}
