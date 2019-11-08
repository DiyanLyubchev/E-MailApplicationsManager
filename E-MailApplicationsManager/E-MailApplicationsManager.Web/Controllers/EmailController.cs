using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Web.Models.Account;
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
        private readonly ILoanService loanService;

        public EmailController(IEmailService service, IConcreteMailService concreteMailService, ISearchService searchService,
            IEncodeDecodeService encodeDecodeService, ILoanService loanService)
        {
            this.service = service;
            this.concreteMailService = concreteMailService;
            this.searchService = searchService;
            this.encodeDecodeService = encodeDecodeService;
            this.loanService = loanService;
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

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> FillEmailBody(string id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var email = await this.concreteMailService.GetEmailByIdAsync(id, userId);
            }
            catch (EmailExeption ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }
            var gmailId = new EmailBodyViewModel(id);
            return View(gmailId);
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

            var emails = (await this.searchService.GetAllUserWorkingOnEmail(baseDto))
              .Select(email => new EmailViewModel(email));

            var results = new SearchEmailViewModel(emails);

            return View("CheckMyEmail", results);
        }

        [Authorize]
        public async Task<IActionResult> FillEmailForm(string id)
        {
            try
            {
                var emailDto = new EmailContentDto
                {
                    GmailId = id
                };
                var email = await this.service.FillLoanForm(emailDto);
                var encodeBody = this.encodeDecodeService.Base64Decode(email.Body);

                var result = new EmailBodyViewModel(encodeBody);

                return View("FillEmailForm", result);
            }
            catch (EmailExeption ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<JsonResult> Loanform(string userData, string egnData, string phoneData)
        {
            try
            {
                var loanDto = new LoanApplicantDto
                {
                    Name = userData,
                    EGN = egnData,
                    PhoneNumber = phoneData,
                    userId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };

                await this.loanService.FillInFormForLoan(loanDto);
            }
            catch (LoanExeption ex)
            {

                return Json($"{ex.Message}");
            }

            return Json(new { Response = "Success" });
        }
    }
}
