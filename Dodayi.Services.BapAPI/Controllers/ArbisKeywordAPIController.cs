using AutoMapper;
using Dodayi.Services.BapAPI.Data;
using Dodayi.Services.BapAPI.Dto;
using Dodayi.Services.BapAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dodayi.Services.BapAPI.Controllers
{
    [Route("api/arbiskeyword")]
    [ApiController]
    [Authorize]

    public class ArbisKeywordAPIController : ControllerBase
    {
        //private readonly IArbisKeywordService _arbisKeywordService;
        private readonly ModelContext db;
        private Response response;
        private IMapper mapper;

        public ArbisKeywordAPIController(IMapper _mapper, ModelContext _db)
        {
            //_arbisKeywordService = arbisKeywordService;
            response = new Response();
            mapper = _mapper;
            db = _db;
        }

        [HttpGet]
        [Route("byParent/{parentId}")]
        public Response GetListByParentId(int parentId)
        {
            try
            {
                IEnumerable<ArbisKeyword> objlist = db.ArbisKeywords.Where(u=>u.ParentId == parentId).ToList();
                response.Result = mapper.Map<IEnumerable<ArbisKeywordDto>>(objlist);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        [HttpGet]
        [Route("byId/{id:int}")]
        public Response Get(int id)
        {
            try
            {
                var obj = db.ArbisKeywords.First(u => u.Id == id);
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
