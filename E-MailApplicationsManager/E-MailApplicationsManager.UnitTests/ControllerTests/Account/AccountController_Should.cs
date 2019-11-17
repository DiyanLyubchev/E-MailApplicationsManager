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

namespace E_MailApplicationsManager.UnitTests.ControllerTests
{
    [TestClass]
    public class AccountController_Should
    {
        [TestMethod]
        public void RegisterAccount()
        {
            var userWebService = new Mock<IUserService>();

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new AccountController(userWebService.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };

            var result = controller.RegisterAccount();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
