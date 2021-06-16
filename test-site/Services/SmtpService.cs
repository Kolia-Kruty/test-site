//using ClientDependency.Core.Logging;

using Umbraco.Core.Logging;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using test_site.ViewModels;
using Umbraco.Core.Models.Membership;
using Umbraco.Core.Services;
using test_site.Controllers;

namespace test_site.Services
{
    public class SmtpService : ISmtpService
    {
        private readonly ILogger logger;
        private readonly IUserService user;

        public SmtpService(ILogger logger, IUserService user)
        {
            this.logger = logger;
            this.user = user;
        }

        public async Task<bool> SendMessgaAsync(ContactViewModel model)
        {
            try
            {
                IUser user = null;

                if (model.User is int idUser)
                {
                    user = this.user.GetUserById(idUser) as IUser;
                }

                var options = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");

                var from = new MailAddress(model.Email, model.Name);

                var to = new MailAddress(user != null ? user.Email : options.From, user != null ? user.Name : "Boss");

                var m = new MailMessage(from, to);

                m.Subject = $"Message";

                m.Body =
                    "<div>" +
                    $"<h1>Help {model.Name}!</h1>" +
                    $"<p style=\"color:blue\">{model.Message}</p>" +
                    "</div>";

                m.IsBodyHtml = true;

                using (var smtp = new SmtpClient(options.Network.Host, options.Network.Port))
                {
                    smtp.Credentials = new NetworkCredential(options.Network.UserName, options.Network.Password);
                    smtp.EnableSsl = options.Network.EnableSsl;
                    await smtp.SendMailAsync(m);
                }

                return true;
            }
            catch (Exception ex)
            {
                logger.Error(typeof(ContactSurfaceController), ex, "Error sending contact form.");
                return false;
            }
        }
    }

    public interface ISmtpService
    {
        Task<bool> SendMessgaAsync(ContactViewModel model);
    }
}