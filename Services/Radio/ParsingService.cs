using HtmlAgilityPack;

namespace montiepy2.Services.Radio 
{
    public static class ParsingService
    {
        public static string Url { get; } = "https://w4uvh.net/";

        public static IEnumerable<Dictionary<string, string>> Parse()
        {
            List<Dictionary<string, string>> newRadioEntries = new();
            var url = Url + "?C=M;O=D";

             var web = new HtmlWeb();
            var doc = web.Load(url);
            var aNodes = doc.DocumentNode.SelectNodes("//pre/a");
            int count = 0;
            foreach (var aNode in aNodes) 
            {
                if (aNode.InnerText.StartsWith("wor")) {
                    count++;
                    Dictionary<string, string> newRadioEntry = new();
                    newRadioEntry["name"] = Url + aNode.InnerText;
                    string dateSize = aNode.NextSibling.InnerText;
                    newRadioEntry["date"] =  dateSize.Trim().Split(" ")[0];
                    newRadioEntries.Add(newRadioEntry);
                }
                if (count == 2) {
                    break;
                }
            }

            return newRadioEntries;
        }
    }
}