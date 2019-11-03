using E_MailApplicationsManager.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace E_MailApplicationsManager.UnitTests
{
    public static class TestUtilities
    {
        public static DbContextOptions<E_MailApplicationsManagerContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<E_MailApplicationsManagerContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }
    }
}
