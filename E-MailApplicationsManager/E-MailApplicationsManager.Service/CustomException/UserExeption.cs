using System;
using System.Collections.Generic;
using System.Text;

namespace E_MailApplicationsManager.Service.CustomException
{
    public class UserExeption : Exception
    {
        public UserExeption(string masege)
        : base(String.Format(masege))
        {
        }
    }
}
