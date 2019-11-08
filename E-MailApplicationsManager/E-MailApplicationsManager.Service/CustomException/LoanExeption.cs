using System;
using System.Collections.Generic;
using System.Text;

namespace E_MailApplicationsManager.Service.CustomException
{
    public class LoanExeption : Exception
    {
        public LoanExeption(string masege)
     : base(String.Format(masege))
        {

        }
    }
}
