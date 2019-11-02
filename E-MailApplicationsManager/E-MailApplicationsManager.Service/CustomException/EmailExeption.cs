using System;

namespace E_MailApplicationsManager.Service.CustomException
{
    public class EmailExeption : Exception
    {
        public EmailExeption(string masege)
       : base(String.Format(masege))
        {

        }
    }
}
