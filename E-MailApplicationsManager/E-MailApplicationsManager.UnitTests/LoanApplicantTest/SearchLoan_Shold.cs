﻿using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.UnitTests.LoanApplicantTest
{
    [TestClass]
    public class SearchLoan_Shold
    {
        [TestMethod]
        public async Task FindByIdAndOfEmployeeAsync_Test()
        {
            var id = 1;
            var loanUtil = LoanGeneratorUtil.GenerateLoan();

            var options = TestUtilities.GetOptions(nameof(FindByIdAndOfEmployeeAsync_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var loan = await actContext.LoanApplicants
                    .AddAsync(loanUtil);

                await actContext.SaveChangesAsync();

            }

            using (var assertContext = new E_MailApplicationsManagerContext(options))
            {
                var sut = new SearchService(assertContext);
                var result = sut.FindByIdAndOfEmployeeAsync(id);

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public async Task FindByIdDateOfTerminalAsync_Test()
        {
            var id = 1;
            var loanUtil = LoanGeneratorUtil.GenerateLoan();

            var options = TestUtilities.GetOptions(nameof(FindByIdDateOfTerminalAsync_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                var loan = await actContext.LoanApplicants
                    .AddAsync(loanUtil);

                await actContext.SaveChangesAsync();

            }

            using (var assertContext = new E_MailApplicationsManagerContext(options))
            {
                var sut = new SearchService(assertContext);
                var result = sut.FindByIdAndOfEmployeeAsync(id);

                Assert.IsNotNull(result);
            }
        }
    }
}
