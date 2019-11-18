using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(E_MailApplicationsManager.Web.Areas.Identity.IdentityHostingStartup))]
namespace E_MailApplicationsManager.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}