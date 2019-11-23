using E_MailApplicationsManager.Models.Model;
using E_MailApplicationsManager.Service.Dto;
using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Contracts
{
    public  interface IEmailBodyHolder
    {
        Task<Email> TakeBodyAsync(EmailContentDto emailDto);

        Task<Email> CheckEmailBodyAsync(EmailContentDto emailDto);

        Task<Email> AddBodyToCurrentEmailAsync(EmailContentDto emailDto);
    }
}
