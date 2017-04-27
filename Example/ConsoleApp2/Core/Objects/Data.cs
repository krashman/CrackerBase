using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cracker.Core.Objects
{
    public class Data
    {
        [JsonProperty(PropertyName = "need_https")]
        public bool NeedHttps { get; set; }

        [JsonProperty(PropertyName = "modhash")]
        public string ModHash { get; set; }

        [JsonProperty(PropertyName = "cookie")]
        public string Cookie { get; set; }
    }
}
