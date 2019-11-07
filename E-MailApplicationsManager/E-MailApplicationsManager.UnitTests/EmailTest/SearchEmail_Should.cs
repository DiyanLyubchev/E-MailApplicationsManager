using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
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
            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var secondEmail = EmailGeneratorUtil.GenerateEmailSecond();

            var options = TestUtilities.GetOptions(nameof(GetAllEmail_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.Emails.AddAsync(firstEmail);

                await actContext.Emails.AddAsync(secondEmail);

                await actContext.SaveChangesAsync();

                var sut = new SearchService(actContext);

                var result = sut.GetAllEmailsAsync();

                Assert.IsNotNull(result);
            }
        }

        [TestMethod]
        public async Task GetAllUserWorkingOnEmail_Test()
        {
            var firstEmail = EmailGeneratorUtil.GenerateEmailFirst();

            var secondEmail = EmailGeneratorUtil.GenerateEmailSecond();

            var userId = secondEmail.UserId;

            var emailContentDto = new EmailContentDto
            {
                UserId = userId
            };

            var options = TestUtilities.GetOptions(nameof(GetAllUserWorkingOnEmail_Test));

            using (var actContext = new E_MailApplicationsManagerContext(options))
            {
                await actContext.Emails.AddAsync(firstEmail);

                await actContext.Emails.AddAsync(secondEmail);

                await actContext.SaveChangesAsync();

                var sut = new SearchService(actContext);

                var result = sut.GetAllUserWorkingOnEmail(emailContentDto);

                Assert.IsNotNull(result);
            }
        }
    }
}
