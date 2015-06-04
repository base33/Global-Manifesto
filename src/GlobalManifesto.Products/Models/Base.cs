
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
	 [NodeTypeAlias("Base")]
 	public partial class Base : UmbracoContent
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("showInMainNav")]
		public bool ShowInMainNavigation { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("umbracoNaviHide")]
		public bool HideFromNavigation { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("thisIsARootOfAMenu")]
		public bool ThisIsARootOfAMenu { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("hideFromSiteMap")]
		public bool HideFromSiteMap { get; set; } 		
		
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
		
		public Base()
			: base()
		{
		}

		public Base(int contentId)
			: base(contentId)
		{
		}

		public Base(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.ShowInMainNavigation = Content.GetPropertyValue<bool>("showInMainNav");
						
			this.HideFromNavigation = Content.GetPropertyValue<bool>("umbracoNaviHide");
						
			this.ThisIsARootOfAMenu = Content.GetPropertyValue<bool>("thisIsARootOfAMenu");
						
			this.HideFromSiteMap = Content.GetPropertyValue<bool>("hideFromSiteMap");
						
			this.CustomUrl = Content.GetPropertyValue<string>("umbracoUrlAlias");
						
			this.Slug = Content.GetPropertyValue<string>("umbracoUrlName");
						
			this.PageTitle = Content.GetPropertyValue<string>("pageTitle");
						
			this.MetaDescription = Content.GetPropertyValue<string>("metaDescription");
						
			this.CanonicalLink = Content.GetPropertyValue<string>("canonicalLink");
						
			this.H1Override = Content.GetPropertyValue<string>("h1Override");
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
						
			dbContent.SetValue("showInMainNav", this.ShowInMainNavigation);
						
			dbContent.SetValue("umbracoNaviHide", this.HideFromNavigation);
						
			dbContent.SetValue("thisIsARootOfAMenu", this.ThisIsARootOfAMenu);
						
			dbContent.SetValue("hideFromSiteMap", this.HideFromSiteMap);
						
			dbContent.SetValue("umbracoUrlAlias", this.CustomUrl);
						
			dbContent.SetValue("umbracoUrlName", this.Slug);
						
			dbContent.SetValue("pageTitle", this.PageTitle);
						
			dbContent.SetValue("metaDescription", this.MetaDescription);
						
			dbContent.SetValue("canonicalLink", this.CanonicalLink);
						
			dbContent.SetValue("h1Override", this.H1Override);
			
			return base.SetProperties(dbContent);
		}
	}
}

