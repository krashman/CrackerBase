using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cracker.Core.Models;
using System.Windows.Forms;
using System.IO;

namespace Cracker.Core.Controllers
{
    class AccountController
    {
        private int accountCounter = 0;
        public List<Account> Accounts = new List<Account>();
        private int line = 0;
        private string[] account = new string[1];
        public string sLine = "";
        public bool OutOfAccounts = false;
        public void LoadAccounts()
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
                            sLine = sr.ReadLine();
                            if (!String.IsNullOrWhiteSpace(sLine) || !String.IsNullOrEmpty(sLine))
                            {
                                account = sLine.Split(':');
                                Accounts.Add(new Account(account[0], account[1]));
                                line++;
                            }
                        }
                    }
                }
                ofd.Dispose();
            }
        }
    }
}

