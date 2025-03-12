using AutoMapper;
using Dodayi.Services.CouponAPI.Data;
using Dodayi.Services.CouponAPI.Dto;
using Dodayi.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dodayi.Services.CouponAPI.Controllers
{
    /// <summary>
    /// Kupon yönetimi için API controller sınıfı.
    /// Kupon ekleme, silme, güncelleme ve listeleme işlemlerini gerçekleştirir.
    /// </summary>
    [Route("api/coupon")]
    [ApiController]
    [Authorize]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext db;
        private Response response;
        private IMapper mapper;

        /// <summary>
        /// CouponAPIController constructor metodu
        /// </summary>
        /// <param name="_db">Veritabanı bağlantı nesnesi</param>
        /// <param name="_mapper">AutoMapper nesnesi</param>
        public CouponAPIController(AppDbContext _db, IMapper _mapper)
        {
            db = _db;
            response = new Response();
            mapper = _mapper;
        }

        /// <summary>
        /// Tüm kuponları listeler
        /// </summary>
        /// <returns>Kupon listesi içeren Response nesnesi</returns>
        [HttpGet]
        public Response Get()
        {
            try
            {
                IEnumerable<Coupon> objList = db.Coupons.ToList();
                response.Result = mapper.Map<IEnumerable<CouponDto>>(objList);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Belirtilen ID'ye sahip kuponu getirir
        /// </summary>
        /// <param name="id">Kupon ID</param>
        /// <returns>Kupon bilgisi içeren Response nesnesi</returns>
        [HttpGet]
        [Route("{id:int}")]
        public Response Get(int id)
        {
            try
            {
                Coupon obj = db.Coupons.First(u => u.CouponId == id);      
                response.Result = mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Kupon koduna göre kupon bilgisini getirir
        /// </summary>
        /// <param name="code">Kupon kodu</param>
        /// <returns>Kupon bilgisi içeren Response nesnesi</returns>
        [HttpGet]
        [Route("GetByCode/{code}")]
        public Response GetByCode(string code)
        {
            try
            {
                Coupon obj = db.Coupons.First(u => u.CouponCode.ToLower() == code.ToLower());
                response.Result = mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Yeni kupon ekler. Sadece ADMIN rolüne sahip kullanıcılar kullanabilir.
        /// </summary>
        /// <param name="dto">Eklenecek kupon bilgisi</param>
        /// <returns>İşlem sonucunu içeren Response nesnesi</returns>
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public Response Post([FromBody] CouponDto dto)
        {
            try
            {
                Coupon obj = mapper.Map<Coupon>(dto);
                db.Coupons.Add(obj);
                db.SaveChanges();

                response.Result = mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Mevcut kuponu günceller. Sadece ADMIN rolüne sahip kullanıcılar kullanabilir.
        /// </summary>
        /// <param name="dto">Güncellenecek kupon bilgisi</param>
        /// <returns>İşlem sonucunu içeren Response nesnesi</returns>
        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public Response Put([FromBody] CouponDto dto)
        {
            try
            {
                Coupon obj = mapper.Map<Coupon>(dto);
                db.Coupons.Update(obj);
                db.SaveChanges();

                response.Result = mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Belirtilen ID'ye sahip kuponu siler. Sadece ADMIN rolüne sahip kullanıcılar kullanabilir.
        /// </summary>
        /// <param name="id">Silinecek kupon ID'si</param>
        /// <returns>İşlem sonucunu içeren Response nesnesi</returns>
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "ADMIN")]
        public Response Delete(int id)
        {
            try
            {
                Coupon obj = db.Coupons.First(u => u.CouponId == id);
                db.Coupons.Remove(obj);
                db.SaveChanges();
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
