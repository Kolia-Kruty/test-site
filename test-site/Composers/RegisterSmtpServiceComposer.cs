using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using test_site.Services;
using Umbraco.Core.Composing;

namespace test_site.Composers
{
    public class RegisterSmtpServiceComposer : IUserComposer
    {
        void IComposer.Compose(Composition composition)
        {
            composition.Register<ISmtpService, SmtpService>(Lifetime.Singleton);
        }
    }
}