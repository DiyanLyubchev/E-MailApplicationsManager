using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Web.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.UnitTests.ControllerTests.Home
{
    [TestClass]
    public class HomeController_Should
    {
        [TestMethod]
        public async Task GetChartData_Test()
        {
            var mockSearchService = new Mock<ISearchService>().Object;

            var defaultContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal()
            };

            var controller = new HomeController(mockSearchService)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = defaultContext
                }
            };

            var result =await controller.GetChartData();

            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }
    }
}

