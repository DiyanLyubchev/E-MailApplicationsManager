using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
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
        private readonly IEncodeDecodeService encodeDecodeService;

        public EmailController(IEmailService service, IConcreteMailService concreteMailService, ISearchService searchService,
            IEncodeDecodeService encodeDecodeService)
        {
            this.service = service;
            this.concreteMailService = concreteMailService;
            this.searchService = searchService;
            this.encodeDecodeService = encodeDecodeService;
        }


        [Authorize]
        public  IActionResult Home()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Search([FromQuery]string status)
        {
            var statusDto = new EmailStatusIdDto
            {
                StatusId = status
            };

            var emailStatus = await this.searchService.SearchEamilByStatusIdAsync(statusDto);

            return Json(emailStatus);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> FillEmailBody(string emailData, string setInvalidEmail)
        {

            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (emailData != null)
                {
                    var email = await this.concreteMailService.GetEmailByIdAsync(emailData, userId);
                }
                else if (setInvalidEmail != null)
                {
                    var dto = new StatusInvalidApplicationDto
                    {
                        GmailId = setInvalidEmail,
                        UserId = userId,
                    };
                    await this.service.SetEmailStatusInvalidApplicationAsync(dto);

                    return Json(new { emailId = emailData });
                }

            }
            catch (EmailExeption ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }

            return Json(new { emailId = emailData });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> CheckBody(string id)
        {
            try
            {
                var emailDto = new EmailContentDto
                {
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                    GmailId = id
                };
                var email = await this.service.CheckEmailBodyAsync(emailDto);
                var decodeBody = this.encodeDecodeService.Base64Decode(email.Body);

                var result = new EmailBodyViewModel(id, decodeBody);

                return View("CheckBody", result);
            }
            catch (EmailExeption ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }
        }

        [Authorize]
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

        [Authorize]
        public async Task<IActionResult> EmailInfo()
        {
            var emails = await this.searchService.GetAllEmailsAsync();

            var libraryViewModel = new EmailListViewModel(emails);

            return View(libraryViewModel);
        }

        [Authorize]
        public async Task<IActionResult> CheckMyEmail()
        {
            var baseDto = new EmailContentDto
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            var emails = (await this.searchService.GetAllUserWorkingOnEmailAsync(baseDto))
              .Select(email => new EmailViewModel(email));

            var results = new SearchEmailViewModel(emails);

            return View("CheckMyEmail", results);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> FillEmailForm(string id)
        {
            try
            {
                var emailDto = new EmailContentDto
                {
                    GmailId = id
                };
                var email = await this.service.TakeBodyAsync(emailDto);
                var encodeBody = this.encodeDecodeService.Base64Decode(email.Body);

                var result = new EmailBodyViewModel(id, encodeBody);

                return View("FillEmailForm", result);
            }
            catch (EmailExeption ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }
        }

        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DetailsManager(int id)
        {
            var email = await this.searchService.FindEmailAsync(id);
            if (email == null)
            {
                return View("Message", new MessageViewModel { Message = "The email was not found!" });
            }

            var result = new EmailViewModel(email);

            return View(result);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangeEmailStatus(string statusData, string idData)
        {
            try
            {
                var statusdto = new EmailStatusIdDto
                {
                    GmailId = idData,
                    StatusId = statusData,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };

                var emailStatus = await this.service.ChangeStatusAsync(statusdto);
                return Json(emailStatus);
            }
            catch (EmailExeption ex)
            {

                return View("Message", new MessageViewModel { Message = ex.Message });
            }
        }

        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> EmailInfoManager()
        {
            var emails = await this.searchService.GetAllEmailsForManagerAsync();

            var libraryViewModel = new EmailListViewModel(emails);

            return View(libraryViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RefreshEmails(string refreshData)
        {
            if (refreshData == "click")
            {
               await this.concreteMailService.QuickStartAsync();
            }

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult ContinueWithEmmail(string currentEmailId)
        {
            return Json(new { emailId = currentEmailId });
        }
    }
}
