
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
	 [NodeTypeAlias("Product")]
 	public partial class Product : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "Product"; } }

				
		
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

		public Product()
			: base()
		{
		}

		public Product(string name, IConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public Product(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public Product(int contentId, bool getPropertiesRecursively = false)
			: base(contentId, getPropertiesRecursively)
		{
		}

		public Product(IPublishedContent content, bool getPropertiesRecursively = false)
			: base(content, getPropertiesRecursively)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
			
		}

	}
}

