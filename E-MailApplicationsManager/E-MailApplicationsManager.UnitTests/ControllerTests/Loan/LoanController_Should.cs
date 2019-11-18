using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.UnitTests.ControllerTests.Loan
{
    [TestClass]
    public class LoanController_Should
    {
        [TestMethod]
        public async Task LoanForm_Test()
        {
            var searchServiceMock = new Mock<ISearchService>().Object;
            var loanServiceMock = new Mock<ILoanService>().Object;
            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new LoanController(loanServiceMock, searchServiceMock,encodeDecodeServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };
            var userData = "TestName";
            var egnData = "9125654877";
            var phoneData = "0888854787";
            var idData = "12345678914";

            var result = await controller.Loanform(userData, egnData, phoneData, idData);

            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        [TestMethod]
        public async Task ListOpenStatusEmails_Test()
        {
            var searchServiceMock = new Mock<ISearchService>().Object;
            var loanServiceMock = new Mock<ILoanService>().Object;
            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new LoanController(loanServiceMock, searchServiceMock, encodeDecodeServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };            

            var result = await controller.ListOpenStatusEmails();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task LoanEmailDetails_Test()
        {
            var searchServiceMock = new Mock<ISearchService>().Object;
            var loanServiceMock = new Mock<ILoanService>().Object;
            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new LoanController(loanServiceMock, searchServiceMock, encodeDecodeServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };         
            var id = 5;

            var result = await controller.LoanEmailDetails(id);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task ApproveLoanLoanEmailDetails_ApproveDataIsNull_Test()
        {
            var searchServiceMock = new Mock<ISearchService>().Object;
            var loanServiceMock = new Mock<ILoanService>().Object;
            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new LoanController(loanServiceMock, searchServiceMock, encodeDecodeServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };

            string approveData = null;
            var rejectData = "Test Data";

            var result = await controller.ApproveLoan(approveData, rejectData);

            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        [TestMethod]
        public async Task ApproveLoanLoanEmailDetails_RejectDataIsNull_Test()
        {
            var searchServiceMock = new Mock<ISearchService>().Object;
            var loanServiceMock = new Mock<ILoanService>().Object;
            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new LoanController(loanServiceMock, searchServiceMock, encodeDecodeServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };

            var approveData = "Test Data";
            string rejectData = null;

            var result = await controller.ApproveLoan(approveData, rejectData);

            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        [TestMethod]
        public async Task GetAllFinishLoan_Test()
        {
            var searchServiceMock = new Mock<ISearchService>().Object;
            var loanServiceMock = new Mock<ILoanService>().Object;
            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new LoanController(loanServiceMock, searchServiceMock, encodeDecodeServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };

            var result = await controller.GetAllFinishLoan();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task FinishLoanDetails_Test()
        {
            var searchServiceMock = new Mock<ISearchService>().Object;
            var loanServiceMock = new Mock<ILoanService>().Object;
            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new LoanController(loanServiceMock, searchServiceMock, encodeDecodeServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };

            var id = 5;

            var result = await controller.FinishLoanDetails(id);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}