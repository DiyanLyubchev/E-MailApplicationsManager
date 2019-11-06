using System.Security.Claims;
using System.Threading.Tasks;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Web.Models.Emails;
using E_MailApplicationsManager.Web.Models.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_MailApplicationsManager.Web.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService service;
        private readonly IConcreteMailService concreteMailService;
        private readonly ISearchService searchService;

        public EmailController(IEmailService service, IConcreteMailService concreteMailService, ISearchService searchService)
        {
            this.service = service;
            this.concreteMailService = concreteMailService;
            this.searchService = searchService;
        }

        [Authorize]
        public IActionResult Home()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Search([FromQuery]string name)
        {
            var words = await this.searchService.GetAllEmailAsync(name);

            return Json(words);
        }
        [Authorize]
        [HttpGet]
        public IActionResult FillEmailsBody()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> FillEmailsBody(EmailBodyViewModel viewModel)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var email = await this.concreteMailService.GetEmailByIdAsync(viewModel.GmailId, userId);
                return Json(email.Body);
            }
            catch (EmailExeption ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }
            //TODO: View 
        }

        public async Task<IActionResult> Details(int id)
        {
            var email = await this.searchService.FindEmailAsync(id);
            if (email == null)
            {
                return View("Message", new MessageViewModel { Message = "The email was not found!" });
            }

            var result = new EmailViewModel(email);

            return View(result);
        }

        public async Task<IActionResult> EmailInfo()
        {
            var emails = await this.searchService.GetAllEmailsAsync();

            var libraryViewModel = new EmailListViewModel(emails);

            return View(libraryViewModel);
        }
    }
}