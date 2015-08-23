
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
using RJP.MultiUrlPicker.Models;
using GlobalManifesto.Products.Models.Media;
using Umbraco.Examine.Linq.Attributes;
using ConcreteContentTypes.Core.Extensions;


namespace GlobalManifesto.Products.Models.Content
{
	 [NodeTypeAlias("HomePage")]
 	public partial class HomePage : WebBlocksPage
	{
		public override string ContentTypeAlias { get { return "HomePage"; } }

				
		
				
		
		[Field("facebookLink")]
		public string FacebookLink { get; set; } 		
		
				
		
		[Field("twitterLink")]
		public string TwitterLink { get; set; } 		
		
				
		
		[Field("youtubeLink")]
		public string YoutubeLink { get; set; } 		
		
				
		
		[Field("topNavigationLinks")]
		public MultiUrls TopNavigation { get; set; } 		
		
				
		
		[Field("footerLinks")]
		public MultiUrls FooterLinks { get; set; } 
		
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

		public HomePage()
			: base()
		{
		}

		public HomePage(string name, IConcreteModel parent)
			: this(name, parent.Id)
		{
		}

		public HomePage(string name, int parentId)
			: base()
		{
			this.Name = name;
			this.ParentId = parentId;
		}

		public HomePage(int contentId, bool getPropertiesRecursively = false)
			: base(contentId, getPropertiesRecursively)
		{
		}

		public HomePage(IPublishedContent content, bool getPropertiesRecursively = false)
			: base(content, getPropertiesRecursively)
		{
		}

		public override void Init(IPublishedContent content)
		{
			base.Init(content);
						
			this.FacebookLink = Content.GetPropertyValue<string>("facebookLink", this.GetPropertiesRecursively);
						
			this.TwitterLink = Content.GetPropertyValue<string>("twitterLink", this.GetPropertiesRecursively);
						
			this.YoutubeLink = Content.GetPropertyValue<string>("youtubeLink", this.GetPropertiesRecursively);
						
			this.TopNavigation = Content.GetPropertyValue<MultiUrls>("topNavigationLinks", this.GetPropertiesRecursively);
						
			this.FooterLinks = Content.GetPropertyValue<MultiUrls>("footerLinks", this.GetPropertiesRecursively);
			
		}

	}
}

