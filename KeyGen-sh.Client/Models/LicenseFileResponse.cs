

namespace KeyGen_sh.Client.Models
{
    public class LicenseFileResponse
    {
        public LicenseFileData data { get; set; } = new LicenseFileData();
        public List<IncludeBase> included { get; set; } = new List<IncludeBase>();
        public class LicenseFileData
        {
            public string id { get; set; } = string.Empty;
            public string type { get; set; } = string.Empty;
            public LicenseFileAttribute attributes { get; set; } = new LicenseFileAttribute();
            public LicenseFileDataRelationship relationships { get; set; } = new LicenseFileDataRelationship();
            public class LicenseFileAttribute
            {
                public string name { get; set; } = string.Empty;
                public string key { get; set; } = string.Empty;
                public string status { get; set; } = string.Empty;
                public bool suspended { get; set; } = false;
                public bool requireHeartbeat { get; set; } = false;
                public bool requireCheckin { get; set; } = false;
                public DateTimeOffset? lastValidated { get; set; }
                public DateTimeOffset? lastCheckIn { get; set; }
                public DateTimeOffset? nextCheckIn { get; set; }
                public DateTimeOffset? lastCheckOut { get; set; }
                public string certificate { get; set; } = string.Empty;
                public int ttl { get; set; }
                public DateTimeOffset? expiry { get; set; }
                public DateTimeOffset issued { get; set; }
            }

            public class LicenseFileDataRelationship
            {
                public LicenseFileDataRelationshipLicense license { get; set; } = new LicenseFileDataRelationshipLicense();
                public class LicenseFileDataRelationshipLicense
                {
                    public LicenseFileDataRelationshipLicenseData data { get; set; } = new LicenseFileDataRelationshipLicenseData();
                    public class LicenseFileDataRelationshipLicenseData
                    {
                        public string type { get; set; } = string.Empty;
                        public string id { get; set; } = string.Empty;
                    }
                }
            }
        }



    }
}
