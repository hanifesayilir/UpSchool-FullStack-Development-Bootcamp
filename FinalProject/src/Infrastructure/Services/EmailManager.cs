using Application.Common.Interfaces;
using Application.Common.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Helpers;
using Domain.Identity;

namespace Infrastructure.Services
{
    public class EmailManager : IEmailService
    {

        private readonly string _wwwrootPath;
        public EmailManager(string wwwrootPath)
        {
            _wwwrootPath = wwwrootPath;
        }
        public void SendEmailNotification(SendEmailNotificationDto sendEmailNotificationDto)
        {
           var htmlContent = File.ReadAllText($"{_wwwrootPath}\\email_templates\\email_notification.html");
         
       

             htmlContent = htmlContent.Replace("{{subject}}", MessagesHelper.Email.Notification.Subject);

            htmlContent = htmlContent.Replace("{{name}}", MessagesHelper.Email.Notification.Name(sendEmailNotificationDto.Name));

            htmlContent = htmlContent.Replace("{{Message}}", MessagesHelper.Email.Notification.ActivationMessage);

         
            Send(new SendEmailDto(sendEmailNotificationDto.Email, htmlContent, MessagesHelper.Email.Notification.Subject));
        }


        private void Send(SendEmailDto sendEmailDto)
        {
            MailMessage message = new MailMessage();

            sendEmailDto.EmailAddresses.ForEach(emailAddress => message.To.Add(emailAddress));

            message.From = new MailAddress("noreply@entegraturk.com");

            message.Subject = sendEmailDto.Subject;

            message.IsBodyHtml = true;

            message.Body = sendEmailDto.Content;

            SmtpClient client = new SmtpClient();

            client.Port = 587;

            client.Host = "mail.entegraturk.com";

            client.EnableSsl = false;

            client.UseDefaultCredentials = false;

            client.Credentials = new NetworkCredential("noreply@entegraturk.com", "xzx2xg4Jttrbzm5nIJ2kj1pE4l");

            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            client.Send(message);


        }
    }
}
