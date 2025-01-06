using Dodayi.Web.Models;

namespace Dodayi.Web.Service.IService
{
    public interface IDetailService
    {
        Task<ResponseDto?> GetAllDetaiAsync();
        Task<ResponseDto?> AddMakineTechizatDetailAsync(DetailDto detailDto);
        Task<ResponseDto?> ProjeyeIdveTureGoreDetailGetirAsync(long projectId, int? tur);
    }
}
