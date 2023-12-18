using EASendMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    public static class SendUsingOffice365
    {
        public static void Send()
        {
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt");

                // Your Hotmail email address
                oMail.From = "Akomspatrick@hotmail.com";
                // Set recipient email address
                oMail.To = "Akomspatrick@yahoo.com";

                // Set email subject
                oMail.Subject = "test email from hotmail account";
                // Set email body
                oMail.TextBody = "this is a test email sent from c# project with hotmail.";

                // Hotmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.office365.com");

                // Hotmail user authentication should use your
                // email address as the user name.
                oServer.User = "Akomspatrick@hotmail.com";

                // If you got authentication error, try to create an app password instead of your user password.
                // https://support.microsoft.com/en-us/account-billing/using-app-passwords-with-apps-that-don-t-support-two-step-verification-5896ed9b-4263-e681-128a-a6f2979a7944
                oServer.Password = "Admin@bigG.hotmail_7";

                // Set 587 port, if you want to use 25 port, please change 587 to 25
                oServer.Port = 587;

                // detect SSL/TLS connection automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                Console.WriteLine("start to send email over SSL...");

                EASendMail.SmtpClient oSmtp = new EASendMail.SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                Console.WriteLine("email was sent successfully!");

            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");

            }
        }
    }
}
