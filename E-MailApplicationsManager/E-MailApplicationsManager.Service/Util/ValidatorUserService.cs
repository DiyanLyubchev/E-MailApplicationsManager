using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;

namespace E_MailApplicationsManager.Service.Util
{
    public static class ValidatorUserService
    {
        public static void ValidatorRoleName(RegisterAccountDto registerAccountDto)
        {
            if (registerAccountDto.Role != "Manager" && registerAccountDto.Role != "Operator")
            {
                throw new UserExeption("Wrong role name!");
            }
        }
        public static void ValidatorUserName(RegisterAccountDto registerAccountDto)
        {
            if (registerAccountDto.UserName.Length < 3 || registerAccountDto.UserName.Length > 50)
            {
                throw new UserExeption("Username must be betweeen 3 and 50 symbols!");
            }
        }

        public static void ValidatorPassword(RegisterAccountDto registerAccountDto)
        {
            if (registerAccountDto.Password.Length < 5 || registerAccountDto.Password.Length > 100)
            {
                throw new UserExeption("Password must be betweeen 5 and 100 symbols!");
            }
        }

        public static void ValidatorUserEmail(RegisterAccountDto registerAccountDto)
        {
            if (registerAccountDto.Email == null)
            {
                throw new UserExeption("Email cannot be null!");
            }

            if (registerAccountDto.Email.Length < 5 || registerAccountDto.Email.Length > 50)
            {
                throw new UserExeption("Email must be betweeen 5 and 50 symbols!");
            }
        }

        public static void ValidatorForExistUsername(string username , RegisterAccountDto registerAccountDto)
        {
            if (username != null)
            {
                throw new UserExeption($"You cannot register accout with the following username {registerAccountDto.UserName}");
            }
        }

        public static void ValidatorChangePassword(ChangePasswordDto changePasswordDto)
        {
            if (changePasswordDto.OldPassword == null ||
             changePasswordDto.NewPassword == null)
            {
                throw new UserExeption("Invalid password");
            }
        }

        public static void ValidatorExistUser(User user)
        {
            if (user == null)
            {
                throw new UserExeption("Incorect password");
            }
        }
    }
}

