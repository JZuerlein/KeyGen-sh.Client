using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyGenClient.Models
{
    public class Product : IncludeBase
    {
        public string id { get; set; } = string.Empty;
        public ProductAttribute attributes { get; set; } = new ProductAttribute();

        public class ProductAttribute
        {
            public string name { get; set; } = string.Empty;
            public string distributionStrategy { get; set; } = string.Empty;
            public string url { get; set; } = string.Empty;
            public ProductAttributeMetadata metadata { get; set; } = new ProductAttributeMetadata();
            public DateTimeOffset created { get; set; }
            public DateTimeOffset updated { get; set; }
        }

        public class ProductAttributeMetadata
        {

        }
    }
}
