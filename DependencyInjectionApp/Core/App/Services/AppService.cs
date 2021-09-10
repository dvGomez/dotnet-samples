using Domain.App.Services;

namespace Core.App.Services
{
    public class AppService : IAppService
    {
        public string HelloWorld()
        {
            return "Hello World?";
        }
    }
}
