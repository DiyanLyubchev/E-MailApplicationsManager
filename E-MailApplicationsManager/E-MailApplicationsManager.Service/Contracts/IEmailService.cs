using E_MailApplicationsManager.Models;
using E_MailApplicationsManager.Service.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface IEmailService
    {
        void AddMail(ReceivedEmailDto emailDto);

        Task<ReceivedEmail> FindEmailAsync(int id);

        Task<IEnumerable<ReceivedEmail>> GetAllReceivedEmailAsync();
    }
}