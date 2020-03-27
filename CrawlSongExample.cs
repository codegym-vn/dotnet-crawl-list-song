using HtmlAgilityPack;
using System; 
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RegularExpressions
{
    class Program
    {
        static void Main()
        {
            HtmlWeb htmlWeb = new HtmlWeb();
            Console.OutputEncoding = Encoding.UTF8;
            //Load trang web, nạp html vào document
            HtmlDocument document = htmlWeb.Load("https://www.nhaccuatui.com/bai-hat/nhac-tre-moi.html");
            //Load các tag li trong tag ul
            var listGenre = document.DocumentNode.SelectNodes("//ul[@class='listGenre']/li").ToList();
 
            foreach (var item in listGenre)
            {
                Match match = Regex.Match(item.InnerHtml, @"<\s*a[^>]*>(.*?)");
                string titleAttribute = Regex.Match(match.Value, @"title+\W\D+").Value;
                titleAttribute = titleAttribute.Replace("\"", "'");
                string songName = Regex.Match(titleAttribute, @"'+\w+\D+\s").Value.Replace("'", "");
                Console.WriteLine(songName);
            }
        }
    }
}
