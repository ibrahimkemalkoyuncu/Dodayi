using Dodayi.Web.Models;

namespace Dodayi.Web.Service.IService
{
    public interface IArbisKeywordService
    {
        Task<ResponseDto?> GetListByParentIdAsync(int parentId);
        Task<ResponseDto?> GetByIdAsync(int Id);
    }
}
