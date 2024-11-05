using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyGen_sh.Client.Models
{
    public class ActivateMachineRequest
    {
        public ActivateMachineData data { get; set; } = new ActivateMachineData();

        public class ActivateMachineData
        {
            public string type { get; set; } = string.Empty;
            public ActivateMachineAttribute attributes { get; set; } = new ActivateMachineAttribute();
            public ActivateMachineRelationship relationships { get; set; } = new ActivateMachineRelationship();
            public class ActivateMachineAttribute
            {
                public string fingerprint { get; set; } = string.Empty;
                public string platform { get; set; } = string.Empty;
                public string name { get; set; } = string.Empty;
            }
            public class ActivateMachineRelationship
            {
                public ActivateMachineLicense license { get; set; } = new ActivateMachineLicense();
                public class ActivateMachineLicense
                {
                    public ActivateMachineLicenseData data { get; set; } = new ActivateMachineLicenseData();
                    public class ActivateMachineLicenseData
                    {
                        public string type { get; set; } = string.Empty;
                        public string id { get; set; } = string.Empty;
                    }
                }
            }
        }
    }
}
