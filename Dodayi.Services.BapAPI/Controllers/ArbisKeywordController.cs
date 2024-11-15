using AutoMapper;
using Dodayi.Services.BapAPI.Abstract;
using Dodayi.Services.BapAPI.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dodayi.Services.BapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArbisKeywordController : ControllerBase
    {
        private readonly IArbisKeywordService _arbisKeywordService;
        private Response response;
        private IMapper mapper;

        public ArbisKeywordController(IArbisKeywordService arbisKeywordService, IMapper _mapper)
        {
            _arbisKeywordService = arbisKeywordService;
            response = new Response();
            mapper = _mapper;
        }

        [HttpGet]
        [Route("ArbisKeywordList")]
        public IActionResult<Response> ArbisKeywordList(int id)
        {
            try
            {
                var list = _arbisKeywordService.GetArbisKeys(id);
                response.Result = mapper.Map<IEnumerable<ArbisKeywordDto>>(list);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return OK(response);
        }

        [HttpGet]
        [Route("ArbisKeyword")]
        public IActionResult ArbisKeyword(int id)
        {
            try
            {
                var obj = _arbisKeywordService.GetArbisKey(id);
                response.Result = mapper.Map<ArbisKeywordDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
