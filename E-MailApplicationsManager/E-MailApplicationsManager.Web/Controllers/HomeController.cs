using E_MailApplicationsManager.Models.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Web.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return LocalRedirect("~/identity/account/login");
            }
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetChartData()
        {
            var emailStatus = new EmailStatus();
            emailStatus.Id = 0;
            emailStatus.Status = "testStatus";
            emailStatus.Emails = new List<Email>();
            emailStatus.Emails.Add(new Email());
            emailStatus.Emails.Add(new Email());
            emailStatus.Emails.Add(new Email());
            emailStatus.Emails.Add(new Email());
            emailStatus.Emails.Add(new Email());
            emailStatus.Emails.Add(new Email());

            var emailStatus2 = new EmailStatus();
            emailStatus2.Id = 1;
            emailStatus2.Status = "testStatus2";
            emailStatus2.Emails = new List<Email>();
            emailStatus2.Emails.Add(new Email());
            emailStatus2.Emails.Add(new Email());

            var emailStatus3 = new EmailStatus();
            emailStatus3.Id = 2;
            emailStatus3.Status = "testStatus";
            emailStatus3.Emails = new List<Email>();
            emailStatus3.Emails.Add(new Email());
            emailStatus3.Emails.Add(new Email());
            emailStatus3.Emails.Add(new Email());
            emailStatus3.Emails.Add(new Email());
            emailStatus3.Emails.Add(new Email());
            emailStatus3.Emails.Add(new Email());
            emailStatus3.Emails.Add(new Email());
            emailStatus3.Emails.Add(new Email());
            emailStatus3.Emails.Add(new Email());
            emailStatus3.Emails.Add(new Email());
            emailStatus3.Emails.Add(new Email());
            emailStatus3.Emails.Add(new Email());
            emailStatus3.Emails.Add(new Email());
            emailStatus3.Emails.Add(new Email());
            emailStatus3.Emails.Add(new Email());
            emailStatus3.Emails.Add(new Email());


            var list = new List<EmailStatus>();
            list.Add(emailStatus);
            list.Add(emailStatus2);
            list.Add(emailStatus3);
            return Json(list);
        }

    }
}
