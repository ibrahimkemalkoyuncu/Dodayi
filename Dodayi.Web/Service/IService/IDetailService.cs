using Dodayi.Web.Models;

namespace Dodayi.Web.Service.IService
{
    public interface IDetailService
    {
        Task<Response?> GetAllDetaiAsync();
        Task<Response?> AddMakineTechizatDetailAsync(DetailDto detailDto);
        Task<Response?> ProjeyeIdveTureGoreDetailGetirAsync(long projectId, int? tur);
    }
}
