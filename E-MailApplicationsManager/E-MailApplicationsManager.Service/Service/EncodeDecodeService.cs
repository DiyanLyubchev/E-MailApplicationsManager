using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
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

        public LoanApplicant DecodeLoanApplicant(LoanApplicant loanApplicant)
        {
            var name = Decrypt(loanApplicant.Name);
            var egn = Decrypt(loanApplicant.EGN);
            var phoneNumber = Decrypt(loanApplicant.PhoneNumber);

            var loan = new LoanApplicant
            {
                Name = name,
                EGN = egn,
                PhoneNumber = phoneNumber,
                GmailId = loanApplicant.GmailId
            };

            return loan;
        }

        public IEnumerable<LoanApplicant> DecodeLoanApplicantList(IEnumerable<LoanApplicant> loanApplicant)
        {
            var loan = new List<LoanApplicant>();

            foreach (var item in loanApplicant)
            {
                var name = Decrypt(item.Name);
                loan.Add(new LoanApplicant { Name = name, Id = item.Id });
            }
            return loan;
        }

        public string ReplaceSign(string body)
        {
            string codedBody = body.Replace("-", "+");
            codedBody = codedBody.Replace("_", "/");

            return codedBody;
        }
        public string Encrypt(string clearText)
        {
            string EncryptionKey = "abc123";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "abc123";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}

