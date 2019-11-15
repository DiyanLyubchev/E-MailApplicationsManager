using System;
using System.Collections.Generic;
using System.Text;

namespace E_MailApplicationsManager.Service.Dto
{
    public class RegisterAccountDto
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string CurrentUserId { get; set; }
    }
}
