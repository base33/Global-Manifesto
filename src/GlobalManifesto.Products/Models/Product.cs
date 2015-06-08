
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
	 [NodeTypeAlias("Product")]
 	public partial class Product : UmbracoContent
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("image")]
		public string Image { get; set; } 
		
		public Product()
			: base()
		{
		}

		public Product(int contentId)
			: base(contentId)
		{
		}

		public Product(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.Image = Content.GetPropertyValue<string>("image");
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
						
			dbContent.SetValue("image", this.Image);
			
			return base.SetProperties(dbContent);
		}
	}
}

