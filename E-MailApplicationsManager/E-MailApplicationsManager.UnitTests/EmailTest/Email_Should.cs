using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenEmailDontHaveSubject_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var emailDto = new EmailDto
                {
                    Subject = subject,
                    Sender = sender,
                    DateReceived = dateReceived
                };

                var sut = new EmailService(actContext, mockEncodeDecodeService);

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

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenEmailDontHaveSender_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var emailDto = new EmailDto
                {
                    Subject = subject,
                    Sender = sender,
                    DateReceived = dateReceived
                };

                var sut = new EmailService(actContext, mockEncodeDecodeService);

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

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenEmailDontHaveDateReceived_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var emailDto = new EmailDto
                {
                    Subject = subject,
                    Sender = sender,
                    DateReceived = dateReceived
                };

                var sut = new EmailService(actContext, mockEncodeDecodeService);

                await sut.AddMailAsync(emailDto);
            }
        }

        [TestMethod]
        public async Task AddEmail_Test()
        {
            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var options = TestUtilities.GetOptions(nameof(AddEmail_Test));

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var emailDto = new EmailDto
                {
                    Subject = firstEmail.Subject,
                    Sender = firstEmail.Sender,
                    DateReceived = firstEmail.DateReceived,
                    GmailId = firstEmail.GmailId
                };

                var sut = new EmailService(actContext, mockEncodeDecodeService);

                var result = sut.AddMailAsync(emailDto);

                Assert.IsNotNull(result);
            }

            using (var assertContext = new E_MailApplicationsManagerContext(options))
            {
                Assert.AreEqual(1, assertContext.Emails.Count());
            }
        }

        [TestMethod]
        public async Task AddBodyToCurrentEmail_Test()
        {
            var body = "TestBody";

            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var options = TestUtilities.GetOptions(nameof(AddBodyToCurrentEmail_Test));

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var emailDto = new EmailContentDto
                {
                    Body = body,
                    GmailId = firstEmail.GmailId
                };

                var sut = new EmailService(actContext, mockEncodeDecodeService);

                await sut.AddBodyToCurrentEmailAsync(emailDto);
            }

            using (var assertContext = new E_MailApplicationsManagerContext(options))
            {
                var sut = assertContext.Emails
                    .Select(emailBody => emailBody.Body)
                    .ToString();

                Assert.IsNotNull(sut);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenCurrentEmailHaveBody_Test()
        {
            string body = null;

            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenCurrentEmailHaveBody_Test));

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);


                await actContext.SaveChangesAsync();

                var emailDto = new EmailContentDto
                {
                    Body = body,
                    GmailId = firstEmail.GmailId
                };

                var sut = new EmailService(actContext, mockEncodeDecodeService);

                await sut.AddBodyToCurrentEmailAsync(emailDto);
            }
        }
    }
}
//public async Task<Email> AddBodyToCurrentEmailAsync(EmailContentDto emailDto)
//{
//    var email = await this.context.Emails
//        .Where(gMail => gMail.GmailId == emailDto.GmailId)
//        .FirstOrDefaultAsync();

//    if (emailDto.Body == null)
//    {
//        throw new EmailExeption($"Email with the following id {emailDto.GmailId} does not exist");
//    }

//    if (email.Body != null)
//    {
//        throw new EmailExeption($"Email with the following id {emailDto.GmailId} contains body");
//    }

//    if (email.Body == null)
//    {
//        email.Body = emailDto.Body;
//        email.InitialRegistrationInData = DateTime.Now;
//        email.UserId = emailDto.UserId;
//        email.IsSeen = true;
//        email.EmailStatusId = (int)EmailStatusesType.New;
//        await this.context.SaveChangesAsync();
//    }

//    return email;
//}