
using System;
using System.Collections.Generic;
using Umbraco.Core.Models;
using Umbraco.Web;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using ConcreteContentTypes.Core.Models;
using ConcreteContentTypes.Core.Interfaces;
using Newtonsoft.Json;

using System;
using GlobalManifesto.Products.Models.Media;
using Umbraco.Examine.Linq.Attributes;
using ConcreteContentTypes.Core.Extensions;


namespace GlobalManifesto.Products.Models.Content
{
	 [NodeTypeAlias("Base")]
 	public partial class Base : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "Base"; } }

				
		
				
		
		[Field("showInMainNav")]
		public bool ShowInMainNavigation { get; set; } 		
		
				
		
		[Field("umbracoNaviHide")]
		public bool HideFromNavigation { get; set; } 		
		
				
		
		[Field("thisIsARootOfAMenu")]
		public bool ThisIsARootOfAMenu { get; set; } 		
		
				
		
		[Field("hideFromSiteMap")]
		public bool HideFromSiteMap { get; set; } 		
		
		private IPublishedContent _umbracoInternalRedirectId = null;
		public IPublishedContent UrlRedirect
		{
			get 
			{
				if (_umbracoInternalRedirectId == null)
				{
					int? contentId = Content.GetPropertyValue<int?>("umbracoInternalRedirectId", this.GetPropertiesRecursively);

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
		
				
		
		[Field("pageTitle")]
		public string PageTitle { get; set; } 		
		
				
		
		[Field("metaDescription")]
		public string MetaDescription { get; set; } 		
		
				
		
		[Field("canonicalLink")]
		public string CanonicalLink { get; set; } 		
		
				
		
		[Field("h1Override")]
		public string H1Override { get; set; } 
		
		private IEnumerable<IPublishedContent> _children = null;
		[JsonIgnore]
		public IEnumerable<IPublishedContent> Children
		{
			get
			{
				if (_children == null && this.Content != null)
					_children = this.Content.Children;

				return _children;
			}
		}

		public Base()
			: base()
		{
		}

		public Base(string name, IConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public Base(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public Base(int contentId, bool getPropertiesRecursively = false)
			: base(contentId, getPropertiesRecursively)
		{
		}

		public Base(IPublishedContent content, bool getPropertiesRecursively = false)
			: base(content, getPropertiesRecursively)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
						
			this.ShowInMainNavigation = Content.GetPropertyValue<bool>("showInMainNav", this.GetPropertiesRecursively);
						
			this.HideFromNavigation = Content.GetPropertyValue<bool>("umbracoNaviHide", this.GetPropertiesRecursively);
						
			this.ThisIsARootOfAMenu = Content.GetPropertyValue<bool>("thisIsARootOfAMenu", this.GetPropertiesRecursively);
						
			this.HideFromSiteMap = Content.GetPropertyValue<bool>("hideFromSiteMap", this.GetPropertiesRecursively);
						
			this.CustomUrl = Content.GetPropertyValue<string>("umbracoUrlAlias", this.GetPropertiesRecursively);
						
			this.Slug = Content.GetPropertyValue<string>("umbracoUrlName", this.GetPropertiesRecursively);
						
			this.PageTitle = Content.GetPropertyValue<string>("pageTitle", this.GetPropertiesRecursively);
						
			this.MetaDescription = Content.GetPropertyValue<string>("metaDescription", this.GetPropertiesRecursively);
						
			this.CanonicalLink = Content.GetPropertyValue<string>("canonicalLink", this.GetPropertiesRecursively);
						
			this.H1Override = Content.GetPropertyValue<string>("h1Override", this.GetPropertiesRecursively);
			
		}

	}
}

