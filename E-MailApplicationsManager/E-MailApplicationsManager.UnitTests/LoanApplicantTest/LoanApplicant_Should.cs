using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.UnitTests.LoanApplicantTest
{
    [TestClass]
    public class LoanApplicant_Should
    {
        [TestMethod]
        [ExpectedException(typeof(LoanExeption))]
        public async Task ThrowExeptionWhenNameIsNullInFormForLoan_Test()
        {
            var loanUtil = LoanGeneratorUtil.GenerateLoan();
            loanUtil.Name = null;

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenNameIsNullInFormForLoan_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var loanDto = new LoanApplicantDto
                {
                    Name = loanUtil.Name,
                    EGN = loanUtil.EGN,
                    PhoneNumber = loanUtil.PhoneNumber,
                    GmailId = loanUtil.GmailId
                };

                var sut = new LoanService(actContext, mockEncodeDecodeService);

                await sut.FillInFormForLoanAsync(loanDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(LoanExeption))]
        public async Task ThrowExeptionWhenEgnIsNullInFormForLoan_Test()
        {
            var loanUtil = LoanGeneratorUtil.GenerateLoan();
            loanUtil.EGN = null;

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenEgnIsNullInFormForLoan_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var loanDto = new LoanApplicantDto
                {
                    Name = loanUtil.Name,
                    EGN = loanUtil.EGN,
                    PhoneNumber = loanUtil.PhoneNumber,
                    GmailId = loanUtil.GmailId
                };

                var sut = new LoanService(actContext, mockEncodeDecodeService);

                await sut.FillInFormForLoanAsync(loanDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(LoanExeption))]
        public async Task ThrowExeptionWhenPhoneNumberIsNullInFormForLoan_Test()
        {
            var loanUtil = LoanGeneratorUtil.GenerateLoan();
            loanUtil.PhoneNumber = null;

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenPhoneNumberIsNullInFormForLoan_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var loanDto = new LoanApplicantDto
                {
                    Name = loanUtil.Name,
                    EGN = loanUtil.EGN,
                    PhoneNumber = loanUtil.PhoneNumber,
                    GmailId = loanUtil.GmailId
                };


                var sut = new LoanService(actContext, mockEncodeDecodeService);

                await sut.FillInFormForLoanAsync(loanDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(LoanExeption))]
        public async Task ThrowExeptionWhenGmailIdIsNullInFormForLoan_Test()
        {
            var loanUtil = LoanGeneratorUtil.GenerateLoan();
            loanUtil.GmailId = null;

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenGmailIdIsNullInFormForLoan_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var loanDto = new LoanApplicantDto
                {
                    Name = loanUtil.Name,
                    EGN = loanUtil.EGN,
                    PhoneNumber = loanUtil.PhoneNumber,
                    GmailId = loanUtil.GmailId
                };

                var sut = new LoanService(actContext, mockEncodeDecodeService);

                await sut.FillInFormForLoanAsync(loanDto);
            }
        }

        [TestMethod]
        public async Task FillInFormForLoan_Test()
        {
            var loanUtil = LoanGeneratorUtil.GenerateLoan();

            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(FillInFormForLoan_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var loanDto = new LoanApplicantDto
                {
                    Name = loanUtil.Name,
                    EGN = loanUtil.EGN,
                    PhoneNumber = loanUtil.PhoneNumber,
                    GmailId = loanUtil.GmailId,
                    UserId = loanUtil.GmailId
                };

                var sut = new LoanService(actContext, mockEncodeDecodeService);

                var result = await sut.FillInFormForLoanAsync(loanDto);

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(LoanExeption))]
        public async Task ThrowExeptionWhenGmailIdIsNullIn_ApproveLoan_Test()
        {
            var expectedResult = "1";
            string gmailId = null;

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenGmailIdIsNullIn_ApproveLoan_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var loanDto = new ApproveLoanDto
                {
                    GmailId = gmailId,
                    IsApprove = expectedResult
                };

                var sut = new LoanService(actContext, mockEncodeDecodeService);

                await sut.ApproveLoanAsync(loanDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(LoanExeption))]
        public async Task ThrowExeptionWhenExpectedResultIsNullIn_ApproveLoan_Test()
        {
            string expectedResult = null;
            var gmailId = "TestGmailId";

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenExpectedResultIsNullIn_ApproveLoan_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var loanDto = new ApproveLoanDto
                {
                    GmailId = gmailId,
                    IsApprove = expectedResult
                };

                var sut = new LoanService(actContext, mockEncodeDecodeService);

                await sut.ApproveLoanAsync(loanDto);
            }
        }

        [TestMethod]
        public async Task ApproveLoan_Test()
        {
            var expectedResult = "1";

            var loanUtil = LoanGeneratorUtil.GenerateLoan();

            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(ApproveLoan_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var email = await actContext.LoanApplicants
                    .AddAsync(
                    new LoanApplicant
                    {
                        GmailId = loanUtil.GmailId,
                        EGN = loanUtil.GmailId,
                        Name = loanUtil.Name,
                        PhoneNumber = loanUtil.PhoneNumber,
                        UserId = loanUtil.UserId
                    });

                await actContext.Emails.AddAsync(firstEmail);

                await actContext.SaveChangesAsync();

                var loanDto = new ApproveLoanDto
                {
                    GmailId = loanUtil.GmailId,
                    IsApprove = expectedResult
                };

                var sut = new LoanService(actContext, mockEncodeDecodeService);

                var result = await sut.ApproveLoanAsync(loanDto);

                Assert.IsTrue(result);
            }
        }
    }
}
