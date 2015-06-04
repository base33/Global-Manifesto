
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
	 [NodeTypeAlias("RedirectsUrlStructure")]
 	public partial class RedirectsUrlStructure : UmbracoContent
	{
				
		
		private IPublishedContent _umbracoInternalRedirectId = null;
		public IPublishedContent UrlRedirect
		{
			get 
			{
				if (_umbracoInternalRedirectId == null)
				{
					int? contentId = Content.GetPropertyValue<int?>("umbracoInternalRedirectId");

					if (contentId.HasValue)
					{
					
						_umbracoInternalRedirectId = UmbracoContext.Current.ContentCache.GetById(contentId.Value);
				
						
					}	
				}
				return _umbracoInternalRedirectId;
			}
		} 		
		
		/// <summary>
		/// Custom alias URL
		/// </summary>
		
		[Field("umbracoUrlAlias")]
		public string CustomUrl { get; set; } 		
		
		/// <summary>
		/// Changes the current page's segment in the URL
		/// </summary>
		
		[Field("umbracoUrlName")]
		public string Slug { get; set; } 
		
		public RedirectsUrlStructure()
			: base()
		{
		}

		public RedirectsUrlStructure(int contentId)
			: base(contentId)
		{
		}

		public RedirectsUrlStructure(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.CustomUrl = Content.GetPropertyValue<string>("umbracoUrlAlias");
						
			this.Slug = Content.GetPropertyValue<string>("umbracoUrlName");
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
						
			dbContent.SetValue("umbracoUrlAlias", this.CustomUrl);
						
			dbContent.SetValue("umbracoUrlName", this.Slug);
			
			return base.SetProperties(dbContent);
		}
	}
}

