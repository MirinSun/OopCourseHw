using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EighthTask
{
    class Program
    {
        static void Main(string[] args)
        {
            WebParser webParser = new WebParser("https://ling47.ru");
            string text = webParser.FindContentInTag("li");
            Console.WriteLine(text);
        }
    }
    class WebParser : WebClient
    {
        private string _url;

        public WebParser(string url)
        {
            _url = url;
        }

        public string FindContentInTag(string tag)
        {
            string page = DownloadString(_url);

            Match match = Regex
                .Match(page, $@"<{tag}[^>]*>(?<text>[\S\s]*)</{tag}>");

            if (match.Success)
                return match.Groups["text"].ToString();
            else
                return "Тег не найден";
        }
    }
}
