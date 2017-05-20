using ApiDemo.Core.Entities;

namespace ApiDemo.Core.AppService
{
    public interface IAppCodeAppService
    {
        AppCode GetAppCode(string appId);
    }
}