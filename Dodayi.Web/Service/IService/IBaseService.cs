using Dodayi.Web.Models;

namespace Dodayi.Web.Service.IService
{
    public interface IBaseService
    {
        Task<Response?> SendAsync(Request request);
    }
}
