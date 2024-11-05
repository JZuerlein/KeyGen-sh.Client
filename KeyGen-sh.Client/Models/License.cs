using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyGen_sh.Client.Models
{
    public class License
    {
        public LicenseMeta meta { get; set; } = new LicenseMeta();
        public class LicenseMeta
        {
            public bool valid { get; set; }
            public string detail { get; set; } = string.Empty;
            public string code { get; set; } = string.Empty;
            public int nonce { get; set; }
            public LicenseScope scope { get; set; } = new LicenseScope();

            public class LicenseScope
            {
                public string fingerprint { get; set; } = string.Empty;
            }
        }

        public LicenseData data { get; set; } = new LicenseData();
        public class LicenseData
        {
            public string id { get; set; } = string.Empty;
            public string type { get; set; } = string.Empty;
            public LicenseAttributes attributes { get; set; } = new LicenseAttributes();

            public class LicenseAttributes
            {
                public string key { get; set; } = string.Empty;
                public DateTimeOffset? expiry { get; set; }
                public string status { get; set; } = string.Empty;
                public bool requiresHeartbeat { get; set; }
            }
        }
    }
}
