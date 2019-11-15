using System.Security.Claims;
using System.Threading.Tasks;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Web.Models;
using E_MailApplicationsManager.Web.Models.Account;
using E_MailApplicationsManager.Web.Models.Message;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Manager")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAccount(RegisterAccountViewModel viewModel)
        {
            try
            {
                var registerAccountDto = new RegisterAccountDto
                {
                    UserName = viewModel.UserName,
                    Password = viewModel.Password,
                    Email = viewModel.Email,
                    Role = viewModel.Role
                };

                await this.service.RegisterAccountAsync(registerAccountDto);

            }
            catch (UserExeption ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }

            return View("Message", new MessageViewModel
            {
                Message = $"Successful registration",

                IsSuccess = true
            });
        }

        [HttpGet]
        public IActionResult ChangeAccountPassword()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ChangeAccountPassword(ChangePasswordViewModel viewModel)
        {
            try
            {
                var passwordDto = new ChangePasswordDto
                {
                    OldPassword = viewModel.OldPassword,
                    NewPassword = viewModel.NewPassword,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };

                await this.service.ChangePasswordAsync(passwordDto);

            }
            catch (UserExeption ex)
            {
                return View("Message", new MessageViewModel { Message = ex.Message });
            }

            return RedirectToAction("Index","Home");
        }

    }
}