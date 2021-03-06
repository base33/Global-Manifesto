
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

using GlobalManifesto.Products.Models.Media;
using Umbraco.Examine.Linq.Attributes;
using ConcreteContentTypes.Core.Extensions;


namespace GlobalManifesto.Products.Models.Content
{
	 [NodeTypeAlias("ContentPage")]
 	public partial class ContentPage : WebBlocksPage
	{
		public override string ContentTypeAlias { get { return "ContentPage"; } }

		
		
		private IEnumerable<ContentPage> _children = null;
		public IEnumerable<ContentPage> Children
		{
			get
			{
				if (_children == null && this.Content != null)
					_children = this.Content.Children.Select(x => new ContentPage(x));

				return _children;
			}
		}

		public ContentPage()
			: base()
		{
		}

		public ContentPage(string name, IConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public ContentPage(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public ContentPage(int contentId, bool getPropertiesRecursively = false)
			: base(contentId, getPropertiesRecursively)
		{
		}

		public ContentPage(IPublishedContent content, bool getPropertiesRecursively = false)
			: base(content, getPropertiesRecursively)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
			
		}

	}
}

