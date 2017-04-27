using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cracker.Core.Controllers;
using Cracker.Core.Enumerations;
using Cracker.Core.Models;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = Console.ReadLine();
            Account account = new Account(username, password);
            switch (RedditController.Validate(account))
            {
                    case LoginResponse.Success:
                        Console.WriteLine($"Working Account: {account.ToString()}");
                    break;
                    case LoginResponse.Fail:
                        Console.WriteLine($"Wrong Account: {account.ToString()}");
                    break;
                    case LoginResponse.Error:
                        Console.WriteLine($"Error on account {account.ToString()}");
                    break;
                default:
                    Console.WriteLine($"Error on account {account.ToString()}");
                    break;
            }
        }
    }
}
