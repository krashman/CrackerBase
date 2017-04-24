using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Cracker.Core.Objects
{
    class Response
    {
        [JsonProperty(PropertyName = "json")]
        public Json Json { get; set; }
    }
}
