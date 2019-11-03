using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Web.Models.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Web.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService emailService;
        private readonly IConcreteMailService concreteMailService;

        public EmailController(IEmailService emailService, IConcreteMailService concreteMailService)
        {
            this.emailService = emailService;
            this.concreteMailService = concreteMailService;
        }

        [HttpGet]
        public IActionResult GetEmailById()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult GetEmailById([FromQuery]string id)
        {
            this.concreteMailService.GetEmailById(id);

            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var email = await this.emailService.FindEmailAsync(id);

            var result = new EmailViewModel(email);

            return View(result);
        }

        public async Task<IActionResult> EmailInfo()
        {
            var words = await this.emailService.GetAllReceivedEmailAsync();

            var emailViewMOdel = new EmailListViewModel(words);

            return View(emailViewMOdel);
        }
    }
}