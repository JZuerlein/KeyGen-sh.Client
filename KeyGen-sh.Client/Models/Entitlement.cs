using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyGenClient.Models
{
    public class Entitlement : IncludeBase
    {
        public string id { get; set; } = string.Empty;
        public EntitlementAttribute attributes { get; set; } = new EntitlementAttribute();

        public class EntitlementAttribute
        {
            public string name { get; set; } = string.Empty;
            public string code { get; set; } = string.Empty;
            public DateTimeOffset created { get; set; }
            public DateTimeOffset updated { get; set; }
        }
    }
}
