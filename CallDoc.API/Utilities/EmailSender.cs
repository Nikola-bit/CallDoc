using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using CallDoc.DTO;

namespace CallDoc.API.Utilities
{
    public class EmailSender
    {
        public async static Task<bool> SendEmail(MailDTO information)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("prendjov.portfolio@gmail.com", "Doctor Calling Center");
            message.To.Add(new MailAddress(information.RecieverEmail));
            message.Subject = information.Subject;
            message.IsBodyHtml = false;
            message.Body = information.Body;
            
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Timeout = 60000;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("prendjov.portfolio@gmail.com", DataEncryption.Decrypt("AyJJS/7lE7fTx3zyU1lP41dJFO//OtIv/ZWVD6mroh4="));
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.Send(message);
            message.Dispose();

            return true; //new
        }
    }
}