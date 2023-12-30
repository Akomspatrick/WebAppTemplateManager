using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Text;
using System.Threading.Tasks;
// wathis this video https://www.youtube.com/watch?v=Zwqo8lX7uP8
namespace MailSender
{
    public static class SendUsingGSmtp
    {
        public static void sendmail(string FromAddress, string thehost, int theport, string thepassword, string ToAddress, string txtMessage, string Subject, string Sender, string receiver)
        {

            //  var fromAddress = new MailAddress("ibarapa@theibarapapoly.edu.ng", "Akomolafe O.P");
            // var toAddress = new MailAddress("Akomspatrick@yahoo.com", "Akomolafe O P");
            //  < network host = "smtp.polyibadan.edu.ng" password = "cidmadmin1" userName = "Admin@polyibadan.edu.ng" />
            try
            {


                var fromAddress = new MailAddress(FromAddress, Sender);
                var toAddress = new MailAddress(ToAddress, receiver);

                //const string fromPassword = "ibarapa1";
                //const string fromPassword = thepassword;//"cidmadmin1";
                string subject = Subject;
                string body = txtMessage;

                var smtp = new SmtpClient
                {
                    //Host = "smtp.gmail.com",
                    Host = thehost,// "smtp.polyibadan.edu.ng",smtp.tops.orn.ng
                    Port = theport,// 587,
                    EnableSsl = true,

                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, thepassword),
                    Timeout = 20000
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    //Body = body,
                    IsBodyHtml = true,

                })
                {

                    smtp.Send(message);
                }


            }
            catch (Exception x)
            {
                //Mail as not sent but error  as suppresed make sure you validate mail on client side
            }

        }
    }
}
