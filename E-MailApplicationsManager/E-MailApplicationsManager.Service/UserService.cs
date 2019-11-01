﻿using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service
{
    public class UserService : IUserService
    {
        private readonly E_MailApplicationsManagerContext context;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public UserService(E_MailApplicationsManagerContext context, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task RegisterAccountAsync(RegisterAccountDto registerAccountDto)
        {
            if (registerAccountDto.Role != "Manager" && registerAccountDto.Role != "Operator")
            {
                throw new Exception("Wrong role name!");
            }

            if (registerAccountDto.UserName == null)
            {
                throw new Exception("Please enter a username");
            }

            if (registerAccountDto.Password.Length < 5)
            {
                throw new Exception("Password cannot be less than 5 symbols");
            }

            var passwordHasher = new PasswordHasher<User>();

            var account = new User
            {
                UserName = registerAccountDto.UserName,
                NormalizedUserName = registerAccountDto.UserName.ToUpper(),
                LockoutEnabled = true
            };
            account.PasswordHash = passwordHasher.HashPassword(account, registerAccountDto.Password);
            var userRole = new RoleUser { Name = registerAccountDto.Role };

            var newAccount = new IdentityUserRole<string>
            { UserId = account.Id, RoleId = userRole.Id };

            await _userManager.CreateAsync(account);
            //await this.context.Users.AddAsync(account);
            //await this.context.SaveChangesAsync();
            await _userManager.AddToRoleAsync(account, registerAccountDto.Role);
        }

        public async Task<User> GetUserAsync(string userId)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            return user;
        }       
    }
}

