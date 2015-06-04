using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Web.Routing;

namespace GlobalManifesto.Products
{
    public class StartUp : ApplicationEventHandler
    {
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            base.ApplicationStarting(umbracoApplication, applicationContext);

            ContentFinderResolver.Current.InsertType<ProductContentFinder>();
        }
    }
}