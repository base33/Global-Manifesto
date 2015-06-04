
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
	 [NodeTypeAlias("RelatedLinksBlock")]
 	public partial class RelatedLinksBlock : BlockBase
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("title")]
		public string Title { get; set; } 
		
		public RelatedLinksBlock()
			: base()
		{
		}

		public RelatedLinksBlock(int contentId)
			: base(contentId)
		{
		}

		public RelatedLinksBlock(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.Title = Content.GetPropertyValue<string>("title");
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
						
			dbContent.SetValue("title", this.Title);
			
			return base.SetProperties(dbContent);
		}
	}
}

