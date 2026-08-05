using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace AirlineBookingSystem.Utilities
{
    public class SendEmail : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("Koraamanianew@gmail.com", "sood taqp uajh wbnl")
            };
            var mail = new MailMessage(from: "Koraamanianew@gmail.com",
                                to: email,
                                subject,
                                htmlMessage
                                )
            {
                IsBodyHtml = true
            };
            return client.SendMailAsync(mail);
        
        }
    }
}
