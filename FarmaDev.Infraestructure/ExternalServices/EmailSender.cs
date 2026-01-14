using FluentEmail.Core;
using Microsoft.Extensions.DependencyInjection;

namespace FarmaDev.Infraestructure.ExternalServices
{
    public class EmailSender : IEmailSender
    {
        private readonly IServiceProvider _serviceProvider;

        public EmailSender(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task SendEmailConfirmOrder(string toEmail, string clientName, int orderId, string pharmacyName)
        {
            var email = await _serviceProvider.GetRequiredService<IFluentEmail>()
                .To(toEmail)
                .Subject($"Order #{orderId} Confirmed - {pharmacyName}")
                .Body($"Dear {clientName},\n\nYour order with ID #{orderId} has been successfully confirmed. Thank you for shopping with {pharmacyName}!\n\nBest regards,\n{pharmacyName} Team")
                .SendAsync();
        }

        public async Task SendEmailRegisterUser(string toEmail, string clientName, string pharmacyName)
        {
            var email = await _serviceProvider.GetRequiredService<IFluentEmail>()
                .To(toEmail)
                .Subject($"Welcome to {pharmacyName}!")
                .Body($"Dear {clientName},\n\nThank you for registering with {pharmacyName}. We're excited to have you on board!\n\nBest regards,\n{pharmacyName} Team")
                .SendAsync();
        }

        public async Task SendEmailRegisterPharmacy(string toEmail, string pharmacyName)
        {
            var email = await _serviceProvider.GetRequiredService<IFluentEmail>()
                .To(toEmail)
                .Subject($"Pharmacy {pharmacyName} Registration Successful")
                .Body($"Congratulations!, \n\n Your pharmacy, {pharmacyName}, has been successfully registered in our system.\n\nBest regards,\nFarmaDev Team")
                .SendAsync();
        }
    }
}
