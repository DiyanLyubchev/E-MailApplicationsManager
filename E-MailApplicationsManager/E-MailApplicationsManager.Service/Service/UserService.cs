using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.Dto;
using E_MailApplicationsManager.Service.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Service
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> logger;
        private readonly E_MailApplicationsManagerContext context;
        private readonly UserManager<User> userManager;

        public UserService(E_MailApplicationsManagerContext context, UserManager<User> userManager, ILogger<UserService> logger)
        {
            this.context = context;
            this.userManager = userManager;
            this.logger = logger;
        }

        public async Task RegisterAccountAsync(RegisterAccountDto registerAccountDto)
        {
            ValidatorUserService.ValidatorRoleName(registerAccountDto);
            ValidatorUserService.ValidatorUserName(registerAccountDto);
            ValidatorUserService.ValidatorPassword(registerAccountDto);
            ValidatorUserService.ValidatorUserEmail(registerAccountDto);

            var user = await this.context.Users
                .Where(name => name.UserName == registerAccountDto.UserName)
                .Select(username => username.UserName)
                .SingleOrDefaultAsync();

            ValidatorUserService.ValidatorForExistUsername(user, registerAccountDto);

            var passwordHasher = new PasswordHasher<User>();

            var account = new User
            {
                UserName = registerAccountDto.UserName,
                NormalizedUserName = registerAccountDto.UserName.ToUpper(),
                LockoutEnabled = true,
                Email = registerAccountDto.Email,
                NormalizedEmail = registerAccountDto.Email.ToUpper()
            };
            account.PasswordHash = passwordHasher.HashPassword(account, registerAccountDto.Password);

            await this.userManager.CreateAsync(account);
            await this.userManager.AddToRoleAsync(account, registerAccountDto.Role);

            var currentUser = await this.context.Users
                .Where(userId => userId.Id == registerAccountDto.CurrentUserId)
                .Select(uName => uName.UserName)
                .SingleOrDefaultAsync();

            logger.LogInformation($"New user {registerAccountDto.UserName} registered by {currentUser}");
        }

        public async Task<User> GetUserAsync(string userId)
        {
            var user = await this.context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            return user;
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordDto changePasswordDto)
        {
            ValidatorUserService.ValidatorChangePassword(changePasswordDto);

            var user = await this.context.Users
                .Where(userPaswword => userPaswword.Id == changePasswordDto.UserId)
                .FirstOrDefaultAsync();

            ValidatorUserService.ValidatorExistUser(user);

            var passwordHasher = new PasswordHasher<User>();

            user.PasswordHash = user.PasswordHash = passwordHasher.HashPassword(user, changePasswordDto.NewPassword);
            user.FirstLog = true;

            await this.context.SaveChangesAsync();

            return true;
        }
    }
}

