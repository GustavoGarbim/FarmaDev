namespace FarmaDev.Infraestructure.ExternalServices
{
    public interface IEmailSender
    {
        Task SendEmailConfirmOrder(string toEmail, string clientName, int orderId, string pharmacyName);
        Task SendEmailRegisterUser(string toEmail, string clientName, string pharmacyName);
        Task SendEmailRegisterPharmacy(string toEmail, string pharmacyName);
    }
}
