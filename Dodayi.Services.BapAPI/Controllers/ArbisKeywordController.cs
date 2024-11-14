using Dodayi.Services.BapAPI.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dodayi.Services.BapAPI.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class ArbisKeywordController : ControllerBase
    //{
    //}

    [Route("api/[controller]")]
    [ApiController]
    public class ArbisKeywordController : ControllerBase
    {
        readonly IArbisKeywordService _arbisKeywordService;
        public ArbisKeywordController(IArbisKeywordService arbisKeywordService)
        {
            _arbisKeywordService = arbisKeywordService;
        }

        [HttpGet]
        [Route("ArbisKeywordList")]
        public IActionResult ArbisKeywordList(int id)
        {
            var list = _arbisKeywordService.GetArbisKeys(id);
            if (list != null)
            {
                return Ok(list);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("ArbisKeyword")]
        public IActionResult ArbisKeyword(int id)
        {
            var arbisKeyword = _arbisKeywordService.GetArbisKey(id);
            if (arbisKeyword != null)
            {
                return Ok(arbisKeyword);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
