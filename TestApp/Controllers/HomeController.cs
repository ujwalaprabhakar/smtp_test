using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Mail;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        //public  string FrameworkDescription { get; }
        public ActionResult Index()
        {
            string sysVersion = RuntimeEnvironment.GetSystemVersion();
            ViewBag.sysVersion = sysVersion;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SendMail()
        {
            try
            {
                string smtpAddress = "smtp.gmail.com";
                int portNumber = 587;
                bool enableSSL = true;
                string emailFromAddress = "ujwalaprabhakar@gmail.com"; //Sender Email Address  
                string password = ""; //Sender Password  
                string emailToAddress = "ujwala.jagtap@telusinternational.com"; //Receiver Email Address  
                string subject = "Hello";
                string body = "Hello, This is Email sending test using gmail.";

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFromAddress);
                    mail.To.Add(emailToAddress);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                        smtp.EnableSsl = enableSSL;
                        //smtp.Timeout = 10000;
                        //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        //smtp.UseDefaultCredentials = false;
                        smtp.Send(mail);
                    }
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }
            return Content("");
        }
    }
}