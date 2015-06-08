
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
	 [NodeTypeAlias("HeroSlide")]
 	public partial class HeroSlide : UmbracoContent
	{
				
		
		/// <summary>
		/// 
		/// </summary>
		[Required] 
		[Field("image")]
		public string Image { get; set; } 		
		
		private IPublishedContent _link = null;
		public IPublishedContent Link
		{
			get 
			{
				if (_link == null)
				{
					int? contentId = Content.GetPropertyValue<int?>("link");

					if (contentId.HasValue)
					{
					
						_link = UmbracoContext.Current.ContentCache.GetById(contentId.Value);
				
						
					}	
				}
				return _link;
			}
		} 
		
		public HeroSlide()
			: base()
		{
		}

		public HeroSlide(int contentId)
			: base(contentId)
		{
		}

		public HeroSlide(IPublishedContent content)
			: base(content)
		{
		}

		protected override void Init()
		{
			base.Init();
						
			this.Image = Content.GetPropertyValue<string>("image");
			
		}

		public override IContent SetProperties(IContent dbContent)
		{
						
			dbContent.SetValue("image", this.Image);
			
			return base.SetProperties(dbContent);
		}
	}
}

