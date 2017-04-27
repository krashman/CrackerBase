using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cracker.Core.Models;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;

namespace Cracker.Core.Controllers
{
    class ProxyController
    {
        public List<Proxy> Proxies = new List<Proxy>();
        private int line = 0;
        private string[] proxy = new string[1];

        public void LoadProxies()
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName))
                    {

                        while (!sr.EndOfStream)
                        {

                            Proxies.Add(new Proxy());
                            proxy = sr.ReadLine().Split(':');
                            Proxies[line].IP = proxy[0];
                            Proxies[line].Port = proxy[1];
                            line++;
                        }
                    }
                }
            }
        }

    }
}

