using DotNetEnv;

namespace montiepy2.Core.Services.KeyStorage
{
    public class KeyVault : IKeyStorage
    {

        public string? RetrieveByKey(string key)
        {
            Env.Load();
            return Environment.GetEnvironmentVariable(key);
        }
    }
}