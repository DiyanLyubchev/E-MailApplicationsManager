using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.UnitTests.EmailTest
{
    [TestClass]
    public class SearchEmail_Should
    {
        [TestMethod]
        public async Task FindEmailByEmailId_Test()
        {
            var id = 2;

            var options = TestUtilities.GetOptions(nameof(FindEmailByEmailId_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.Emails.AddAsync(new Email { Id = id });
                await actContext.SaveChangesAsync();

            }


            using (var assertContext = new E_MailApplicationsManagerContext(options))
            {
                var sut = new SearchService(assertContext);
                var findEmail = await sut.FindEmailAsync(id);

                Assert.IsNotNull(findEmail);
            }

        }
    
        [TestMethod]
        public async Task GetAllEmail_Test()
        {
            var subject = "TestSubject";
            var dateReceived = "TestDateReceived";
            var sender = "TestSender";
            var gmailId = "TestgmailId";

            var subject2 = "TestSubject2";
            var dateReceived2 = "TestDateReceived2";
            var sender2 = "TestSender2";
            var gmailId2 = "TestgmailId2";

            var options = TestUtilities.GetOptions(nameof(GetAllEmail_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.Emails.AddAsync(
                     new Email
                     {
                         Sender = sender,
                         GmailId = gmailId,
                         Subject = subject,
                         DateReceived = dateReceived,
                         IsSeen = false

                     });

                await actContext.Emails.AddAsync(new Email
                      {
                          Sender = sender2,
                          DateReceived = dateReceived2,
                          Subject = subject2,
                          GmailId = gmailId2,
                          IsSeen = false
                      });

                await actContext.SaveChangesAsync();

                var sut = new SearchService(actContext);

                var result = sut.GetAllEmailsAsync();

                Assert.IsNotNull(result);
            }
        }

    }
}
