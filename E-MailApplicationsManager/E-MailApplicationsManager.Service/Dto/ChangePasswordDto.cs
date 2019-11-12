using System;
using System.Collections.Generic;
using System.Text;

namespace E_MailApplicationsManager.Service.Dto
{
    public class ChangePasswordDto
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string UserId { get; set; }

    }
}
