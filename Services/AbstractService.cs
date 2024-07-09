using montiepy2.Providers;

namespace montiepy2.Services{
    public  class AbstractService{
        protected ProviderInterface Db = new FileProvider();
    }
}