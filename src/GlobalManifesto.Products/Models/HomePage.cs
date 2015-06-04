
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
	 [NodeTypeAlias("HomePage")]
 	public partial class HomePage : WebBlocksPage
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("facebookLink")]
		public string FacebookLink { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("twitterLink")]
		public string TwitterLink { get; set; } 		
		
		/// <summary>
		/// 
		/// </summary>
		
		[Field("youtubeLink")]
		public string YoutubeLink { get; set; } 
		
		public HomePage()
			: base()
		{
		}

		public HomePage(int contentId)
			: base(contentId)
		{
		}

		public HomePage(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.FacebookLink = Content.GetPropertyValue<string>("facebookLink");
						
			this.TwitterLink = Content.GetPropertyValue<string>("twitterLink");
						
			this.YoutubeLink = Content.GetPropertyValue<string>("youtubeLink");
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
						
			dbContent.SetValue("facebookLink", this.FacebookLink);
						
			dbContent.SetValue("twitterLink", this.TwitterLink);
						
			dbContent.SetValue("youtubeLink", this.YoutubeLink);
			
			return base.SetProperties(dbContent);
		}
	}
}

