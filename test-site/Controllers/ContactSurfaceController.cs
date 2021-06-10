using System;
using System.Collections.Generic;
using System.Linq;
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


            return CurrentUmbracoPage();
        }
    }
}