
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
	 [NodeTypeAlias("BlockBase")]
 	public partial class BlockBase : UmbracoContent
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("cssClasses")]
		public string CssClasses { get; set; } 
		
		public BlockBase()
			: base()
		{
		}

		public BlockBase(int contentId)
			: base(contentId)
		{
		}

		public BlockBase(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.CssClasses = Content.GetPropertyValue<string>("cssClasses");
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
						
			dbContent.SetValue("cssClasses", this.CssClasses);
			
			return base.SetProperties(dbContent);
		}
	}
}

