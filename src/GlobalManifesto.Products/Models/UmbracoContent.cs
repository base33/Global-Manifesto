
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
	 [NodeTypeAlias("UmbracoContent")]
 	public class UmbracoContent : UmbracoContentBase
	{
		 [Field("nodeName")]
 		public new string Name { get; set; }
		 [Field("id")]
 		public new int Id { get; set; }
		 [Field("createDate")]
 		public new DateTime CreateDate { get; set; }
		 [Field("updateDate")]
 		public new DateTime UpdateDate { get; set; }
		 [Field("__path")]
 		public new string Path { get; set; }
		
 		public UmbracoContent()
			: base()
 		{
 		}
 
 		public UmbracoContent(int contentId)
			: base(contentId)
 		{
 		}
 
 		public UmbracoContent(IPublishedContent content)
			: base(content)
 		{
 		}

		protected override void Init()
		{
			 
			this.Name = this.Content.Name;
			 
			this.Id = this.Content.Id;
			 
			this.CreateDate = this.Content.CreateDate;
			 
			this.UpdateDate = this.Content.UpdateDate;
			 
			this.Path = this.Content.Path;
					}

		public override IContent SetProperties(IContent dbContent)
		{
			 
			dbContent.Name = this.Name;
			 
			dbContent.Id = this.Id;
			 
			dbContent.CreateDate = this.CreateDate;
			 
			dbContent.UpdateDate = this.UpdateDate;
			 
			dbContent.Path = this.Path;
			
			return base.SetProperties(dbContent);
		}
 	}
} 
