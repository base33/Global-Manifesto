
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
	 [NodeTypeAlias("Productlistingblock")]
 	public partial class Productlistingblock : BlockBase
	{
				
		
		private IPublishedContent _productsRoot = null;
		public IPublishedContent ProductsRoot
		{
			get 
			{
				if (_productsRoot == null)
				{
					int? contentId = Content.GetPropertyValue<int?>("productsRoot");

					if (contentId.HasValue)
					{
					
						_productsRoot = UmbracoContext.Current.ContentCache.GetById(contentId.Value);
				
						
					}	
				}
				return _productsRoot;
			}
		} 
		
		public Productlistingblock()
			: base()
		{
		}

		public Productlistingblock(int contentId)
			: base(contentId)
		{
		}

		public Productlistingblock(IPublishedContent content)
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

