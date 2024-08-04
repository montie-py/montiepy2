using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using montiepy2.Business.Models;
using montiepy2.Business.Services.Radio;

namespace montiepy2.Core.Pages
{
    public class RadioModel : PageModel
    {

        public List<RadioEntry> RadioEntries { get; set; } = new();
        public void OnGet() 
        {
            IEnumerable<Dictionary<string, string>> fileRadioEntries = [];
            RadioFileHandlingService radioFileHandlingService = new("radioentries.txt");
            if (radioFileHandlingService.FileUpdatedToday()) {
                fileRadioEntries = radioFileHandlingService.GetEntriesFromFile();
            } else {
                fileRadioEntries = ParsingService.Parse();
                radioFileHandlingService.WriteEntriesToFile(fileRadioEntries);
            }
            
            foreach (var fileRadioEntry in fileRadioEntries) {
                RadioEntry radioEntry = new RadioEntry();
                radioEntry.Url = fileRadioEntry["url"];
                radioEntry.Date = DateTime.Parse(fileRadioEntry["date"]);
                RadioEntries.Add(radioEntry);
            }
        }
    }
}