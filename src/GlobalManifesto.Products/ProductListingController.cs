using GlobalManifesto.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Examine.Linq;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace GlobalManifesto.Products
{
    public class ProductListingController : RenderMvcController
    {
        public override ActionResult Index(RenderModel model)
        {
            var nodeUrl = model.Content.Url.Split(new [] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var currentUrl = Request.Url.AbsolutePath.Split(new [] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            if(currentUrl.Length > nodeUrl.Length)
            {
                var product = getProductByName(currentUrl.Last());

				if (product != null)
				{
					return View("Product", new ProductRenderModel(new ProductListing(model.Content), product));
				}
            }

            return base.Index(model);
        }

        protected Product getProductByName(string productUrlName)
        {
            return new Index<Product>().Where(c => c.Name == productUrlName).FirstOrDefault();
        }
    }
}