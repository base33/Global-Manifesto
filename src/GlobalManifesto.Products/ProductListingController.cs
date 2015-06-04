using GlobalManifesto.Products.Examine;
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
        public override ActionResult Index(Umbraco.Web.Models.RenderModel model)
        {
            var nodeUrl = model.Content.Url.Split(new [] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var currentUrl = Request.Url.AbsolutePath.Split(new [] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            if(currentUrl.Length > nodeUrl.Length)
            {
                var productContent = getProductByName(currentUrl.Last());

                if(productContent != null)
                    return View("Product", new ProductRenderModel(model.Content, productContent));
            }

            return base.Index(model);
        }

        protected IPublishedContent getProductByName(string productUrlName)
        {
            Product product = new Index<Product>().Where(c => c.Name == productUrlName).FirstOrDefault();

            return product != null ? UmbracoContext.ContentCache.GetById(product.Id) : null;
        }
    }
}