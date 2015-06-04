
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
	 [NodeTypeAlias("Navigation")]
 	public partial class Navigation : UmbracoContent
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("showInMainNav")]
		public bool ShowInMainNavigation { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("umbracoNaviHide")]
		public bool HideFromNavigation { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("thisIsARootOfAMenu")]
		public bool ThisIsARootOfAMenu { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("hideFromSiteMap")]
		public bool HideFromSiteMap { get; set; } 
		
		public Navigation()
			: base()
		{
		}

		public Navigation(int contentId)
			: base(contentId)
		{
		}

		public Navigation(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.ShowInMainNavigation = Content.GetPropertyValue<bool>("showInMainNav");
						
			this.HideFromNavigation = Content.GetPropertyValue<bool>("umbracoNaviHide");
						
			this.ThisIsARootOfAMenu = Content.GetPropertyValue<bool>("thisIsARootOfAMenu");
						
			this.HideFromSiteMap = Content.GetPropertyValue<bool>("hideFromSiteMap");
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
						
			dbContent.SetValue("showInMainNav", this.ShowInMainNavigation);
						
			dbContent.SetValue("umbracoNaviHide", this.HideFromNavigation);
						
			dbContent.SetValue("thisIsARootOfAMenu", this.ThisIsARootOfAMenu);
						
			dbContent.SetValue("hideFromSiteMap", this.HideFromSiteMap);
			
			return base.SetProperties(dbContent);
		}
	}
}

