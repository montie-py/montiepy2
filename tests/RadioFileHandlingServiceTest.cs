using Xunit;
using montiepy2.Services.Radio;

public class RadioFileHandlingServiceTest
{
    [Fact]
    public void TestDataIsSavedIntoFile()
    {
       var radioFileHandlingService = new RadioFileHandlingService("tests.txt");
       var fileEntries = new List<Dictionary<string, string>>{
        new Dictionary<string, string>{
           ["url"] = "url1",
           ["date"] = "date1"  
        }, 
        new Dictionary<string, string>{
           ["url"] = "url2",
           ["date"] = "date2"  
        } 
       };
       radioFileHandlingService.WriteEntriesToFile(fileEntries);
       var fileEntriesEquals = radioFileHandlingService.GetEntriesFromFile();
        Assert.Equal(fileEntries, fileEntriesEquals);
    }
}