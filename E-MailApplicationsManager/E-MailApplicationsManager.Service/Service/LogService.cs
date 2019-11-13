using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Models.Model;
using System;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Service
{
    public class LogService : ILogService
    {
        private readonly E_MailApplicationsManagerContext context;

        public LogService(E_MailApplicationsManagerContext context)
        {
            this.context = context;
        }

        public async Task<bool> SaveLastLoginUser(User user)
        {
            if (user == null)
            {
                return false;
            }

            user.LastLog = DateTime.Now;
            await this.context.SaveChangesAsync();

            return true;
        }

    }
}
