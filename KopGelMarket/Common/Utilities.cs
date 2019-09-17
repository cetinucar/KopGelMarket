using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace KopGelMarket.Common
{
    public static class Utilities
    {
        /// <summary>
        /// Mail göndermek için oluşturulmuş metod
        /// </summary>
        /// <param name="destination">Alıcının Mail Adresi</param>
        /// <param name="subject">Mailin Konusu</param>
        /// <param name="body">Mailin İçeriği</param>
        public static void SendMail(string destination, string subject, string body)
        {
            var fromAddress = new MailAddress("info@cetinucar.com", "Çetin Uçar");
            var toAddress = new MailAddress(destination, "To Name");
            string fromPassword = "Kayseri3.8";

            var smtp = new SmtpClient
            {
                Host = "windmill.guzelhosting.com",
                Port = 25,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message=new MailMessage(fromAddress, toAddress)
            {
                 Subject=subject,
                  Body=body,
                  IsBodyHtml=true
            })
            {
                smtp.Send(message);
            }



        }
    }
}