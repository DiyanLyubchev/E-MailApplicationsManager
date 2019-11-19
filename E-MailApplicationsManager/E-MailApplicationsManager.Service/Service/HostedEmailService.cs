using E_MailApplicationsManager.Service.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Service
{
    public class HostedEmailService : IHostedService
    {
        private readonly IServiceProvider serviceProvider;
        private Timer timer;

        public HostedEmailService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            this.timer = new Timer(GetEmails, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(60));

            return Task.CompletedTask;
        }

        private async void GetEmails(object state)
        {
            using (var scope = this.serviceProvider.CreateScope())
            {
                var checkForNewEmailService = scope.ServiceProvider.GetRequiredService<IConcreteMailService>();

                await checkForNewEmailService.QuickStartAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            this.timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }
    }
}
