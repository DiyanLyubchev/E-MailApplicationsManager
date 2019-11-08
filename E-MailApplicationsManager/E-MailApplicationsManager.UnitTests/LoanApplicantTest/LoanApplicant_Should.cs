﻿using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
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
            string name = null;
            var egn = "TestEgn";
            var phoneNumber = "TestPhoneNumber";

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenNameIsNullInFormForLoan_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var loanDto = new LoanApplicantDto
                {
                    Name = name,
                    EGN = egn,
                    PhoneNumber = phoneNumber
                };

                var sut = new LoanService(actContext, mockEncodeDecodeService);

                await sut.FillInFormForLoan(loanDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(LoanExeption))]
        public async Task ThrowExeptionWhenEgnIsNullInFormForLoan_Test()
        {
            var name = "TestName";
            string egn = null;
            var phoneNumber = "TestPhoneNumber";

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenEgnIsNullInFormForLoan_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var loanDto = new LoanApplicantDto
                {
                    Name = name,
                    EGN = egn,
                    PhoneNumber = phoneNumber
                };

                var sut = new LoanService(actContext, mockEncodeDecodeService);

                await sut.FillInFormForLoan(loanDto);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(LoanExeption))]
        public async Task ThrowExeptionWhenPhoneNumberIsNullInFormForLoan_Test()
        {
            var name = "TestName";
            var egn = "TestEgn";
            string phoneNumber = null;

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(ThrowExeptionWhenPhoneNumberIsNullInFormForLoan_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var loanDto = new LoanApplicantDto
                {
                    Name = name,
                    EGN = egn,
                    PhoneNumber = phoneNumber
                };

                var sut = new LoanService(actContext, mockEncodeDecodeService);

                await sut.FillInFormForLoan(loanDto);
            }
        }

        [TestMethod]
        public async Task FillInFormForLoan_Test()
        {
            var name = "TestName";
            var egn = "TestEgn";
            var phoneNumber = "TestPhoneNumber";

            var mockEncodeDecodeService = new Mock<IEncodeDecodeService>().Object;

            var options = TestUtilities.GetOptions(nameof(FillInFormForLoan_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var loanDto = new LoanApplicantDto
                {
                    Name = name,
                    EGN = egn,
                    PhoneNumber = phoneNumber
                };

                var sut = new LoanService(actContext, mockEncodeDecodeService);

                var result = await sut.FillInFormForLoan(loanDto);

                Assert.IsNotNull(result);
            }
        }
    }
}