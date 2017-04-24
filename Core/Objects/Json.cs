using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Cracker.Core.Objects
{
    public class Json
    {
        [JsonProperty(PropertyName = "errors")]
        public List<object> Errors { get; set; }

        [JsonProperty(PropertyName = "data")]
        public Data Data { get; set; }
    }
}
