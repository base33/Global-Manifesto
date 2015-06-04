
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
	 [NodeTypeAlias("Seo")]
 	public partial class Seo : UmbracoContent
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("pageTitle")]
		public string PageTitle { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("metaDescription")]
		public string MetaDescription { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("canonicalLink")]
		public string CanonicalLink { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("h1Override")]
		public string H1Override { get; set; } 
		
		public Seo()
			: base()
		{
		}

		public Seo(int contentId)
			: base(contentId)
		{
		}

		public Seo(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.PageTitle = Content.GetPropertyValue<string>("pageTitle");
						
			this.MetaDescription = Content.GetPropertyValue<string>("metaDescription");
						
			this.CanonicalLink = Content.GetPropertyValue<string>("canonicalLink");
						
			this.H1Override = Content.GetPropertyValue<string>("h1Override");
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
						
			dbContent.SetValue("pageTitle", this.PageTitle);
						
			dbContent.SetValue("metaDescription", this.MetaDescription);
						
			dbContent.SetValue("canonicalLink", this.CanonicalLink);
						
			dbContent.SetValue("h1Override", this.H1Override);
			
			return base.SetProperties(dbContent);
		}
	}
}

