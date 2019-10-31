using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_MailApplicationsManager.Service;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Web.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult RegisterAccount(RegisterAccountViewModel viewModel)
        {
            var registerAccountDto = new RegisterAccountDto
            {
                UserName = viewModel.UserName,
                Password = viewModel.Password,
                Role = viewModel.Role
            };

            this.service.RegisterAccountAsync(registerAccountDto);

            return View();
        }
    }
}