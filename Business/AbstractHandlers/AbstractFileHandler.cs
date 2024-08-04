using System.Text;

namespace montiepy2.Business.AbstractHandlers
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

        protected void AppendAllText(string filename, string content)
        {
            if (!File.Exists(filename))
            {
                // Create the file
                using (FileStream fs = File.Create(filename))
                {
                    // Optionally write some data to the file
                    Byte[] info = new UTF8Encoding(true).GetBytes(content);
                    fs.Write(info, 0, info.Length);
                }
            }
            else
            {
                File.AppendAllText(filename, content);
            }
        }

        protected string ReadAllText(string filename)
        {
            string result;
            if (!File.Exists(filename))
            {
                // Create the file
                using (FileStream fs = File.Create(filename))
                {
                    
                }
                result = "";
            }
            else
            {
                result = File.ReadAllText(filename);
            }

            return result;
        }
    }
}