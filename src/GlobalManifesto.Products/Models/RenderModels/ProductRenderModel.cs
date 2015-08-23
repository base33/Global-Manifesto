using ConcreteContentTypes.Core.Models;
using GlobalManifesto.Products.Models.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web.Models;

namespace GlobalManifesto.Products.Models
{
	public class ProductRenderModel : ConcreteRenderModel<Product>
	{
		public ProductListing ProductListing { get; set; }
		public Product Product { get; set; }

		public ProductRenderModel(ProductListing productListing, Product product)
			: base(product.Content)
		{
			ProductListing = productListing;
			Product = product;
		}
	}
}