using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using E_MailApplicationsManager.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using E_MailApplicationsManager.Models.Context;
using Microsoft.EntityFrameworkCore;
using E_MailApplicationsManager.Web.Areas.Identity.Pages.Account.Manage;
using E_MailApplicationsManager.Models.Model;
using System;
using E_MailApplicationsManager.Service.Service;

namespace E_MailApplicationsManager.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly UserManager<User> _userManager;
        private readonly ILogService _logService;

        public LoginModel(SignInManager<User> signInManager, ILogger<LoginModel> logger,
            UserManager<User> userManager, ILogService logService)
        {
            _signInManager = signInManager;
            _logger = logger;
            _userManager = userManager;
            _logService = logService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string UserName { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");


            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            var login = await _userManager
                .FindByNameAsync(Input.UserName);

            if (login == null)
            {
                return LocalRedirect("~/identity/account/login");
            }

            if (ModelState.IsValid && login != null)
            {
                var result = await _signInManager
                    .PasswordSignInAsync(Input.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: true);

                if (login.FirstLog == false)
                {
                    return RedirectToAction("ChangeAccountPassword", "Account");
                }

                if (result.Succeeded)
                {
                    await _logService.SaveLastLoginUser(login);
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
                if (result.RequiresTwoFactor)
                {

                    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }


            return Page();
        }
    }
}
