
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
	 [NodeTypeAlias("ContentPage")]
 	public partial class ContentPage : WebBlocksPage
	{
		
		private IEnumerable<ContentPage> _children = null;
		public new IEnumerable<ContentPage> Children
		{
			get
			{
				if (_children == null)
				{
					_children = this.Content.Children.Select(x => new ContentPage(x));
				}

				return _children;
			}
		}
		
		public ContentPage()
			: base()
		{
		}

		public ContentPage(int contentId)
			: base(contentId)
		{
		}

		public ContentPage(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
			
			return base.SetProperties(dbContent);
		}
	}
}

