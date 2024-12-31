using Dodayi.Web.Models;
using Dodayi.Web.Service.IService;
using Dodayi.Web.Utility;

namespace Dodayi.Web.Service
{
    public class DetailService : IDetailService
    {
         private readonly IBaseService _baseService;

        public DetailService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<Response?> GetAllDetaiAsync()
        {
            return await _baseService.SendAsync(new Request
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BapAPIBase + "/api/detail/get",
            });
        }


        public async Task<Response?> AddMakineTechizatDetailAsync(DetailDto detailDto)
        {
            return await _baseService.SendAsync(new Request
            {
                ApiType = SD.ApiType.POST,
                Url = SD.BapAPIBase + "/api/detail/AddMakineTechizatDetail",
                Data = detailDto
            });
        }

        public async Task<Response?> ProjeyeIdveTureGoreDetailGetirAsync(long projectId, int? tur)
        {
            return await _baseService.SendAsync(new Request
            {
                ApiType = SD.ApiType.GET,  
                // Query String 
                Url = $"{SD.BapAPIBase}/api/detail/ProjeyeIdveTureGoreDetailGetir?projectId={projectId}&tur={tur}"

            });
        }

    }
}
