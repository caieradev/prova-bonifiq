namespace ProvaPub.Services
{
  public class BaseService<MainRepository>
  {
    protected readonly MainRepository _mainRepository;
    public BaseService(MainRepository repository) { _mainRepository = repository; }
  }
}