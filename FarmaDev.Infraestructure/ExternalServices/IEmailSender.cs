namespace FarmaDev.Infraestructure.ExternalServices
{
    public interface IEmailSender
    {
        Task SendEmailConfirmOrder(string toEmail, string clientName, int orderId, string pharmacyName);
        Task SendEmailRegister(string toEmail, string clientName, string pharmacyName);
    }
}
