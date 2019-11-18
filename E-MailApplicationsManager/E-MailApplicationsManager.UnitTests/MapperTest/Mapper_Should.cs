using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Service.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
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
                await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var sut = new MapperService(emailServiceMock);

                await sut.MappGmailBodyIntoEmailBody(firstEmail.GmailId, body, firstEmail.UserId);

                var emailBody = actContext.Emails
                    .Where(b => b.Body == body)
                    .FirstOrDefaultAsync();

                 Assert.IsNotNull(emailBody);
            }
        }

        [TestMethod]
        public async Task MappGmailDataIntoEmailData_Test()
        {
            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var emailServiceMock = new Mock<IEmailService>().Object;

            var options = TestUtilities.GetOptions(nameof(MappGmailDataIntoEmailData_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var sut = new MapperService(emailServiceMock);

                await sut.MappGmailDataIntoEmailData(firstEmail.GmailId, firstEmail.DateReceived, firstEmail.Sender , firstEmail.Subject);

                await actContext.SaveChangesAsync();

                var email = actContext.Emails.Where(b => b.GmailId == firstEmail.GmailId).FirstOrDefaultAsync();

                Assert.IsNotNull(email);
            }
        }

        [TestMethod]
        public async Task MappGmailAttachmentIntoEmailAttachment_Test()
        {
            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var gmailId = firstEmail.GmailId;
            var FileName = "TestFileName";
            double fileSize = 876.77;

            var emailServiceMock = new Mock<IEmailService>().Object;

            var options = TestUtilities.GetOptions(nameof(MappGmailAttachmentIntoEmailAttachment_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {

                var sut = new MapperService(emailServiceMock);

                await sut.MappGmailAttachmentIntoEmailAttachment(gmailId, FileName, fileSize);

                await actContext.SaveChangesAsync();

                var attachment = actContext.LoanApplicants.Where(b => b.GmailId == firstEmail.GmailId).FirstOrDefaultAsync();

                Assert.IsNotNull(attachment);
            }
        }
    }
}
