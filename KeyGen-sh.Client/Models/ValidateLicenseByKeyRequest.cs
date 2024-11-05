using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyGen_sh.Client.Models
{
    public class ValidateLicenseByKeyRequest
    {
        public ValidateLicenseByKeyMeta meta { get; set; } = new ValidateLicenseByKeyMeta();
        public class ValidateLicenseByKeyMeta
        {
            public string key { get; set; } = string.Empty;
            public int nonce { get; set; }
            public ValidateLicenseByKeyScope scope { get; set; } = new ValidateLicenseByKeyScope();

            public class ValidateLicenseByKeyScope
            {
                public string fingerprint { get; set; } = string.Empty;
            }

        }
    }
}
