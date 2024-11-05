using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyGen_sh.Client
{
    public class LicenseFile
    {
        public string enc { get; set; } = string.Empty;
        public string sig { get; set; } = string.Empty;
        public string alg { get; set; } = string.Empty;
    }
}
