namespace E_MailApplicationsManager.Service.Contracts
{
    public interface IEncodeDecodeService
    {
        string Base64Decode(string base64EncodedData);
        string Base64Encode(string plainText);
    }
}