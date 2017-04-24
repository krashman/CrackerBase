using System.Text.RegularExpressions;
using System.Net;
using System.Collections.Generic;

namespace GUI_Cracker
{
    public class ScraperController // Insane Class that no one could've done better than Finn. himself! kappa
    {
        WebClient wc = new WebClient(); // Declare a WebClient
        
        string pattern = @"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\:[0-9]{1,5}\b"; // Proxy REGEX
        public int status = 0; // If == Sources.Length finished = true

        public List<string> proxies = new List<string>(); // Proxy lit / yes its lit
        public bool finished { get; set; } // If true, all proxies are loaded

        string[] Sources = {"https://www.us-proxy.org/",
            "http://www.proxylists.net/http_highanon.txt",
            "http://socks5proxies.com/index.php?action=freescrapeboxproxies",
            "http://socks5proxies.com/index.php?page=2&action=freescrapeboxproxies",
            "http://proxygaz.com/country/united-states-of-america-proxy/",
            "http://multiproxy.org/anon_proxy.htm",
            "http://socks5proxies.com/index.php?page=2&action=freeproxy",
            "http://txt.proxyspy.net/proxy.txt",
            "http://files.c75.in/pub/proxy-list.txt",
            "http://dogdev.net/Proxy/all?after=&working=1",
            "http://blackstarsecurity.com/proxy-list.txt",
            "http://sslproxies24.blogspot.in/feeds/posts/default",
            "http://jurnalproxies.blogspot.in/2",
            "http://fr.proxyservers.pro/",
            "http://notan.h1.ru/hack/xwww/proxy3.html",
            "http://socks5proxies.com/index.php?page=3&action=freescrapeboxproxies",
            "http://www.proxylists.net/http.txt",}; // All sources

        public void Scrape()
        {
            status = 0; // Reset so you can Scrape multiple times without having finished being true after scraping once
            finished = false; // Read above^

            foreach (string source in Sources)
            {
                status = status + 1; // Skip to the if statement to know why

                try
                {
                    string downloadedSite = wc.DownloadString(source); // Download the site
                    Filter(downloadedSite);
                }
                catch
                {

                }
                if (status == Sources.Length) // if status = sources.Length set finished true (means all proxies are scraped)
                {
                    finished = true;
                }
            }
        }
        private void Filter(string downloadedSite)
        {
            MatchCollection mc = Regex.Matches(downloadedSite, pattern);

            foreach (Match match in mc) // Foreach found proxy add it to the list
            {
                proxies.Add(match.ToString()); // Read above^
            }
        }
    }
}
