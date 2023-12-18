using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using EASendMail;
using MailSender; //add EASendMail namespace
namespace mysendemail
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg = "Testing mail sending using gmail";
            string subject = "Send From Gmail";
            string towhom = "Oladeji Akomolafe";
            string toaddress = "Akomspatrick@yahoo.com";
            int theport = 587;
            string thepassword = "Deji75@Akoms";
            string thehost = "smtp.gmail.com";
            string fromAddress = "Akomspatrick@gmail.com";
            string sender = "Software Engr";


            SendUsingOffice365.Send();


            //MAIL   GeneralClass.sendmailwtAttachment("Admin@polyibadan.edu.ng", "smtp.gmail.com", 587, "polyibadan", entity.EmailAddress,  msg, "FILLED APPLICATION FORM","Admissions", entity.Surname + " " + entity.Middlename + " " + entity.Firstname, Appprintout,"Filled_Form");

            SendUsingGSmtp.sendmail(fromAddress, thehost, theport, thepassword, toaddress, msg, subject, sender, towhom);

            Console.WriteLine("Done..........................");
            Console.ReadLine();
        }


    }
}