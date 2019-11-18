using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
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
            var validationMethod = ValidationMethod(registerAccountDto);

            var user = await this.context.Users
                .Where(name => name.UserName == validationMethod.UserName)
                .Select(username => username.UserName)
                .SingleOrDefaultAsync();

            if (user != null)
            {
                throw new UserExeption($"You cannot register accout with the following username {validationMethod.UserName}");
            }

            var passwordHasher = new PasswordHasher<User>();

            var account = new User
            {
                UserName = validationMethod.UserName,
                NormalizedUserName = validationMethod.UserName.ToUpper(),
                LockoutEnabled = true,
                Email = validationMethod.Email,
                NormalizedEmail = validationMethod.Email.ToUpper()
            };
            account.PasswordHash = passwordHasher.HashPassword(account, validationMethod.Password);

            await this.userManager.CreateAsync(account);
            await this.userManager.AddToRoleAsync(account, validationMethod.Role);

            var currentUser = await this.context.Users
                .Where(userId => userId.Id == validationMethod.CurrentUserId)
                .Select(uName => uName.UserName)
                .SingleOrDefaultAsync();

            logger.LogInformation($"New user {validationMethod.UserName} registered by {currentUser}");
        }

        public async Task<User> GetUserAsync(string userId)
        {
            var user = await this.context.Users
                .FirstOrDefaultAsync(u => u.Id == userId);

            return user;
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordDto changePasswordDto)
        {
            if (changePasswordDto.OldPassword == null ||
                changePasswordDto.NewPassword == null)
            {
                throw new UserExeption("Invalid password");
            }

            var user = await this.context.Users
                .Where(userPaswword => userPaswword.Id == changePasswordDto.UserId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                throw new UserExeption("Incorect password");
            }
            var passwordHasher = new PasswordHasher<User>();

            user.PasswordHash = user.PasswordHash = passwordHasher.HashPassword(user, changePasswordDto.NewPassword);
            user.FirstLog = true;

            await this.context.SaveChangesAsync();

            return true;
        }

        public RegisterAccountDto ValidationMethod(RegisterAccountDto registerAccountDto)
        {
            if (registerAccountDto.Role != "Manager" && registerAccountDto.Role != "Operator")
            {
                throw new UserExeption("Wrong role name!");
            }

            if (registerAccountDto.UserName.Length < 3 || registerAccountDto.UserName.Length > 50)
            {
                throw new UserExeption("Username must be betweeen 3 and 50 symbols!");
            }

            if (registerAccountDto.Password.Length < 5 || registerAccountDto.Password.Length > 100)
            {
                throw new UserExeption("Password must be betweeen 5 and 100 symbols!");
            }

            if (registerAccountDto.Email == null)
            {
                throw new UserExeption("Email cannot be null!");
            }

            if (registerAccountDto.Email.Length < 5 || registerAccountDto.Email.Length > 50)
            {
                throw new UserExeption("Email must be betweeen 5 and 50 symbols!");
            }

            return registerAccountDto;
        }
    }
}

