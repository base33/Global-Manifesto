
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
	 [NodeTypeAlias("FeatureBlock")]
 	public partial class FeatureBlock : BlockBase
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("title")]
		public string Title { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("image")]
		public IPublishedContent Image { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("content")]
		public IHtmlString content { get; set; } 
		
		public FeatureBlock()
			: base()
		{
		}

		public FeatureBlock(int contentId)
			: base(contentId)
		{
		}

		public FeatureBlock(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.Title = Content.GetPropertyValue<string>("title");
						
			this.Image = Content.GetPropertyValue<IPublishedContent>("image");
						
			this.content = Content.GetPropertyValue<IHtmlString>("content");
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
						
			dbContent.SetValue("title", this.Title);
						
			dbContent.SetValue("image", this.Image);
						
			dbContent.SetValue("content", this.content);
			
			return base.SetProperties(dbContent);
		}
	}
}

