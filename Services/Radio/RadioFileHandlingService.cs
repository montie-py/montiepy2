

namespace montiepy2.Services.Radio {
    public class RadioFileHandlingService
    {
        static string FileName {get; set;} = null!;
        public RadioFileHandlingService(string filename) {
            FileName = filename;
        }
        public bool FileUpdatedToday()
        {
            CreateFileIfNotExists();
            if (FileIsEmpty()) {
                return false;
            }

            DateTime lastModifiedDate = File.GetLastWriteTime(FileName);
            return lastModifiedDate == DateTime.Today;
        }

        private bool FileIsEmpty()
        {
            FileInfo fileInfo = new FileInfo(FileName);
            if (fileInfo.Length == 0) {
                return true;
            }
            return false;
        }

        private void CreateFileIfNotExists()
        {
            if (!File.Exists(FileName)) {
                File.Create(FileName);
            }
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