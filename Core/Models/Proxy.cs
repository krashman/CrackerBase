using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cracker.Core.Models
{
    public class Proxy
    {

        public string IP { get; set; }
        public string Port { get; set; }

        public override string ToString()
        {
            return $"{IP}:{Port}";
        }

    }
}
