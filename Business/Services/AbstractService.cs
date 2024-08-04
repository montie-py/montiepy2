using montiepy2.Business.Providers;

namespace montiepy2.Business.Services{
    public  class AbstractService{
        protected ProviderInterface Db = new FileProvider();
    }
}