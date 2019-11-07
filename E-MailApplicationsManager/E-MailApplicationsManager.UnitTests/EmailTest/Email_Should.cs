using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.UnitTests.EmailTest
{
    [TestClass]
    public class Email_Should
    {
        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenEmailDontHaveSubject_Test()
        {
            string subject = null;
            var dateReceived = "TestDate";
            var sender = "TestSender";

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenEmailDontHaveSubject_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var emailDto = new EmailDto
                {
                    Subject = subject,
                    Sender = sender,
                    DateReceived = dateReceived
                };

                var sut = new EmailService(actContext);

                await sut.AddMailAsync(emailDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenEmailDontHaveSender_Test()
        {
            var subject = "TestSubject";
            var dateReceived = "TestDate";
            string sender = null;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenEmailDontHaveSender_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var emailDto = new EmailDto
                {
                    Subject = subject,
                    Sender = sender,
                    DateReceived = dateReceived
                };

                var sut = new EmailService(actContext);

                await sut.AddMailAsync(emailDto);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenEmailDontHaveDateReceived_Test()
        {
            var subject = "TestSubject";
            string dateReceived = null;
            var sender = "TestSender";

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenEmailDontHaveDateReceived_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var emailDto = new EmailDto
                {
                    Subject = subject,
                    Sender = sender,
                    DateReceived = dateReceived
                };

                var sut = new EmailService(actContext);

                await sut.AddMailAsync(emailDto);
            }
        }

        [TestMethod]
        public async Task AddEmail_Test()
        {
            var subject = "TestSubject";
            var dateReceived = "TestDateReceived";
            var sender = "TestSender";
            var gmailId = "TestgmailId";

            var options = TestUtilities.GetOptions(nameof(AddEmail_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(
                      new Email
                      {
                          Sender = sender,
                          GmailId = gmailId,
                          Subject = subject,
                          DateReceived = dateReceived
                      });
                await actContext.SaveChangesAsync();

                var emailDto = new EmailDto
                {
                    Subject = subject,
                    Sender = sender,
                    DateReceived = dateReceived,
                    GmailId = gmailId
                };

                var sut = new EmailService(actContext);

                var result = sut.AddMailAsync(emailDto);

                Assert.IsNotNull(result);
            }

            using (var assertContext = new E_MailApplicationsManagerContext(options))
            {
                Assert.AreEqual(1, assertContext.Emails.Count());
            }
        }
    }
}
