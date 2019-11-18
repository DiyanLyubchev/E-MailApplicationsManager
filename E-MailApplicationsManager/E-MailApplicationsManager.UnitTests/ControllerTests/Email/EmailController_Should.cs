using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.UnitTests.ControllerTests.Email
{
    [TestClass]
    public class EmailController_Should
    {
        [TestMethod]
        public void ContinueWithEmmail_Test()
        {
            var emailServiceMock = new Mock<IEmailService>().Object;
            var concreteMailServiceMock = new Mock<IConcreteMailService>().Object;
            var searchServiceMock = new Mock<ISearchService>().Object;
            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new EmailController(emailServiceMock, concreteMailServiceMock,
                searchServiceMock, encodeDecodeServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };

            var result = controller.ContinueWithEmmail(firstEmail.GmailId);

            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        [TestMethod]
        public async Task Search_Test()
        {
            var emailServiceMock = new Mock<IEmailService>().Object;
            var concreteMailServiceMock = new Mock<IConcreteMailService>().Object;
            var searchServiceMock = new Mock<ISearchService>().Object;
            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();
            firstEmail.EmailStatusId = 1;

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new EmailController(emailServiceMock, concreteMailServiceMock,
            searchServiceMock, encodeDecodeServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };

            var result = await controller.Search(firstEmail.EmailStatusId.ToString());

            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        [TestMethod]
        public async Task FillEmailBody_Test()
        {
            var emailServiceMock = new Mock<IEmailService>().Object;
            var concreteMailServiceMock = new Mock<IConcreteMailService>().Object;
            var searchServiceMock = new Mock<ISearchService>().Object;
            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

            var emailData = "1 TestGmailId";
            string setInvalidEmail = null;

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new EmailController(emailServiceMock, concreteMailServiceMock,
                searchServiceMock, encodeDecodeServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };

            var result = await controller.FillEmailBodyAsync(emailData, setInvalidEmail);

            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        [TestMethod]
        public async Task FillEmailBody_SetInvalidEmail_Test()
        {
            var emailServiceMock = new Mock<IEmailService>().Object;
            var concreteMailServiceMock = new Mock<IConcreteMailService>().Object;
            var searchServiceMock = new Mock<ISearchService>().Object;
            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

            string emailData = null;
            var setInvalidEmail = "3 TestGmailId";

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new EmailController(emailServiceMock, concreteMailServiceMock,
                searchServiceMock, encodeDecodeServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };

            var result = await controller.FillEmailBodyAsync(emailData, setInvalidEmail);

            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        [TestMethod]
        public async Task RefreshEmails_Test()
        {
            var emailServiceMock = new Mock<IEmailService>().Object;
            var concreteMailServiceMock = new Mock<IConcreteMailService>().Object;
            var searchServiceMock = new Mock<ISearchService>().Object;
            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new EmailController(emailServiceMock, concreteMailServiceMock,
                searchServiceMock, encodeDecodeServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };
            var refreshData = "click";

            var result = await controller.RefreshEmailsAsync(refreshData);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task CheckMyEmail_Test()
        {
            var emailServiceMock = new Mock<IEmailService>().Object;
            var concreteMailServiceMock = new Mock<IConcreteMailService>().Object;
            var searchServiceMock = new Mock<ISearchService>().Object;
            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new EmailController(emailServiceMock, concreteMailServiceMock,
                searchServiceMock, encodeDecodeServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };

            var result = await controller.CheckMyEmailAsync();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task EmailInfoManager_Test()
        {
            var emailServiceMock = new Mock<IEmailService>().Object;
            var concreteMailServiceMock = new Mock<IConcreteMailService>().Object;
            var searchServiceMock = new Mock<ISearchService>().Object;
            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new EmailController(emailServiceMock, concreteMailServiceMock,
                searchServiceMock, encodeDecodeServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };

            var result = await controller.EmailInfoManagerAsync();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task ChangeEmailStatus_Test()
        {
            var emailServiceMock = new Mock<IEmailService>().Object;
            var concreteMailServiceMock = new Mock<IConcreteMailService>().Object;
            var searchServiceMock = new Mock<ISearchService>().Object;
            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

            string emailData = "TestGmailId";
            var setInvalidEmail = "1";

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new EmailController(emailServiceMock, concreteMailServiceMock,
                searchServiceMock, encodeDecodeServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };

            var result = await controller.ChangeEmailStatusAsync(emailData, setInvalidEmail);

            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        [TestMethod]
        public async Task DetailsManager_Test()
        {
            var emailServiceMock = new Mock<IEmailService>().Object;
            var concreteMailServiceMock = new Mock<IConcreteMailService>().Object;
            var searchServiceMock = new Mock<ISearchService>().Object;
            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

            var id = 1;

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new EmailController(emailServiceMock, concreteMailServiceMock,
                searchServiceMock, encodeDecodeServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };

            var result = await controller.DetailsManagerAsync(id);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task Details_Test()
        {
            var emailServiceMock = new Mock<IEmailService>().Object;
            var concreteMailServiceMock = new Mock<IConcreteMailService>().Object;
            var searchServiceMock = new Mock<ISearchService>().Object;
            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

            var id = 1;

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new EmailController(emailServiceMock, concreteMailServiceMock,
                searchServiceMock, encodeDecodeServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };

            var result = await controller.DetailsAsync(id);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task EmailInfo_Test()
        {
            var emailServiceMock = new Mock<IEmailService>().Object;
            var concreteMailServiceMock = new Mock<IConcreteMailService>().Object;
            var searchServiceMock = new Mock<ISearchService>().Object;
            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new EmailController(emailServiceMock, concreteMailServiceMock,
                searchServiceMock, encodeDecodeServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };

            var result = await controller.EmailInfoAsync();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void Home_Test()
        {
            var emailServiceMock = new Mock<IEmailService>().Object;
            var concreteMailServiceMock = new Mock<IConcreteMailService>().Object;
            var searchServiceMock = new Mock<ISearchService>().Object;
            var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new EmailController(emailServiceMock, concreteMailServiceMock,
                searchServiceMock, encodeDecodeServiceMock)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };

            var result = controller.Home();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}




