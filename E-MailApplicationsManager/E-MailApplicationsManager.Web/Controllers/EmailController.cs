using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_MailApplicationsManager.Service.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_MailApplicationsManager.Web.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService service;

        public EmailController(IEmailService service)
        {
            this.service = service;
        }

        [Authorize]
        public IActionResult Home()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Search([FromQuery]string name)
        {
            var words =await this.service.GetAllEmailAsync(name);

            return Json(words);
        }
    }
}