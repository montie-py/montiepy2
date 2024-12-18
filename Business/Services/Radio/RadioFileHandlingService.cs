using montiepy2.Business.AbstractHandlers;

namespace montiepy2.Business.Services.Radio {
    public class RadioFileHandlingService : AbstractFileHandler
    {
        static string FileName {get; set;} = null!;
        public RadioFileHandlingService(string filename) {
            FileName = filename;
        }
        public bool FileUpdatedToday()
        {
            CreateFileIfNotExists(FileName);
            if (FileIsEmpty(FileName)) {
                return false;
            }

            DateTime lastModifiedDate = File.GetLastWriteTime(FileName);
            return lastModifiedDate == DateTime.Today;
        }

        public void WriteEntriesToFile(IEnumerable<Dictionary<string, string>> fileEntries) 
        {
            //overwriting to the file
            using StreamWriter writer = new (FileName);
            foreach (var entry in fileEntries)
            {
                writer.WriteLine(entry["url"] + " " + entry["date"]);
            }
        }

        public IEnumerable<Dictionary<string, string>> GetEntriesFromFile()
        {
            List<Dictionary<string, string>> radioEntries = [];
            foreach (string line in File.ReadAllLines(FileName)) {
                Dictionary<string, string> entry = [];
                string[] parseLine = line.Split(" ");
                entry["url"] = parseLine[0];
                entry["date"] = parseLine[1];
                radioEntries.Add(entry);
            }
            return radioEntries;
        }
    }
}