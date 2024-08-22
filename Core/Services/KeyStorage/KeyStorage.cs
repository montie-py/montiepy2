namespace montiepy2.Core.Services.KeyStorage
{
    public abstract class KeyStorage : IKeyStorage
    {
        public string? FindByKey(string key)
        {
            return RetrieveByKey(key);
        }

        protected abstract string? RetrieveByKey(string key);
    }
}