using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Web.Models.Email;
using E_MailApplicationsManager.Web.Models.Message;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_MailApplicationsManager.Web.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService service;
        private readonly IConcreteMailService concreteMailService;

        public EmailController(IEmailService service, IConcreteMailService concreteMailService)
        {
            this.service = service;
            this.concreteMailService = concreteMailService;
        }

        [Authorize]
        public IActionResult Home()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Search([FromQuery]string name)
        {
            var words = await this.service.GetAllEmailAsync(name);

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
    }
}