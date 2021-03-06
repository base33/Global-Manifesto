
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
	 [NodeTypeAlias("HeroSlide")]
 	public partial class HeroSlide : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "HeroSlide"; } }

				
		
		private IPublishedContent _image = null;
		public IPublishedContent Image
		{
			get 
			{
				if (_image == null)
				{
					int? contentId = Content.GetPropertyValue<int?>("image", this.GetPropertiesRecursively);

					if (contentId.HasValue)
					{
					
						_image = UmbracoContext.Current.MediaCache.GetById(contentId.Value);
				
						
					}	
				}
				return _image;
			}
		} 		
		
		private IPublishedContent _link = null;
		public IPublishedContent Link
		{
			get 
			{
				if (_link == null)
				{
					int? contentId = Content.GetPropertyValue<int?>("link", this.GetPropertiesRecursively);

					if (contentId.HasValue)
					{
					
						_link = UmbracoContext.Current.ContentCache.GetById(contentId.Value);
				
						
					}	
				}
				return _link;
			}
		} 
		
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

		public HeroSlide()
			: base()
		{
		}

		public HeroSlide(string name, IConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public HeroSlide(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public HeroSlide(int contentId, bool getPropertiesRecursively = false)
			: base(contentId, getPropertiesRecursively)
		{
		}

		public HeroSlide(IPublishedContent content, bool getPropertiesRecursively = false)
			: base(content, getPropertiesRecursively)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
			
		}

	}
}

