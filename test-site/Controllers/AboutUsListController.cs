using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using System.Web.Mvc;
using System.Collections.Generic;
using Umbraco.Web.PublishedModels;
using Umbraco.Core.Models.PublishedContent;
using System.Linq;
using Umbraco.Web;

namespace test_site.Controllers
{
    public class AboutUsListController : RenderMvcController
    {

        // GET: AboutUs
        public override ActionResult Index(ContentModel model)
        {
            var aboutUsList = model.Content as AboutUsList;
            var home = Umbraco.ContentAtRoot().FirstOrDefault() as Home;

            if (aboutUsList == null && home == null)
            {
                return CurrentTemplate(model);
            }

            var aboutUsItems = aboutUsList.Descendants<AboutUsItem>().ToList();

            var language = Session["language"];

            if (language == null)
            {
                language = home.TDefaultLanguage?.Name ?? "";
            }

            var aboutUsItem = aboutUsItems.Where(w => w.Name == (string)language).FirstOrDefault();

            if (aboutUsItem != null && !string.IsNullOrWhiteSpace(aboutUsItem.Url))
            {
                return Redirect(aboutUsItem.Url);
            }

            return CurrentTemplate(model);
        }
    }
}