using AutoMapper;
using Dodayi.Services.BapAPI.Data;
using Dodayi.Services.BapAPI.Dto;
using Dodayi.Services.BapAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dodayi.Services.BapAPI.Controllers
{
    [Route("api/detail")]
    [ApiController]
    [Authorize]
    public class DetailAPIController : ControllerBase
    {
        private readonly ModelContext db;
        private Response response;
        private IMapper mapper;

        public DetailAPIController(IMapper _mapper, ModelContext _db)
        {
            response = new Response();
            mapper = _mapper;
            db = _db;
        }


        [HttpGet]
        [Route("Get")]  
        public Response Get()
        {
            try
            {
                IEnumerable<Detail> objList = db.Details.ToList();
                response.Result = mapper.Map<IEnumerable<DetailDto>>(objList);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }


        [HttpPost]
        [Route("AddMakineTechizatDetail")]
        public Response AddMakineTechizatDetail([FromBody] DetailDto dto)
        {
            try
            {
                Detail obj = mapper.Map<Detail>(dto);
                db.Details.Add(obj);
                db.SaveChanges();

                response.Result = mapper.Map<DetailDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        [HttpDelete]
        [Route("DeleteMakineTechizat")]
        public Response DeleteMakineTechizat(int detailId, int tur)
        {
            try
            {
                Detail obj = db.Details.First(u => u.Id == detailId);
                db.Details.Remove(obj);
                db.SaveChanges();

                response.Result = mapper.Map<DetailDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;


            //var details = _detailService.ProjeyeIdveTureGoreDetailGetir(projectId, tur);
            //return Ok(details);

        }


        /// <summary>
        //tur 1:makine
        //tur 2:tuketım
        //tur 3:hizmet
        //tur 4:yazılım
        //tur 5:yolluk
        //tur 6:personel
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="tur"></param>
        /// <returns></returns>

        [HttpGet]
        [Route("ProjeyeIdveTureGoreDetailGetir")]
        public Response ProjeyeIdveTureGoreDetailGetir(long projectId, int? tur)
        {
            try
            {
                IEnumerable<Detail>? objList = null;

                if (tur == null)
                {
                    objList = db.Details
                    .Where(x => x.Unused == false || x.Unused == null)
                   .Where(x => x.ProjectId == projectId)
                   .Where(x => x.FromCommission == 0)
                   .Where(x => x.MalzemeDegistirmeDurum == null || (x.MalzemeDegistirmeDurum == 3 || x.MalzemeDegistirmeDurum == 4))
                   .OrderBy(x => x.Year)
                   .ToList();
                }
                else
                {
                    objList = db.Details
                    .Where(x => x.Unused == false || x.Unused == null)
                    .Where(x => x.ProjectId == projectId)
                    .Where(x => x.Code == tur)
                    .Where(x => x.FromCommission == 0)
                    .Where(x => x.MalzemeDegistirmeDurum == null || (x.MalzemeDegistirmeDurum == 3 || x.MalzemeDegistirmeDurum == 4))
                    .OrderBy(x => x.Year)
                    .ToList();
                }

                //objList = db.Details.ToList();
                response.Result = mapper.Map<IEnumerable<DetailDto>>(objList);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return response;
        }




        //[HttpPost]
        //[Route("AddTuketimDetail")]
        //public IActionResult AddTuketimDetail(int projectId, string name, string why, int count, decimal unit, int piyasaTuru, int year)
        //{
        //    Detail detail = new Detail();
        //    detail.Id = Convert.ToInt32(_detailService.GetIdTableName("DETAIL"));
        //    detail.ProjectId = projectId;
        //    detail.Name = name;
        //    detail.Why = why; // gerekçe
        //    detail.Count = count; // adet
        //    detail.Unit = unit; // tl birim fiyatı
        //    detail.Year = year;
        //    detail.PiyasaTuru = piyasaTuru; // 1 yurtıcı, 2 yurtdısı
        //    detail.Type = "tüketim"; // tüketim alımından geldıgı ıcın type 
        //    detail.Code = 2;        // ve code kısmını set ettık.
        //    detail.Sum = count * unit; // tl birim fiyat * adet

        //    // bu kısımlar oracle null yerıne 0 atadıgı ıcın null yaptım.
        //    detail.KdvPrice = null;
        //    detail.Alindi = null;
        //    detail.Kalan = null;
        //    detail.Status = null;
        //    // ama ekleme ıslemınde hala 0 yapıyor sonrdan bakılması gerekır.
        //    if (detail != null)
        //    {
        //        _detailService.Add(detail);
        //        return Ok("İşleminiz başarı ile gerçekleştirilmiştir.");
        //    }
        //    return BadRequest("İşleminiz gerçekleştirilememiştir.");
        //}

        //[HttpPost]
        //[Route("AddHizmetDetail")]
        //public IActionResult AddHizmetDetail(int projectId, string name, string hizmetTanim, string why, int count, decimal unit, int piyasaTuru, int year)
        //{
        //    Detail detail = new Detail();
        //    detail.Id = Convert.ToInt32(_detailService.GetIdTableName("DETAIL"));
        //    detail.ProjectId = projectId;
        //    detail.Name = name;
        //    detail.Why = why; // gerekçe
        //    detail.Count = count; // adet
        //    detail.Unit = unit; // tl birim fiyatı
        //    detail.Year = year;
        //    detail.PiyasaTuru = piyasaTuru; // 1 yurtıcı, 2 yurtdısı
        //    detail.Type = "hizmet"; // hizmet alımından geldıgı ıcın type 
        //    detail.Code = 3;        // ve code kısmını set ettık.
        //    detail.Sum = count * unit; // tl birim fiyat * adet
        //    detail.HizmetTanimi = hizmetTanim;

        //    // bu kısımlar oracle null yerıne 0 atadıgı ıcın null yaptım.
        //    detail.KdvPrice = null;
        //    detail.Alindi = null;
        //    detail.Kalan = null;
        //    detail.Status = null;
        //    // ama ekleme ıslemınde hala 0 yapıyor sonrdan bakılması gerekır.
        //    if (detail != null)
        //    {
        //        _detailService.Add(detail);
        //        return Ok("İşleminiz başarı ile gerçekleştirilmiştir.");
        //    }
        //    return BadRequest("İşleminiz gerçekleştirilememiştir.");
        //}

        //[HttpPost]
        //[Route("AddYazilimDetail")]
        //public IActionResult AddYazilimDetail(int projectId, string name, string technicalPro, string why, int count, decimal unit, decimal unitUsd, int piyasaTuru, int year)
        //{
        //    Detail detail = new Detail();
        //    detail.Id = Convert.ToInt32(_detailService.GetIdTableName("DETAIL"));
        //    detail.ProjectId = projectId;
        //    detail.Name = name;
        //    detail.Why = why; // gerekçe
        //    detail.Count = count; // adet
        //    detail.Unit = unit; // tl birim fiyatı
        //    detail.Year = year;
        //    detail.PiyasaTuru = piyasaTuru; // 1 yurtıcı, 2 yurtdısı
        //    detail.Type = "yazilim"; // yazılım alımından geldıgı ıcın type 
        //    detail.Code = 4;        // ve code kısmını set ettık.
        //    detail.Sum = count * unit; // tl birim fiyat * adet
        //    detail.TechnicalPros = technicalPro;
        //    detail.Unitusd = unitUsd;

        //    // bu kısımlar oracle null yerıne 0 atadıgı ıcın null yaptım.
        //    detail.KdvPrice = null;
        //    detail.Alindi = null;
        //    detail.Kalan = null;
        //    detail.Status = null;
        //    // ama ekleme ıslemınde hala 0 yapıyor sonrdan bakılması gerekır.
        //    if (detail != null)
        //    {
        //        _detailService.Add(detail);
        //        return Ok("İşleminiz başarı ile gerçekleştirilmiştir.");
        //    }
        //    return BadRequest("İşleminiz gerçekleştirilememiştir.");
        //}

        //[HttpPost]
        //[Route("AddYollukDetail")]
        //public IActionResult AddYollukDetail(int projectId, string name, string yetkinlik, decimal ulasimBedel, decimal gundelikBedel, decimal konaklamaBedel, DateTime gidisTarih, string kisiBilgi, string nitelik, string amac, string gereklilik, string katki, DateTime donusTarih, int ulkeId, string sehir, decimal unitUsd, int year)
        //{
        //    Detail detail = new Detail();
        //    detail.Id = Convert.ToInt32(_detailService.GetIdTableName("DETAIL"));
        //    detail.ProjectId = projectId;
        //    detail.Name = name;
        //    detail.Year = year;
        //    detail.Type = "yolluk"; // yolluk alımından geldıgı ıcın type 
        //    detail.Code = 5;        // ve code kısmını set ettık.
        //    detail.Sum = ulasimBedel + konaklamaBedel + gundelikBedel; // ulasım bedeli+konaklamabedeli+gundelikbedel
        //    detail.UlkeId = ulkeId;
        //    detail.Sehir = sehir;
        //    detail.GidisTarihi = gidisTarih;
        //    detail.DonusTarihi = donusTarih;
        //    detail.Unitusd = unitUsd;
        //    detail.Amac = amac;
        //    detail.Katki = katki;
        //    detail.Gereklilik = gereklilik;
        //    detail.Nitelik = nitelik;
        //    detail.KisiBilgi = kisiBilgi;
        //    detail.Yetkinlik = yetkinlik;
        //    detail.UlasimBedeli = ulasimBedel;
        //    detail.KonaklamaBedeli = konaklamaBedel;
        //    detail.GundelikBedeli = gundelikBedel;
        //    detail.AraziFormuId = 1;

        //    // bu kısımlar oracle null yerıne 0 atadıgı ıcın null yaptım.
        //    detail.KdvPrice = null;
        //    detail.Alindi = null;
        //    detail.Kalan = null;
        //    detail.Status = null;
        //    // ama ekleme ıslemınde hala 0 yapıyor sonrdan bakılması gerekır.
        //    if (detail != null)
        //    {
        //        _detailService.Add(detail);
        //        return Ok("İşleminiz başarı ile gerçekleştirilmiştir.");
        //    }
        //    return BadRequest("İşleminiz gerçekleştirilememiştir.");
        //}

        //[HttpGet]
        //[Route("GetProjeDetailsByProjectIdAndCode")]
        //public IActionResult GetProjeDetailsByProjectIdAndCode(int projectId, int code)
        //{
        //    //code 1: makıne
        //    //code 2: tuketım
        //    //code 3: hizmet
        //    //code 4: yazılım
        //    //code 5: yolluk
        //    //code 6: personel
        //    var details = _detailService.GetProjeDetailsByProjectIdAndCode(projectId, code);
        //    return Ok(details);
        //}

        //[HttpGet]
        //[Route("ProjeOnerilenButceGetir")]
        //public IActionResult ProjeOnerilenButceGetir(int projectId)
        //{
        //    double sonuc = _detailService.OnerilenButce(projectId);
        //    return Ok(sonuc);
        //}


    }
}
