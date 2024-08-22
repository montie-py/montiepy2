namespace montiepy2.Core.Services.KeyStorage
{
    public interface IKeyStorage
    {
        public string? FindByKey(string key);
    }
}