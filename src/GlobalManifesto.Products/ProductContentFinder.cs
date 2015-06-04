using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using umbraco;
using Umbraco.Core.Models;
using Umbraco.Examine.Linq;
using Umbraco.Examine.Linq.Models;
using Umbraco.Web;
using Umbraco.Web.Routing;

namespace GlobalManifesto.Products
{
    public class ProductContentFinder : IContentFinder
    {
        public bool TryFindContent(PublishedContentRequest contentRequest)
        {
            var allNodes = new Index<Result>().Where(p => p.NodeTypeAlias == "ProductListing").ToList().OrderByDescending(p => p.SearchResult.Fields["level"]);

            //var allNodes = uQuery.GetNodesByType("EventListing").OrderByDescending(n => n.Level);

            foreach (var node in allNodes)
            {
                string fullUri = contentRequest.Uri.AbsolutePath;
                string parentUri = umbraco.library.NiceUrl(node.Id);
                bool isChild = fullUri.StartsWith(parentUri, StringComparison.InvariantCultureIgnoreCase);

                if (isChild)
                {
                    contentRequest.PublishedContent = new UmbracoHelper(UmbracoContext.Current).TypedContent(node.Id);
                    return true;
                }
            }
            return false;
        }
    }
}