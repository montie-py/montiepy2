namespace montiepy2.AbstractHandlers
{
    public abstract class AbstractFileHandler
    {
        protected bool FileIsEmpty(string FileName)
        {
            FileInfo fileInfo = new FileInfo(FileName);
            if (fileInfo.Length == 0) {
                return true;
            }
            return false;
        }

        protected void CreateFileIfNotExists(string FileName)
        {
            if (!File.Exists(FileName)) {
                File.Create(FileName);
            }
        }
    }
}