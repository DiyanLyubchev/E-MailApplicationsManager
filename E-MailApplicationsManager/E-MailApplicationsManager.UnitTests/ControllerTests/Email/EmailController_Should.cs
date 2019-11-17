using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Web.Controllers;
using E_MailApplicationsManager.Web.Models.Emails;
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

            var result = await controller.FillEmailBody(emailData, setInvalidEmail);

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

            var result = await controller.FillEmailBody(emailData, setInvalidEmail);

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

            var result = await controller.RefreshEmails(refreshData);

            Assert.IsInstanceOfType(result, typeof(ViewResult));

        }

        //[TestMethod]
        //public async Task CheckBody_Test()
        //{
        //    var emailServiceMock = new Mock<IEmailService>().Object;
        //    var concreteMailServiceMock = new Mock<IConcreteMailService>().Object;
        //    var searchServiceMock = new Mock<ISearchService>().Object;
        //    var encodeDecodeServiceMock = new Mock<IEncodeDecodeService>().Object;

        //    var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();
        //    firstEmail.Body = "TestBody";

        //    var defaultContext = new DefaultHttpContext()
        //    {
        //        User = new ClaimsPrincipal()
        //    };

        //    var options = TestUtilities.GetOptions(nameof(CheckBody_Test));

        //    using (var actContext = new E_MailApplicationsManagerContext(options))
        //    {
        //        var email = await actContext.Emails.AddAsync(firstEmail);

        //        await actContext.SaveChangesAsync();
        //    }

        //    var controller = new EmailController(emailServiceMock, concreteMailServiceMock,
        //    searchServiceMock, encodeDecodeServiceMock)
        //    {
        //        ControllerContext = new ControllerContext()
        //        {
        //            HttpContext = defaultContext
        //        }
        //    };

        //    var result = await controller.CheckBody(firstEmail.GmailId);

        //    var actual = new EmailBodyViewModel(firstEmail.GmailId, firstEmail.Body);

        //    Assert.IsInstanceOfType(result, typeof(ViewResult));
        //}
    }
}




