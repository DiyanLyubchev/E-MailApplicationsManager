using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Service;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace E_MailApplicationsManager.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService service;
   

        public AccountController(IUserService service)
        {
            this.service = service;         
        }

        [HttpGet]
        public IActionResult RegisterAccount()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAccount(RegisterAccountViewModel viewModel)
        {
            var registerAccountDto = new RegisterAccountDto
            {
                UserName = viewModel.UserName,
                Password = viewModel.Password,
                Role = viewModel.Role
            };

            await this.service.RegisterAccountAsync(registerAccountDto);

            return View();
        }            
    }
}