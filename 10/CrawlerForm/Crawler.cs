using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrawlerForm
{
    class Crawler
    {
        public string HostFilter { get; set; } 
        public string FileFilter { get; set; } 
        public int MaxPage { get; set; } 
        public string StartURL { get; set; } 
        public Encoding HtmlEncoding { get; set; } 
        public Dictionary<string, bool> DownloadedPages { get => urls; }
        int taskNum = 0;
        public event Action<Crawler> CrawlerStopped;
        public event Action<Crawler, string, string> PageDownloaded;
        private Dictionary<string, bool> urls = new Dictionary<string, bool>();
        private Queue<string> pending = new Queue<string>();
        private readonly string urlDetectRegex = @"(href|HREF)\s*=\s*[""'](?<url>[^""'#>]+)[""']";
        public static readonly string urlParseRegex =
            @"^(?<site>https?://(?<host>[\w\d.]+)(:\d+)?($|/))([\w\d]+/)*(?<file>[^#?]*)";
        public Crawler()
        {
            MaxPage = 100;
            HtmlEncoding = Encoding.UTF8;
        }
        public void Start()
        {
            urls.Clear();
            pending.Clear();
            pending.Enqueue(StartURL);
            int count = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (count < MaxPage )
            {               
                try
                {                  
                    if (pending.Count == 0)
                    {
                        if (taskNum == 0)
                            break;
                        continue;
                    }
                    else
                    {
                        string url = pending.Dequeue();
                        lock (this)
                        {
                            taskNum++;
                        }
                        Task task = Task.Run(() => DownLoadAndParse(url));
                    }                   
                }
                catch (Exception ex)
                {
                
                }
                count++;
            }
            CrawlerStopped(this);
            sw.Stop();
            Console.WriteLine("用时："+sw.ElapsedMilliseconds);
        }

        private void DownLoadAndParse(string url)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            string html = webClient.DownloadString(url);
            string fileName = urls.Count.ToString();
            lock (this) { File.WriteAllText(fileName, html, Encoding.UTF8); }          
            
            urls[url] = true;
            PageDownloaded(this, url, "success");
            var matches = new Regex(urlDetectRegex).Matches(html);
            foreach (Match match in matches)
            {
                string linkUrl = match.Groups["url"].Value;
                if (linkUrl == null || linkUrl == "") continue;
                linkUrl = FixUrl(linkUrl, url);

                Match linkUrlMatch = Regex.Match(linkUrl, urlParseRegex);
                string host = linkUrlMatch.Groups["host"].Value;
                string file = linkUrlMatch.Groups["file"].Value;
                if (file == "") file = "index.html";

                if (Regex.IsMatch(host, HostFilter) && Regex.IsMatch(file, FileFilter)
                  && !urls.ContainsKey(linkUrl))
                {
                    pending.Enqueue(linkUrl);
                    urls.Add(linkUrl, false);
                }
            }
            lock (this)
            {
                taskNum--;
            }
        }
        static private string FixUrl(string url, string baseUrl)
        {
            if (url.Contains("://"))
            {
                return url;
            }
            if (url.StartsWith("//"))
            {
                return "http:" + url;
            }
            if (url.StartsWith("/"))
            {
                Match urlMatch = Regex.Match(baseUrl, urlParseRegex);
                String site = urlMatch.Groups["site"].Value;
                return site.EndsWith("/") ? site + url.Substring(1) : site + url;
            }
            if (url.StartsWith("../"))
            {
                url = url.Substring(3);
                int idx = baseUrl.LastIndexOf('/');
                return FixUrl(url, baseUrl.Substring(0, idx));
            }
            if (url.StartsWith("./"))
            {
                return FixUrl(url.Substring(2), baseUrl);
            }
            int end = baseUrl.LastIndexOf("/");
            return baseUrl.Substring(0, end) + "/" + url;
        }
    }
}
