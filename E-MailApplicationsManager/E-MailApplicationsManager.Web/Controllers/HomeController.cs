using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using E_MailApplicationsManager.Web.Models;
using E_MailApplicationsManager.Service.Service;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Models.Context;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConcreteMailService concreteMailService;

        public HomeController(IConcreteMailService concreteMailService)
        {
            this.concreteMailService = concreteMailService;
        }

        public IActionResult Index()
        {
            this.concreteMailService.QuickStart();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
