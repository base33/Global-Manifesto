
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
	 [NodeTypeAlias("RedirectsUrlStructure")]
 	public partial class RedirectsUrlStructure : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "RedirectsUrlStructure"; } }

				
		
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

		public RedirectsUrlStructure()
			: base()
		{
		}

		public RedirectsUrlStructure(string name, IConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public RedirectsUrlStructure(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public RedirectsUrlStructure(int contentId, bool getPropertiesRecursively = false)
			: base(contentId, getPropertiesRecursively)
		{
		}

		public RedirectsUrlStructure(IPublishedContent content, bool getPropertiesRecursively = false)
			: base(content, getPropertiesRecursively)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
						
			this.CustomUrl = Content.GetPropertyValue<string>("umbracoUrlAlias", this.GetPropertiesRecursively);
						
			this.Slug = Content.GetPropertyValue<string>("umbracoUrlName", this.GetPropertiesRecursively);
			
		}

	}
}

