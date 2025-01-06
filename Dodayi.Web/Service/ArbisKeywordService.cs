using Dodayi.Web.Models;
using Dodayi.Web.Service.IService;
using Dodayi.Web.Utility;

namespace Dodayi.Web.Service
{
    public class ArbisKeywordService : IArbisKeywordService
    {
        private readonly IBaseService _baseService;

        public ArbisKeywordService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> GetListByParentIdAsync(int parentId)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BapAPIBase + "/api/arbiskeyword/byParent/" + parentId,
            }); 
        }

        public async Task<ResponseDto?> GetByIdAsync(int Id)
        {
            return await _baseService.SendAsync(new RequestDto
            {
                ApiType = SD.ApiType.GET,
                Url = SD.BapAPIBase + "/api/arbiskeyword/byId/" + Id,
            });
        }

        
    }
}
