using Cracker.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Cracker.Core.Models
{
    public class Account
    { 
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginResponse LoginResponse { get; set; }
        public CookieContainer Cookies { get; set; }
        List<Account> Accounts = new List<Account>();
        public Account(string user, string pass)
        {
            Username = user;
            Password = pass;
        }
        public override string ToString()
        {
            return $"{Username}:{Password}";
        }


    }
}
