using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using E_MailApplicationsManager.Web.Models;
using E_MailApplicationsManager.Service.Service;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Models.Context;

namespace E_MailApplicationsManager.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailService emailService;
        private readonly E_MailApplicationsManagerContext context;

        public HomeController(IEmailService emailService, E_MailApplicationsManagerContext context)
        {
            this.emailService = emailService;
            this.context = context;
        }

        public IActionResult Index()
        {
            var db = new EmailService(context);
            var run = new ConcreteMailService(emailService);
            run.QuickStart();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
