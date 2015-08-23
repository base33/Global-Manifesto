
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
	 [NodeTypeAlias("Seo")]
 	public partial class Seo : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "Seo"; } }

				
		
				
		
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

		public Seo()
			: base()
		{
		}

		public Seo(string name, IConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public Seo(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public Seo(int contentId, bool getPropertiesRecursively = false)
			: base(contentId, getPropertiesRecursively)
		{
		}

		public Seo(IPublishedContent content, bool getPropertiesRecursively = false)
			: base(content, getPropertiesRecursively)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
						
			this.PageTitle = Content.GetPropertyValue<string>("pageTitle", this.GetPropertiesRecursively);
						
			this.MetaDescription = Content.GetPropertyValue<string>("metaDescription", this.GetPropertiesRecursively);
						
			this.CanonicalLink = Content.GetPropertyValue<string>("canonicalLink", this.GetPropertiesRecursively);
						
			this.H1Override = Content.GetPropertyValue<string>("h1Override", this.GetPropertiesRecursively);
			
		}

	}
}

