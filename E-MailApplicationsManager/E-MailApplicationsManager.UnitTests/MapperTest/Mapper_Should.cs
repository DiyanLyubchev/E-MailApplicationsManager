using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.UnitTests.MapperTest
{
    [TestClass]
    public class Mapper_Should
    {
        [TestMethod]
        public async Task MappGmailBodyIntoEmailBody_Test()
        {
            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();
            string body = "TestBody";

            var emailServiceMock = new Mock<IEmailService>().Object;

            var options = TestUtilities.GetOptions(nameof(MappGmailBodyIntoEmailBody_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);
                await actContext.Users.AddAsync(new User { Id = firstEmail.UserId });

                await actContext.SaveChangesAsync();

                var sut = new MapperService(emailServiceMock);

                var result = await sut.MappGmailBodyIntoEmailBody(firstEmail.GmailId, body, firstEmail.UserId);

                Assert.AreEqual(1, email.Entity.Body);
            }
        }
    }
}
