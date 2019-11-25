using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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

            var controller = new HomeController(mockSearchService);

            var result =await controller.GetChartData();

            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }

        [TestMethod]
        public void NotFoundPage_Test()
        {
            var mockSearchService = new Mock<ISearchService>().Object;

            var controller = new HomeController(mockSearchService);

            var result =  controller.NotFoundPage();

            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}

