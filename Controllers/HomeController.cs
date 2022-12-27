using HashTag.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HashTag.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public  IActionResult Email(String name, String subject, String message_, String email )
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("ithelp254@gmail.com");
                message.To.Add(new MailAddress("ithelp254@gmail.com"));
                message.Subject = "Test";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = "<html><body>" +
                    "<img src=\"https://res.cloudinary.com/dqab6gg7d/image/upload/v1671698046/Hashtag/Logo_Three_lmbsem.png\" style=\"height:70px;width:7-px\" <br/>" +
                    "<table>" +
                    "<tr>" +
                    "<td><b style=\"color:#a7b3c8\">Hashtag <span style=\"color:#1c98f7\">Technologies</span></td> <td></td>" +
                    "</tr>" + "<tr>" +
                    "<td>New mail from: </td> <td>" + name+"</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td>Email: </td> <td>" + email + "</td>" +

                    "</tr>" +
                     "<tr>" +
                    "<td>Time: </td> <td>" + DateTime.Now + "</td>" +

                    "</tr>" +
                      "<tr>" +
                    "<td>Message: </td> <td>" + message_ + "</td>" +

                    "</tr>" +

                    "</table>" +

                    "<p>Mail sending test</p></body></html>";
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("ithelp254@gmail.com", "mkybeggoujggystf");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);

            }
            catch (Exception) { }
            return Redirect("~/home/index");
        }
    }
}
