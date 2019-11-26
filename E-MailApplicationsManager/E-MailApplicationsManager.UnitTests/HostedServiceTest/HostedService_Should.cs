using E_MailApplicationsManager.Service.Service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.UnitTests.HostedServiceTest
{
    [TestClass]
    public class HostedService_Should
    {
        [TestMethod]
        public async Task HostedEmailService_Run_Test()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddHostedService<HostedEmailService>();

            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetService<IHostedService>() as HostedEmailService;

            var isExecuted = false;
            if (service.StartAsync(CancellationToken.None).IsCompleted)
            {
                isExecuted = true;
            }
            await Task.Delay(100);
            Assert.IsTrue(isExecuted);
        }

        [TestMethod]
        public async Task HostedEmailService_Stop_Test()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddHostedService<HostedEmailService>();

            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetService<IHostedService>() as HostedEmailService;

            var isExecuted = false;
            if (service.StopAsync(CancellationToken.None).IsCompleted)
            {
                isExecuted = true;
            }
            await Task.Delay(100);
            Assert.IsTrue(isExecuted);
        }

    }
}
