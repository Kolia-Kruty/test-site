using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using test_site.ViewModels;
using Umbraco.Core.Logging;
using Umbraco.Web.Mvc;

namespace test_site.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        private readonly ILogger logger;

        public ContactSurfaceController(ILogger logger)
        {
            this.logger = logger;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ContactViewModel model)
        {
            bool success = false;

            if (ModelState.IsValid)
            {   
                success = SendEmail(model);
            }

            TempData["InfoMessageHtml"] = success ? "<divclass=\"alert alert - success\" role=\"alert\">A simple success alert—check it out!</ div > " : "error";

            return CurrentUmbracoPage();
        }

        private bool SendEmail(ContactViewModel model)
        {
            try
            {
                var options = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");

                MailAddress from = new MailAddress(options.From, "Admin");

                MailAddress to = new MailAddress(model.Email, model.Name);
                
                MailMessage m = new MailMessage(from, to);
                
                m.Subject = $"{model.Name}";

                m.Body =
                    "<div>" +
                    "<h1>Hello bro!</h1>" +
                    $"<p style=\"color:blue\">{model.Message}</p>" +
                    "</div>";

                m.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient(options.Network.Host, options.Network.Port);

                smtp.Credentials = new NetworkCredential(options.Network.UserName, options.Network.Password);
                smtp.EnableSsl = options.Network.EnableSsl;
                smtp.Send(m);

                return true;
            }
            catch (Exception ex)
            {
                this.logger.Error(typeof(ContactSurfaceController), ex, "Error sending contact form.");
                return false;
            }
        }
    }
}