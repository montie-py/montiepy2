using montiepy2.Core.AbstractHandlers;

namespace montiepy2.Core.Services.KeyStorage
{
    public class FileStorage : AbstractFileHandler, IKeyStorage
    {
        private const string KeysFileName = "keys.txt";
        private static IDictionary<string, string> _keyStorage = new Dictionary<string, string>();
        public string? RetrieveByKey(string key)
        {
            if (!_keyStorage.ContainsKey(key)) {
                FillKeyStorage();
            }

            return _keyStorage[key];
        }

        private void FillKeyStorage()
        {
            string fileContents = ReadAllText(KeysFileName);
            foreach (string entry in fileContents.Split("\r\n")) {
                var EntryData = entry.Split("=");
                _keyStorage[EntryData[0]] = EntryData[1];
            }
        }
    }
}