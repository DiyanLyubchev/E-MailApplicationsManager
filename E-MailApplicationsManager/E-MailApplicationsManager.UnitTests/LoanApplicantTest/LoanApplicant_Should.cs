using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Service.Service;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
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
                var loan = await actContext.LoanApplicants.AddAsync(
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

        [TestMethod]
        [ExpectedException(typeof(LoanExeption))]
        public async Task ThrowExeptionWhenNameIsMoreThanMaxLenght_Test()
        {
            var loanUtil = LoanGeneratorUtil.GenerateLoan();
            loanUtil.Name = new String('t', 51);

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenNameIsMoreThanMaxLenght_Test));

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
        public async Task ThrowExeptionWhenNameIsLessThanMinLenght_Test()
        {
            var loanUtil = LoanGeneratorUtil.GenerateLoan();
            loanUtil.Name = "IT";

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenNameIsLessThanMinLenght_Test));

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
        public async Task ThrowExeptionWhenPhoneNumberIsMoreThanMaxLenght_Test()
        {
            var loanUtil = LoanGeneratorUtil.GenerateLoan();
            loanUtil.PhoneNumber = new String('t', 51);

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenPhoneNumberIsMoreThanMaxLenght_Test));

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
        public async Task ThrowExeptionWhenPhoneNumberIsLessThanMinLenght_Test()
        {
            var loanUtil = LoanGeneratorUtil.GenerateLoan();
            loanUtil.Name = "IT";

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenPhoneNumberIsLessThanMinLenght_Test));

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
        public async Task ThrowExeptionWhenEGNIsNotCorrect_Test()
        {
            var loanUtil = LoanGeneratorUtil.GenerateLoan();
            loanUtil.EGN = "92121245";

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenEGNIsNotCorrect_Test));

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
        public void CheckEmailForDigitReturtTrue_Test()
        {
            var egn = "7802120867";

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;
            var options = TestUtilities.GetOptions(nameof(CheckEmailForDigitReturtTrue_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {

                var sut = new LoanService(actContext, mockEncodeDecodeService);

                var result = sut.CheckEGNForDigit(egn);

                Assert.IsTrue(result);
            }
        }

        [TestMethod]
        public void CheckEmailForDigitReturnFalse_Test()
        {
            var egn = "7802120e67";

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;
            var options = TestUtilities.GetOptions(nameof(CheckEmailForDigitReturnFalse_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {

                var sut = new LoanService(actContext, mockEncodeDecodeService);

                var result = sut.CheckEGNForDigit(egn);

                Assert.IsFalse(result);
            }
        }
    }
}
