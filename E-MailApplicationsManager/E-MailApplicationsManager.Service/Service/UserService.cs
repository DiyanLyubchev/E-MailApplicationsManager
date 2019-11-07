using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Service
{
    public class UserService : IUserService
    {
        private readonly E_MailApplicationsManagerContext context;
        private readonly UserManager<User> userManager;

        public UserService(E_MailApplicationsManagerContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task RegisterAccountAsync(RegisterAccountDto registerAccountDto)
        {
            if (registerAccountDto.Role != "Manager" && registerAccountDto.Role != "Operator")
            {
                throw new UserExeption("Wrong role name!");
            }

            if (registerAccountDto.UserName.Length < 3)
            {
                throw new UserExeption("Username cannotbe less that 3 symbols!");
            }

            if (registerAccountDto.Password.Length < 5)
            {
                throw new UserExeption("Password cannot be less than 5 symbols!");
            }

            var passwordHasher = new PasswordHasher<User>();

            var account = new User
            {
                UserName = registerAccountDto.UserName,
                NormalizedUserName = registerAccountDto.UserName.ToUpper(),
                LockoutEnabled = true
            };
            account.PasswordHash = passwordHasher.HashPassword(account, registerAccountDto.Password);

            await this.userManager.CreateAsync(account);
            await this.userManager.AddToRoleAsync(account, registerAccountDto.Role);
        }

        public async Task<User> GetUserAsync(string userId)
        {
            var user = await this.context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            return user;
        }
    }
}

