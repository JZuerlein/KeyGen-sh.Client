

namespace KeyGen_sh.Client.Models
{
    public class Machine
    {
        public MachineData data { get; set; } = new MachineData();
        public class MachineData
        {
            public string id { get; set; } = string.Empty;
            public string type { get; set; } = string.Empty;
            public MachineDataAttribute attributes { get; set; } = new MachineDataAttribute();

            public class MachineDataAttribute
            {
                public string fingerprint { get; set; } = string.Empty;
                public string platform { get; set; } = string.Empty;
                public string hostname { get; set; } = string.Empty;
                public string name { get; set; } = string.Empty;
                public string ip { get; set; } = string.Empty;
                public string heartbeatStatus { get; set; } = string.Empty;
                public int heartbeatDuration { get; set; }
                public DateTimeOffset lastHeartbeat { get; set; }
                public DateTimeOffset nextHeartbeat { get; set; }
            }
        }
    }
}
