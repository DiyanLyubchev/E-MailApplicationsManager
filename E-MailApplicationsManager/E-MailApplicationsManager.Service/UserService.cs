using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service
{
    public class UserService : IUserService
    {
        private readonly E_MailApplicationsManagerContext context;

        public UserService(E_MailApplicationsManagerContext context)
        {
            this.context = context;
        }

        public void RegisterAccountAsync(RegisterAccountDto registerAccountDto)
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

            var userRole = this.context.Roles
                .Where(role => role.Name == registerAccountDto.Role)
                .Select(r => r.Id)
                .ToString();

            var account = new User
            {
                UserName = registerAccountDto.UserName,
                PasswordHash = registerAccountDto.Password,
                NormalizedUserName = registerAccountDto.UserName.ToUpper(),
                LockoutEnabled = true
            };
            
            var newAccount = new IdentityUserRole<string>
            { UserId = account.Id, RoleId = userRole };

            this.context.Users.Add(account);
            this.context.SaveChanges();
        }
    }
}

