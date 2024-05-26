using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using montiepy2.Models;
using montiepy2.Services.Radio;

namespace montiepy2.Pages
{
    public class RadioModel : PageModel
    {
        public void OnGet() 
        {
            IEnumerable<Dictionary<string, string>> radioEntries = [];
            RadioFileHandlingService radioFileHandlingService = new("radioentries.txt");
            if (radioFileHandlingService.FileUpdatedToday()) {
                radioEntries = radioFileHandlingService.GetEntriesFromFile();
            } else {
                radioEntries = ParsingService.Parse();
                radioFileHandlingService.WriteEntriesToFile(radioEntries);
            }
            
            foreach (var radioEntry in radioEntries) {
                Console.WriteLine(radioEntry["name"] + " " + radioEntry["date"]);
            }
        }
    }
}