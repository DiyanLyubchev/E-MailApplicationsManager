using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Web.ViewComponents
{
    public class EmailViewComponent : ViewComponent
    {
        private readonly IEmailService emailService;
       // private readonly E_MailApplicationsManagerContext context;
        public EmailViewComponent(IEmailService emailService)
        {
            this.emailService = emailService;
           // this.context = context;
        }




        public async Task<IViewComponentResult> InvokeAsync()
        {
           // var db = new EmailService(context);
            var run = new ConcreteMailService(emailService);
            run.QuickStart();
            return View();
        }
    }
}
