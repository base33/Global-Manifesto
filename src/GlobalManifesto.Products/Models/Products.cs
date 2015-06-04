
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ConcreteContentTypes.Core.Models;
using Newtonsoft.Json;

using Umbraco.Examine.Linq.Attributes;


namespace GlobalManifesto.Products.Models
{
	 [NodeTypeAlias("Products")]
 	public partial class Products : UmbracoContent
	{
		
		private IEnumerable<Product> _children = null;
		public new IEnumerable<Product> Children
		{
			get
			{
				if (_children == null)
				{
					_children = this.Content.Children.Select(x => new Product(x));
				}

				return _children;
			}
		}
		
		public Products()
			: base()
		{
		}

		public Products(int contentId)
			: base(contentId)
		{
		}

		public Products(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
			
			return base.SetProperties(dbContent);
		}
	}
}

