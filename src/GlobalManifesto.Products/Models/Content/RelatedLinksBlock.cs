
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

using RJP.MultiUrlPicker.Models;
using System;
using GlobalManifesto.Products.Models.Media;
using Umbraco.Examine.Linq.Attributes;
using ConcreteContentTypes.Core.Extensions;


namespace GlobalManifesto.Products.Models.Content
{
	 [NodeTypeAlias("RelatedLinksBlock")]
 	public partial class RelatedLinksBlock : BlockBase
	{
		public override string ContentTypeAlias { get { return "RelatedLinksBlock"; } }

				
		
				
		
		[Field("relatedLinks")]
		public MultiUrls RelatedLinks { get; set; } 		
		
				
		
		[Field("title")]
		public string Title { get; set; } 
		
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

		public RelatedLinksBlock()
			: base()
		{
		}

		public RelatedLinksBlock(string name, IConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public RelatedLinksBlock(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public RelatedLinksBlock(int contentId, bool getPropertiesRecursively = false)
			: base(contentId, getPropertiesRecursively)
		{
		}

		public RelatedLinksBlock(IPublishedContent content, bool getPropertiesRecursively = false)
			: base(content, getPropertiesRecursively)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
						
			this.RelatedLinks = Content.GetPropertyValue<MultiUrls>("relatedLinks", this.GetPropertiesRecursively);
						
			this.Title = Content.GetPropertyValue<string>("title", this.GetPropertiesRecursively);
			
		}

	}
}

