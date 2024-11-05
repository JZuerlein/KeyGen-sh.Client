using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyGen_sh.Client
{
    public class AccessToken
    {
        private static readonly TimeSpan Threshold = new TimeSpan(0, 5, 0);

        public AccessToken(string token,
                                 string kind,
                                 DateTimeOffset expiry,
                                 DateTimeOffset created,
                                 DateTimeOffset updated)
        {
            Token = token;
            Kind = kind;
            Expiry = expiry;
            Created = created;
            Updated = updated;
        }

        public virtual string Token { get; }
        public string Kind { get; }
        public DateTimeOffset Expiry { get; }
        public DateTimeOffset Created { get; }
        public DateTimeOffset Updated { get; }
        public virtual bool Expired => (Expiry - DateTime.UtcNow).TotalSeconds <= Threshold.TotalSeconds;
    }
}
