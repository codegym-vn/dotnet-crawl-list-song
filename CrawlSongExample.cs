using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RegularExpressions
{
    class Program
    {
        static void Main()
        {
            HtmlWeb htmlWeb = new HtmlWeb()
            {
                AutoDetectEncoding = false, 
            };
            Console.OutputEncoding = Encoding.UTF8;
            //Load trang web, nạp html vào document
            HtmlDocument document = htmlWeb.Load("https://www.nhaccuatui.com/bai-hat/nhac-tre-moi.html");
            //Load các tag li trong tag ul
            var listGenre = document.DocumentNode.SelectNodes("//ul[@class='listGenre']/li").ToList();

            var items = new List<object>();
            string getAtag = @"<\s*a[^>]*>(.*?)";
            string getTitleAttribute = @"title+\W\D+";
            string songNamePatern = @"'+\w+\D+\s";
            foreach (var item in listGenre)
            {
                Match match = Regex.Match(item.InnerHtml, getAtag);
                string titleAttribute = Regex.Match(match.Value, getTitleAttribute).Value;
                titleAttribute = titleAttribute.Replace("\"", "'");
                string songName = Regex.Match(titleAttribute, songNamePatern).Value.Replace("'", "");
                Console.WriteLine(songName);

            }

        }

    }
}
