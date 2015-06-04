using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Examine.Linq.Attributes;

namespace GlobalManifesto.Products.Models
{
	public partial class Product
	{
		[Field("nodeName")]
		new public string Name { get; set; }
	}
}