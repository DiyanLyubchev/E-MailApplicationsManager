using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Service;
using E_MailApplicationsManager.UnitTests.Util;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace E_MailApplicationsManager.UnitTests.EncodeDecodeTest
{
    [TestClass]
    public class EncodeDecode_Should
    {
        [TestMethod]
        public void Decode_Test()
        {
            var test = "MDk4OS8yNTUtMzQ1";

            var sut = new EncodeDecodeService();
            var result = sut.Base64Decode(test);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Encode_Test()
        {
            var test = "TestName";

            var sut = new EncodeDecodeService();
            var result = sut.Base64Encode(test);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DecodeLoanApplicant_Test()
        {
            var loanEncode = LoanAplicantEncodeUtil.GenerateLoanApplicantEncode();

            var sut = new EncodeDecodeService();
            var result = sut.DecodeLoanApplicant(loanEncode);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void DecodeLoanApplicantList_Test()
        {
            var listLoan = new List<LoanApplicant>();

            var loanEncode = LoanAplicantEncodeUtil.GenerateLoanApplicantEncode();

            for (int i = 0; i < 2; i++)
            {
                listLoan.Add(loanEncode);
            }

            var sut = new EncodeDecodeService();

            var result = sut.DecodeLoanApplicantList(listLoan);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ReplaseSign_Test()
        {
            var test = "++4O__";

            var sut = new EncodeDecodeService();
            var result = sut.ReplaceSign(test);

            Assert.IsNotNull("--40//",result);
        }

        [TestMethod]
        public void Encrypt_Test()
        {
            var test = "testName";

            var sut = new EncodeDecodeService();

            var result = sut.Encrypt(test);

            Assert.AreNotEqual(test, result);
        }

        [TestMethod]
        public void Decrypt_Test()
        {
            var test = "CWH8UP++GqTltbMfA8MSxcCoU5GBP37sx9t0XlXPhsA=";

            var sut = new EncodeDecodeService();

            var result = sut.Decrypt(test);

            Assert.AreNotEqual(test, result);
        }
    }
}
