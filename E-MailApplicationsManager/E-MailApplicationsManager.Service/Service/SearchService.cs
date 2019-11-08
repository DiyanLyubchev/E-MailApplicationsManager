using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Models.Common;
using E_MailApplicationsManager.Models.Context;
using E_MailApplicationsManager.Service.Contracts;
using E_MailApplicationsManager.Service.CustomException;
using E_MailApplicationsManager.Service.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Service
{
    public class SearchService : ISearchService
    {
        private readonly E_MailApplicationsManagerContext context;

        public SearchService(E_MailApplicationsManagerContext context)
        {
            this.context = context;
        }


        public async Task<IEnumerable<Email>> GetAllEmailAsync(string name)
        {
            var emailList = await this.context.Emails
               .Where(mail => mail.Sender.Contains(name))
               .Select(email => email)
               .ToListAsync();

            return emailList;
        }

        public async Task<Email> FindEmailAsync(int id)
        {
            return await this.context.Emails
                 .FirstOrDefaultAsync(email => email.Id == id);
        }

        public async Task<IEnumerable<Email>> GetAllEmailsAsync()
        {
            return await this.context.Emails
                .Where(email => email.IsSeen == false)
                .OrderBy(email => email.DateReceived)
                .ToListAsync();
        }

        public async Task<IEnumerable<Email>> GetAllUserWorkingOnEmail(EmailContentDto userIdDto)
        {
            var userId = await this.context.Users
                .FirstOrDefaultAsync(uId => uId.Id == userIdDto.UserId);

            var email = await this.context.Emails
                .Include(u => u.User)
                .Where(workingOnEmail => workingOnEmail.UserId == userIdDto.UserId 
                && workingOnEmail.EmailStatusId != (int)EmailStatusesType.Closed)
                .Select(emails => emails)
                .ToListAsync();
           
            return email;
        }
    }
}
