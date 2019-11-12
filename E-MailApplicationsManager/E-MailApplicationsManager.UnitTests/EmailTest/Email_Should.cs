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
            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

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

                var sut = new EmailService(actContext);

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

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var emailDto = new EmailContentDto
                {
                    Body = body,
                    GmailId = firstEmail.GmailId
                };

                var sut = new EmailService(actContext);

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

                var sut = new EmailService(actContext);

                await sut.AddBodyToCurrentEmailAsync(emailDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenEmailDtoIsNull_AddBodyToCurrentEmailAsync_Test()
        {
            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

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

                var sut = new EmailService(actContext);

                await sut.AddBodyToCurrentEmailAsync(emailDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExceptionWhenGmailIdIsNullSetEmailStatusInvalidApplication_Test()
        {
            var userID = "TestID";
            string gmailId = null;

            var options = TestUtilities.GetOptions(nameof(ThrowExceptionWhenGmailIdIsNullSetEmailStatusInvalidApplication_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var dto = new StatusInvalidApplicationDto
                {
                    GmailId = gmailId,
                    UserId = userID
                };

                var sut = new EmailService(actContext);
                await sut.SetEmailStatusInvalidApplicationAsync(dto);
            }
        }

        [TestMethod]
        public async Task SetEmailStatusInvalidApplication_Test()
        {
            var userID = "TestId";

            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var options = TestUtilities.GetOptions(nameof(SetEmailStatusInvalidApplication_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var dto = new StatusInvalidApplicationDto
                {
                    GmailId = firstEmail.GmailId,
                    UserId = userID
                };

                var sut = new EmailService(actContext);
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

            var options = TestUtilities.GetOptions(nameof(CheckEmailBody_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var dto = new EmailContentDto
                {
                    GmailId = firstEmail.GmailId,
                };

                var sut = new EmailService(actContext);
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
                        
            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenCheckEmailBodyIsNull_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var dto = new EmailContentDto
                {
                    GmailId = firstEmail.GmailId,
                };

                var sut = new EmailService(actContext);
                await sut.CheckEmailBodyAsync(dto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(EmailExeption))]
        public async Task ThrowExeptionWhenStatusNull_ChangeStatus_Test()
        {
            string status = null;


            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenStatusNull_ChangeStatus_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var dto = new EmailStatusIdDto
                {
                    StatusId = status
                };

                var sut = new EmailService(actContext);
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

                var sut = new EmailService(actContext);
                await sut.ChangeStatusAsync(dto);
            }
        }

        [TestMethod]
        public async Task ChangeStatus_Test()
        {
            var status = "2";

            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

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

                var sut = new EmailService(actContext);
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

            var options = TestUtilities.GetOptions(nameof(TakeBody_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var dto = new EmailContentDto
                {
                    GmailId = email.Entity.GmailId
                };

                var sut = new EmailService(actContext);
                var result = await sut.TakeBodyAsync(dto);

                Assert.IsNotNull(result);
            }
        }
    }
}
