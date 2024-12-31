using Dodayi.Web.Models;

namespace Dodayi.Web.Service.IService
{
    public interface IArbisKeywordService
    {
        Task<Response?> GetListByParentIdAsync(int parentId);
        Task<Response?> GetByIdAsync(int Id);
    }
}
