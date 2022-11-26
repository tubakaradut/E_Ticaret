using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class MailSender
    {

        public static void SendEmail(string email, string subject, string message)
        {

            //Sender
            MailMessage sender = new MailMessage();
            sender.From = new MailAddress("tuba--18@hotmail.com", "tubik");
            sender.To.Add(email);
            sender.Subject = subject;
            sender.Body = message;


            //Smtp
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("tuba--18@hotmail.com", "tubik");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;

            smtp.Send(sender);

            //NOT!!
            //Eğer tanımlı gmail hesabınız üzerinden mail göndermek istediğinizde bir hata ile karşılaşıyorsanız aşağıdaki link üzerinden izin tanımlaması yapmanız gerekmektedir.
            //https://www.google.com/settings/security/lesssecureapps

        }
    }
}
