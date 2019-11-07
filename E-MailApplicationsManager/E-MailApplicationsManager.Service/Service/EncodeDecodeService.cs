using E_MailApplicationsManager.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace E_MailApplicationsManager.Service.Service
{
    public class EncodeDecodeService : IEncodeDecodeService
    {

        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
