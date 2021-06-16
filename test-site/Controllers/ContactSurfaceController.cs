using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using test_site.Services;
using test_site.ViewModels;
using Umbraco.Web.Mvc;

namespace test_site.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        private readonly ISmtpService smtp;

        public ContactSurfaceController(ISmtpService smtp)
        {
            this.smtp = smtp;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SubmitForm(ContactViewModel model)
        {
            bool success = false;

            if (ModelState.IsValid)
            {
                success = await smtp.SendMessgaAsync(model);
            }

            TempData["InfoMessageHtml"] = success ? "<div class=\"alert alert-success\" role=\"alert\"> Success! </div>"
                : "<div class=\"alert alert-danger\" role=\"alert\"> Error! </div>";

            return CurrentUmbracoPage();
        }
    }
}