using System.Text;

namespace montiepy2.Core.AbstractHandlers
{
    public abstract class  AbstractFileHandler
    {
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