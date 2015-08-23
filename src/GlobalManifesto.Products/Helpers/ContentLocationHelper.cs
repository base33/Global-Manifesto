using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace GlobalManifesto.Products.Helpers
{
	public static class ContentLocationHelper
	{
		const string CACHE_KEY = "ADOPTED_CHILD_PARENT";

		public static void SetLocalParent(IPublishedContent parent)
		{
			HttpContext.Current.Items.Add(CACHE_KEY, parent);
		}

		public static IPublishedContent GetLocalRoot(IPublishedContent globalNode)
		{
			var localParent = GetLocalParent(globalNode);

			if (localParent == null)
				return globalNode.AncestorOrSelf(1);

			return localParent.AncestorOrSelf(1);
		}

		public static IPublishedContent GetLocalParent(IPublishedContent globalNode)
		{
			if (HttpContext.Current.Items.Contains(CACHE_KEY))
			{
				return (IPublishedContent)HttpContext.Current.Items[CACHE_KEY];
			}

			return globalNode.Parent;
		}

		
	}
}