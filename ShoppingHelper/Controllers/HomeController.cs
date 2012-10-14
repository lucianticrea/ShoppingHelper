using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingHelper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public void GmailTeste(string To, string Subject, string Body)
        {
            var message = new System.Net.Mail.MailMessage();
            message.To.Add(To);
            message.Subject = Subject;
            message.Body = Body;

            var smtpClient = new System.Net.Mail.SmtpClient();
            smtpClient.Send(message);
        }
    }
}
