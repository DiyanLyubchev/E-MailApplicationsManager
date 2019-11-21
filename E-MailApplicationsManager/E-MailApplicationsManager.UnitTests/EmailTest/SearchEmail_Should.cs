using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Common;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;


namespace E_MailApplicationsManager.UnitTests.EmailTest
{
    [TestClass]
    public class SearchEmail_Should
    {
        [TestMethod]
        public async Task FindEmailByEmailId_Test()
        {
            var id = 2;

            var options = TestUtilities.GetOptions(nameof(FindEmailByEmailId_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.Emails.AddAsync(new Email { Id = id });
                await actContext.SaveChangesAsync();

            }


            using (var assertContext = new E_MailApplicationsManagerContext(options))
            {
                var sut = new SearchService(assertContext);
                var findEmail = await sut.FindEmailAsync(id);

                Assert.IsNotNull(findEmail);
            }

        }

        [TestMethod]
        public async Task GetAllEmail_Test()
        {
            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var secondEmail = EmailGeneratorUtil.GenerateEmailSecond();

            var options = TestUtilities.GetOptions(nameof(GetAllEmail_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.Emails.AddAsync(firstEmail);

                await actContext.Emails.AddAsync(secondEmail);

                await actContext.SaveChangesAsync();

                var sut = new SearchService(actContext);

                var result = await sut.GetAllEmailsAsync();

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public async Task GetAllUserWorkingOnEmail_Test()
        {
            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var secondEmail = EmailGeneratorUtil.GenerateEmailSecond();

            var userId = secondEmail.UserId;

            var emailContentDto = new EmailContentDto
            {
                UserId = userId
            };

            var options = TestUtilities.GetOptions(nameof(GetAllUserWorkingOnEmail_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.Emails.AddAsync(firstEmail);

                await actContext.Emails.AddAsync(secondEmail);

                await actContext.SaveChangesAsync();

                var sut = new SearchService(actContext);

                var result = await sut.GetAllUserWorkingOnEmailAsync(emailContentDto);

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public async Task GetAllEmailAsyncByStatus_Test()
        {
            var status = "2";

            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();
            firstEmail.EmailStatusId = (int)EmailStatusesType.InvalidApplication;

            var options = TestUtilities.GetOptions(nameof(GetAllEmailAsyncByStatus_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var statusDto = new EmailStatusIdDto
                {
                    StatusId = status
                };

                var sut = new SearchService(actContext);

                var result = await sut.SearchEamilByStatusIdAsync(statusDto);

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public async Task GetAllEmailsForManagerAsync_Test()
        {
            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var secondEmail = EmailGeneratorUtil.GenerateEmailSecond();

            var options = TestUtilities.GetOptions(nameof(GetAllEmailsForManagerAsync_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.Emails.AddAsync(firstEmail);

                await actContext.Emails.AddAsync(secondEmail);

                await actContext.SaveChangesAsync();

                var sut = new SearchService(actContext);

                var result = await sut.GetAllEmailsForManagerAsync();

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public async Task ListEmailsWithStatusOpenAsync_Test()
        {
            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();
            firstEmail.EmailStatusId = (int)EmailStatusesType.Open;

            var userId = firstEmail.UserId;

            var loanApplicantDto = new LoanApplicantDto
            {                
                UserId = userId,
            };

            var options = TestUtilities.GetOptions(nameof(ListEmailsWithStatusOpenAsync_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var sut = new SearchService(actContext);

                var result = await sut.ListEmailsWithStatusOpenAsync(loanApplicantDto);

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public async Task FindLoansByIdAsync_Test()
        {
            var id = 2;

            var options = TestUtilities.GetOptions(nameof(FindLoansByIdAsync_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.LoanApplicants.AddAsync(new LoanApplicant { Id = id });
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new E_MailApplicationsManagerContext(options))
            {
                var sut = new SearchService(assertContext);
                var findEmail = await sut.FindLoansByIdAsync(id);

                Assert.IsNotNull(findEmail);
            }
        }

        [TestMethod]
        public async Task GetAllFinishLoanApplicantAsync_Test()
        {
            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();
            firstEmail.EmailStatusId = (int)EmailStatusesType.Closed;

            var options = TestUtilities.GetOptions(nameof(GetAllFinishLoanApplicantAsync_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var sut = new SearchService(actContext);

                var result = await sut.GetAllFinishLoanApplicantAsync();

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public async Task GetEmailsForChart_Test()
        {
            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();
            firstEmail.EmailStatusId = (int)EmailStatusesType.New;

            var options = TestUtilities.GetOptions(nameof(GetEmailsForChart_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var sut = new SearchService(actContext);

                var result = await sut.GetEmailsForChart();

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public async Task GetAllNotReviewedEmails_Test()
        {
            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();
            firstEmail.EmailStatusId = (int)EmailStatusesType.NotReviewed;

            var secondEmail = EmailGeneratorUtil.GenerateEmailSecond();
            firstEmail.EmailStatusId = (int)EmailStatusesType.NotReviewed;

            var options = TestUtilities.GetOptions(nameof(GetEmailsForChart_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.Emails.AddAsync(firstEmail);
                await actContext.Emails.AddAsync(secondEmail);

                await actContext.SaveChangesAsync();

                var sut = new SearchService(actContext);

                var result = await sut.GetAllNotReviewedEmails();

                Assert.AreEqual(2,result);
            }
        }
    }
}

