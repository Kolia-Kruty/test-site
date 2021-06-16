using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using Umbraco.Web.PublishedModels;

namespace test_site.Controllers
{
    public class LocalizationSurfaceController : SurfaceController
    {
        [HttpPost]
        public ActionResult SaveLanguage(string language)
        {
            Session["language"] = language;

            var root = Umbraco.ContentAtRoot();

            if (root.FirstOrDefault() is Home home)
            {
                var aboutUsList = home.Children.Where(w => w is AboutUsList).FirstOrDefault();

                var requestUrl = Request.RawUrl;

                var wordsUrl = requestUrl.Split('/');

                if (wordsUrl.Count() > 2)
                {
                    if (wordsUrl[1] == aboutUsList?.UrlSegment)
                    {
                        return Redirect(aboutUsList.Url);
                    }
                }
            }

            return CurrentUmbracoPage();
        }
    }
}