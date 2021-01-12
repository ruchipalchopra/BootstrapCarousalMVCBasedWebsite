using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EclipseStudio.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title="Eclipse Dance and Performing Arts";
            return View();
        }
        public ActionResult Instructors()
        {
            ViewBag.Title = "Eclipse Dance and Performing Arts";
            return View();
        }
        public ActionResult ContactUs()
        {
            ViewBag.Title = "Eclipse Dance and Performing Arts";
            return View();
        }
        public ActionResult EclipseCompetitionTeam()
        {
            ViewBag.Title = "Eclipse Dance and Performing Arts";
            return View();
        }
        public ActionResult Events()
        {
            ViewBag.Title = "Eclipse Dance and Performing Arts";
            return View();
        }
        public ActionResult TimetableFees()
        {
            ViewBag.Title = "Eclipse Dance and Performing Arts";
            return View();
        }
        public async Task<ActionResult> email(FormCollection form)
        {
            var name = form["sname"];
            var email = form["semail"];
            var messages = form["smessage"];
            var phone = form["sphone"];
            var x = await SendEmail(name, email, messages, phone);
            if (x == "sent")
                ViewData["esent"] = "Your Message Has Been Sent";
            return RedirectToAction("Index");
        }
        //this is not the permanent solution, implement oauth2.0
        private async Task<string> SendEmail(string name, string email, string messages, string phone)
        {
            var message = new MailMessage();
            message.To.Add(new MailAddress("ruchichopra.in@gmail.com")); // replace with receiver's email id     
            message.From = new MailAddress("ruchichopra.in@gmail.com"); // replace with sender's email id     
            message.Subject = "Message From" + email;
            message.Body = "Name: " + name + "\nFrom: " + email + "\nPhone: " + phone + "\n" + messages;
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "ruchichopra.in@gmail.com", // replace with sender's email id     
                    Password = "up13e6421" // replace with password     
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                try
                {
                    await smtp.SendMailAsync(message);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
                return "sent";
            }
        }

    }
}