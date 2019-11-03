using System.Threading.Tasks;

namespace E_MailApplicationsManager.Service.Contracts
{
    public interface IConcreteMailService
    {
        string Base64Decode(string base64EncodedData);

        void QuickStart();

        void GetEmailById(string id);
    }
}