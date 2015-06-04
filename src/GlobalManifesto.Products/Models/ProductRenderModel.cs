using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace GlobalManifesto.Products.Models
{
    public class ProductRenderModel : RenderModel
    {
        private IPublishedContent productContent;

        public IPublishedContent ProductListing { get; set; }
        public IPublishedContent Product { get; set; }

        public ProductRenderModel(IPublishedContent productListing, IPublishedContent product)
            : base(productListing)
        {
            ProductListing = productListing;
            Product = product;
        }
    }
}