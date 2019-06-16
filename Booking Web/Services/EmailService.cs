using Booking_Web.InterFaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Booking_Web.Services
{
    public class AuthMessageServices : IEmailService
    {
        UnitOfWork database = new UnitOfWork();
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var qservice = database.SettingRepository.Get().FirstOrDefault();
            MailMessage msg = new MailMessage();
            msg.Body = message;
            msg.BodyEncoding = Encoding.UTF8;
            msg.From = new MailAddress(qservice.Email, "Your Email Name", Encoding.UTF8);
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            msg.Sender = msg.From;
            msg.Subject = subject;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.To.Add(new MailAddress(email, "Reciver", Encoding.UTF8));

            SmtpClient smtp = new SmtpClient();
            smtp.Host = qservice.Smpt;
            smtp.Port = 25;   
            smtp.EnableSsl = true;   // this propertis is true  when your server support ssl
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(qservice.Email, qservice.EmailPwd);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(msg);

            return Task.FromResult(0);
        }
        public Task SendEmailAsync(string[] emails, string subject, string message)
        {
            var qservice = database.SettingRepository.Get().FirstOrDefault();
            MailMessage msg = new MailMessage();
            msg.Body = message;
            msg.BodyEncoding = Encoding.UTF8;
            msg.From = new MailAddress(qservice.Email, "Your Email Name", Encoding.UTF8);
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            msg.Sender = msg.From;
            msg.Subject = subject;
            msg.SubjectEncoding = Encoding.UTF8;
            for (int i = 0; i < emails.Length; i++)
            {
                msg.To.Add(new MailAddress(emails[i], "Reciver", Encoding.UTF8));
            }
            SmtpClient smtp = new SmtpClient();
            smtp.Host = qservice.Smpt;
            smtp.Port = 25;
            smtp.EnableSsl = true;   // this propertis is true  when your server support ssl
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(qservice.Email, qservice.EmailPwd);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(msg);

            return Task.FromResult(0);
        }
    }
}
