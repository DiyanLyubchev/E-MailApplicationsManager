using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Web.Controllers;
using E_MailApplicationsManager.Web.Models;
using E_MailApplicationsManager.Web.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.UnitTests.ControllerTests
{
    [TestClass]
    public class AccountController_Should
    {
        [TestMethod]
        public void RegisterAccount_Test()
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

        [TestMethod]
        public async Task RegisterAccountPost_Test()
        {
            var userWebService = new Mock<IUserService>();

            var userName = "Test Username";
            var password = "Test Password";
            var email = "Test Email";
            var role = "Operator";

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

            var registerAccountViewModel = new RegisterAccountViewModel
            {
                UserName = userName,
                Password = password,
                Email = email,
                Role = role
            };

            var result = await controller.RegisterAccount(registerAccountViewModel);

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public void ChangeAccountPassword_Test()
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

            var result = controller.ChangeAccountPassword();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }

        [TestMethod]
        public async Task ChangePasswordPost_Test()
        {
            var userWebService = new Mock<IUserService>();

            var oldPassword = "OldTestPass";
            var newPassword = "NewTestPass";

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

            var changePasswordViewModel = new ChangePasswordViewModel
            {
                OldPassword = oldPassword,
                NewPassword = newPassword 
            };

            var result = await controller.ChangeAccountPassword(changePasswordViewModel);

            Assert.IsInstanceOfType(result, typeof(RedirectToActionResult));
        }
    }
}