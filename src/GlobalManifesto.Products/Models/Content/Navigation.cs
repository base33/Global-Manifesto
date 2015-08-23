
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
	 [NodeTypeAlias("Navigation")]
 	public partial class Navigation : UmbracoContent
	{
		public override string ContentTypeAlias { get { return "Navigation"; } }

				
		
				
		
		[Field("showInMainNav")]
		public bool ShowInMainNavigation { get; set; } 		
		
				
		
		[Field("umbracoNaviHide")]
		public bool HideFromNavigation { get; set; } 		
		
				
		
		[Field("thisIsARootOfAMenu")]
		public bool ThisIsARootOfAMenu { get; set; } 		
		
				
		
		[Field("hideFromSiteMap")]
		public bool HideFromSiteMap { get; set; } 
		
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

		public Navigation()
			: base()
		{
		}

		public Navigation(string name, IConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public Navigation(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public Navigation(int contentId, bool getPropertiesRecursively = false)
			: base(contentId, getPropertiesRecursively)
		{
		}

		public Navigation(IPublishedContent content, bool getPropertiesRecursively = false)
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
			
		}

	}
}

