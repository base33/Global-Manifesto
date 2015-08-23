
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
	 [NodeTypeAlias("Productlistingblock")]
 	public partial class Productlistingblock : BlockBase
	{
		public override string ContentTypeAlias { get { return "Productlistingblock"; } }

				
		
		private IPublishedContent _productsRoot = null;
		public IPublishedContent ProductsRoot
		{
			get 
			{
				if (_productsRoot == null)
				{
					int? contentId = Content.GetPropertyValue<int?>("productsRoot", this.GetPropertiesRecursively);

					if (contentId.HasValue)
					{
					
						_productsRoot = UmbracoContext.Current.ContentCache.GetById(contentId.Value);
				
						
					}	
				}
				return _productsRoot;
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

		public Productlistingblock()
			: base()
		{
		}

		public Productlistingblock(string name, IConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public Productlistingblock(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public Productlistingblock(int contentId, bool getPropertiesRecursively = false)
			: base(contentId, getPropertiesRecursively)
		{
		}

		public Productlistingblock(IPublishedContent content, bool getPropertiesRecursively = false)
			: base(content, getPropertiesRecursively)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
			
		}

	}
}

