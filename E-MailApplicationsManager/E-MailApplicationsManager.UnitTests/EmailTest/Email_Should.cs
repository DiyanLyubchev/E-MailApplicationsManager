using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Service.Service;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.UnitTests.EmailTest
{
    [TestClass]
    public class Email_Should
    {

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenSenderIsWithMaxLanght_Test()
        {
            var subject = "TestSubject";
            var dateReceived = "TestDate";
            var sender = new String('T', 51);
            var gmailId = "TestGmailId";

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenSenderIsWithMaxLanght_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var sut = new EmailService(actContext, loggerMock);

                var emailDto = new EmailDto
                {
                    GmailId = gmailId,
                    Subject = subject,
                    Sender = sender,
                    DateReceived = dateReceived
                };

                await sut.AddMailAsync(emailDto);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenSenderIsWithMinLanght_Test()
        {
            var subject = "TestSubject";
            var dateReceived = "TestDate";
            var sender = "Test";
            var gmailId = "TestGmailId";

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenSenderIsWithMinLanght_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var sut = new EmailService(actContext, loggerMock);

                var emailDto = new EmailDto
                {
                    GmailId = gmailId,
                    Subject = subject,
                    Sender = sender,
                    DateReceived = dateReceived
                };

                await sut.AddMailAsync(emailDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenGmailIdIsWithMaxLanght_Test()
        {
            var subject = "TestSubject";
            var dateReceived = "TestDate";
            var sender = "TestSender";
            var gmailId = new String('T', 101);

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenGmailIdIsWithMaxLanght_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var sut = new EmailService(actContext, loggerMock);

                var emailDto = new EmailDto
                {
                    GmailId = gmailId,
                    Subject = subject,
                    Sender = sender,
                    DateReceived = dateReceived
                };

                await sut.AddMailAsync(emailDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenGmailIdIsWithMinLanght_Test()
        {
            var subject = "TestSubject";
            var dateReceived = "TestDate";
            var sender = "TestSender";
            var gmailId = "Test";

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenGmailIdIsWithMinLanght_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var sut = new EmailService(actContext, loggerMock);

                var emailDto = new EmailDto
                {
                    GmailId = gmailId,
                    Subject = subject,
                    Sender = sender,
                    DateReceived = dateReceived
                };

                await sut.AddMailAsync(emailDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenEmailDontHaveSubject_Test()
        {
            string subject = null;
            var dateReceived = "TestDate";
            var sender = "TestSender";
            var gmailId = "TestGamilId";

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenEmailDontHaveSubject_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var emailDto = new EmailDto
                {
                     GmailId = gmailId,
                    Subject = subject,
                    Sender = sender,
                    DateReceived = dateReceived
                };

                var sut = new EmailService(actContext, loggerMock);

                await sut.AddMailAsync(emailDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenSubjectIsWithMaxLanght_Test()
        {
            var subject = new String('T' , 101);
            var dateReceived = "TestDate";
            var sender = "TestSender";
            var gmailId = "TestGamilId";

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenSubjectIsWithMinLanght_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var sut = new EmailService(actContext, loggerMock);

                var emailDto = new EmailDto
                {
                    GmailId = gmailId,
                    Subject = subject,
                    Sender = sender,
                    DateReceived = dateReceived
                };

                await sut.AddMailAsync(emailDto);
            }
        }


        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenSubjectIsWithMinLanght_Test()
        {
            string subject = "ab";
            var dateReceived = "TestDate";
            var sender = "TestSender";
            var gmailId = "TestGamilId";

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenSubjectIsWithMinLanght_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var sut = new EmailService(actContext, loggerMock);

                var emailDto = new EmailDto
                {
                    GmailId = gmailId,
                    Subject = subject,
                    Sender = sender,
                    DateReceived = dateReceived
                };

                await sut.AddMailAsync(emailDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenEmailDontHaveSender_Test()
        {
            var gmailId = "TestGamilId";
            var subject = "TestSubject";
            var dateReceived = "TestDate";
            string sender = null;

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenEmailDontHaveSender_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var emailDto = new EmailDto
                {
                    GmailId = gmailId,
                    Subject = subject,
                    Sender = sender,
                    DateReceived = dateReceived
                };

                var sut = new EmailService(actContext, loggerMock);

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
            var gmailId = "TestGamilId";

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenEmailDontHaveDateReceived_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var emailDto = new EmailDto
                {
                    GmailId = gmailId,
                    Subject = subject,
                    Sender = sender,
                    DateReceived = dateReceived
                };

                var sut = new EmailService(actContext, loggerMock);

                await sut.AddMailAsync(emailDto);
            }
        }

        [TestMethod]
        public async Task AddEmail_Test()
        {
            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(AddEmail_Test));

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

                var sut = new EmailService(actContext, loggerMock);

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

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(AddBodyToCurrentEmail_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var emailDto = new EmailContentDto
                {
                    Body = body,
                    GmailId = firstEmail.GmailId
                };

                var sut = new EmailService(actContext, loggerMock);

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
            var body = "TestBody";
            var dtoBody = "TestDtoBody";

            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();
            firstEmail.Body = body;

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenCurrentEmailHaveBody_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);


                await actContext.SaveChangesAsync();

                var emailDto = new EmailContentDto
                {
                    Body = dtoBody,
                    GmailId = firstEmail.GmailId
                };

                var sut = new EmailService(actContext, loggerMock);

                await sut.AddBodyToCurrentEmailAsync(emailDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenEmailDtoIsNull_AddBodyToCurrentEmailAsync_Test()
        {
            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenEmailDtoIsNull_AddBodyToCurrentEmailAsync_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);


                await actContext.SaveChangesAsync();

                var emailDto = new EmailContentDto
                {
                    Body = null,
                    GmailId = firstEmail.GmailId
                };

                var sut = new EmailService(actContext, loggerMock);

                await sut.AddBodyToCurrentEmailAsync(emailDto);
            }
        }
        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenEmailBodyIsToLong_AddBodyToCurrentEmailAsync_Test()
        {
            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var body = new String('T', 1001);

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenEmailBodyIsToLong_AddBodyToCurrentEmailAsync_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);


                await actContext.SaveChangesAsync();

                var emailDto = new EmailContentDto
                {
                    Body = body,
                    GmailId = firstEmail.GmailId
                };

                var sut = new EmailService(actContext, loggerMock);

                await sut.AddBodyToCurrentEmailAsync(emailDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExceptionWhenGmailIdIsNullSetEmailStatusInvalidApplication_Test()
        {
            var userID = "TestID";
            string gmailId = null;

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExceptionWhenGmailIdIsNullSetEmailStatusInvalidApplication_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var dto = new StatusInvalidApplicationDto
                {
                    GmailId = gmailId,
                    UserId = userID
                };

                var sut = new EmailService(actContext, loggerMock);
                await sut.SetEmailStatusInvalidApplicationAsync(dto);
            }
        }

        [TestMethod]
        public async Task SetEmailStatusInvalidApplication_Test()
        {
            var user = UserGeneratorUtil.GenerateUser();

            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(SetEmailStatusInvalidApplication_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);
                var currentUser = await actContext.AddAsync(user);
                await actContext.SaveChangesAsync();

                var dto = new StatusInvalidApplicationDto
                {
                    GmailId = firstEmail.GmailId,
                    UserId = currentUser.Entity.Id
                };

                var sut = new EmailService(actContext, loggerMock);
                var result = await sut.SetEmailStatusInvalidApplicationAsync(dto);

                Assert.IsTrue(result);
            }
        }
        [TestMethod]
        public async Task CheckEmailBody_Test()
        {
            var body = "TestBody";

            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();
            firstEmail.Body = body;

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(CheckEmailBody_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var dto = new EmailContentDto
                {
                    GmailId = firstEmail.GmailId,
                };

                var sut = new EmailService(actContext, loggerMock);
                var result = await sut.CheckEmailBodyAsync(dto);

                Assert.AreEqual(result.Body, firstEmail.Body);
                Assert.IsNotNull(result.Body);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenCheckEmailBodyIsNull_Test()
        {
            string body = null;

            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();
            firstEmail.Body = body;

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenCheckEmailBodyIsNull_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var dto = new EmailContentDto
                {
                    GmailId = firstEmail.GmailId,
                };

                var sut = new EmailService(actContext, loggerMock);
                await sut.CheckEmailBodyAsync(dto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenStatusNull_ChangeStatus_Test()
        {
            string status = null;

            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenStatusNull_ChangeStatus_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var dto = new EmailStatusIdDto
                {
                    StatusId = status
                };

                var sut = new EmailService(actContext, loggerMock);
                await sut.ChangeStatusAsync(dto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenGmailIdIsNull_ChangeStatus_Test()
        {
            var status = "2";
            string gmailId = null;

            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenGmailIdIsNull_ChangeStatus_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var dto = new EmailStatusIdDto
                {
                    StatusId = status,
                    GmailId = gmailId
                };

                var sut = new EmailService(actContext, loggerMock);
                await sut.ChangeStatusAsync(dto);
            }
        }

        [TestMethod]
        public async Task ChangeStatus_Test()
        {
            var status = "2";

            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(ChangeStatus_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var dto = new EmailStatusIdDto
                {
                    StatusId = status,
                    GmailId = email.Entity.GmailId
                };

                var sut = new EmailService(actContext, loggerMock);
                var result = await sut.ChangeStatusAsync(dto);

                Assert.IsTrue(result);

            }
        }

        [TestMethod]
        public async Task TakeBody_Test()
        {
            var body = "TestBody";

            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            firstEmail.Body = body;

            var loggerMock = new Mock<ILogger<EmailService>>().Object;

            var options = TestUtilities.GetOptions(nameof(TakeBody_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var dto = new EmailContentDto
                {
                    GmailId = email.Entity.GmailId
                };

                var sut = new EmailService(actContext, loggerMock);
                var result = await sut.TakeBodyAsync(dto);

                Assert.IsNotNull(result);
            }
        }
    }
}
