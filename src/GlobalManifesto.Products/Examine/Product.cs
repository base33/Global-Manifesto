using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Examine.Linq.Attributes;

namespace GlobalManifesto.Products.Examine
{
    [NodeTypeAlias("Product")]
    public class Product
    {
        [Field("id")]
        public int Id { get; set; }
        [Field("nodeName")]
        public string Name { get; set; }
        [Field("urlName")]
        public string UrlName { get; set; }
        [Field("level")]
        public int Level { get; set; }
        [Field("url")]
        public string Url { get; set; }
    }
}