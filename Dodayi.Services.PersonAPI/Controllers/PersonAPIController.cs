using Dodayi.Services.PersonAPI.Dto;
using Dodayi.Services.PersonAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using AutoMapper;
using Dodayi.Services.PersonAPI.Data;

namespace Dodayi.Services.PersonAPI.Controllers
{
    [Route("api/person")]
    [ApiController]
    public class PersonAPIController : ControllerBase
    {
        private readonly PersonModelContext db;
        private Response response;
        private IMapper mapper;
        public PersonAPIController(IMapper _mapper, PersonModelContext _db)
        {
            response = new Response();
            mapper = _mapper;
            db = _db;
        }
        [HttpGet]
        [Route("byId/{id:int}")]
        public Response Get(int id)
        {
            try
            {
                var obj = db.People.First(u => u.Id == id);
                response.Result = mapper.Map<PersonDto>(obj);
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            return response;
        }

        //[HttpGet]
        //[Route("GetPersonById")]
        //public IActionResult GetPersonById(long personId)
        //{
        //    var person = _personService.GetPersonById(personId);
        //    if (person != null)
        //    {
        //        return Ok(person);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //[HttpGet]
        //[Route("GetFakulteByNodeId")]
        //public IActionResult GetFakulteByNodeId(int nodeId)
        //{
        //    var node = _corpnodeService.GetCorpnode(nodeId);
        //    var fakulte = _corpnodeService.GetCorpnode(node.ParentId);
        //    return Ok(fakulte);
        //}

        //#region KimlikBilgileri
        //[HttpPost]
        //[Route("UpdatePersonKimlikBilgi")]
        //public IActionResult UpdatePersonKimlikBilgi(DateTime? birthday, DateTime? unvanAtanmaTarih, string? orcidId, string? researcherId, long personId)
        //{
        //    var person = _personService.GetPersonById(personId);

        //    if (person == null)
        //    {
        //        return BadRequest("Kullanıcı bulunamadı.");
        //    }

        //    if (orcidId != null)
        //    {
        //        if (orcidId.Length == 16 && Convert.ToDecimal(orcidId) >= 1000000000000000)
        //        {
        //            // ID geçerli, işleme devam et
        //        }
        //        else
        //        {
        //            return BadRequest("16 Haneli ORCID ID bilginizi giriniz.");
        //        }
        //    }
        //    if (researcherId != null)
        //    {
        //        if (researcherId.Length == 9 && Convert.ToDecimal(researcherId) >= 100000000)
        //        {
        //            // ID geçerli, işleme devam et
        //        }
        //        else
        //        {
        //            return BadRequest("9 Haneli Researcher  ID bilginizi giriniz.");
        //        }
        //    }

        //    person.Birthday = birthday;
        //    person.UnvanTarihi = unvanAtanmaTarih;
        //    person.OrcidId = orcidId;
        //    person.ResearcherId = researcherId;
        //    _personService.Update(person);
        //    return Ok("İşlem başarılı bir şekilde gerçekleşmiştir.");
        //}
        //#endregion

        //#region İletisimBilgileri
        //[HttpPost]
        //[Route("UpdatePersonIletisimBilgi")]
        //public IActionResult UpdatePersonIletisimBilgi(long personId, string? homePhone, string? workPhone, string? workPhone2, string? gsm, string? fax, string? email, string? emailDogrulama, string? email1)
        //{

        //    var person = _personService.GetPersonById(personId);

        //    if (person == null)
        //    {
        //        return BadRequest("Kullanıcı bulunamadı.");
        //    }

        //    if (homePhone != null)
        //    {
        //        if (Convert.ToDecimal(homePhone) >= 100000000000)
        //        {
        //            return BadRequest("Lütfen ev telefonu numarasını en fazla 11 haneli giriniz.");
        //        }
        //        if (Convert.ToDecimal(homePhone) < 1000000000)
        //        {
        //            return BadRequest("Lütfen ev telefonu numarasını en az 10 haneli giriniz.");
        //        }
        //    }

        //    if (workPhone == null || workPhone == "")
        //    {
        //        return BadRequest("Lütfen iş telefonu numaranızı giriniz.");
        //    }

        //    if (Convert.ToDecimal(workPhone) >= 100000000000)
        //    {
        //        return BadRequest("Lütfen iş telefonu numarasını en fazla 11 haneli giriniz.");
        //    }

        //    if (Convert.ToDecimal(workPhone) < 1000000000)
        //    {
        //        return BadRequest("Lütfen iş telefonu numarasını en az 10 haneli giriniz.");
        //    }

        //    if (workPhone2 != null)
        //    {
        //        if (Convert.ToDecimal(workPhone2) >= 100000000000)
        //        {
        //            return BadRequest("Lütfen diğer iş telefonu numarasını en fazla 11 haneli giriniz.");
        //        }
        //        if (Convert.ToDecimal(workPhone2) < 1000000000)
        //        {
        //            return BadRequest("Lütfen diğer iş telefonu numarasını en az 10 haneli giriniz.");
        //        }
        //    }

        //    if (gsm != null)
        //    {
        //        if (Convert.ToDecimal(gsm) >= 100000000000)
        //        {
        //            return BadRequest("Lütfen gsm numarasını en fazla 11 haneli giriniz.");
        //        }
        //        if (Convert.ToDecimal(gsm) < 1000000000)
        //        {
        //            return BadRequest("Lütfen gsm numarasını en az 10 haneli giriniz.");
        //        }
        //    }

        //    if (fax != null)
        //    {
        //        if (Convert.ToDecimal(fax) >= 100000000000)
        //        {
        //            return BadRequest("Lütfen fax numarasını en fazla 11 haneli giriniz.");
        //        }
        //        if (Convert.ToDecimal(fax) < 1000000000)
        //        {
        //            return BadRequest("Lütfen fax numarasını en az 10 haneli giriniz.");
        //        }
        //    }

        //    if (email == null || email == "")
        //    {
        //        return BadRequest("Lütfen E-mail adresini giriniz.");
        //    }

        //    if (emailDogrulama == null || emailDogrulama == "")
        //    {
        //        return BadRequest("Lütfen E-mail doğrulama için e-posta adresini tekrar giriniz.");
        //    }

        //    if ((!email.Contains("@bogazici.edu.tr")) || (!emailDogrulama.Contains("@bogazici.edu.tr")))
        //    {
        //        return BadRequest("Lütfen sadece boğaziçi uzantılı email adresinizi giriniz. Örnek:ornek@bogazici.edu.tr");
        //    }

        //    if (email != emailDogrulama)
        //    {
        //        return BadRequest("E-posta adresleri eşleşmiyor. Lütfen aynı e-posta adresini girin");
        //    }

        //    person.HomePhone = homePhone;
        //    person.WorkPhone = workPhone;
        //    person.WorkPhone2 = workPhone2;
        //    person.Gsm = gsm;
        //    person.Fax = fax;
        //    person.Email = email;
        //    person.Email1 = email1;
        //    _personService.Update(person);

        //    return Ok("İşlem başarılı bir şekilde gerçekleşmiştir.");
        //}
        //#endregion

        //#region EgitimBilgileri
        //[HttpGet]
        //[Route("GetPersonEgitimBilgileri")]
        //public IActionResult GetPersonEgitimBilgileri(long personId)
        //{
        //    var educations = _educationService.GetAllEducationByPersonId(personId);
        //    return Ok(educations);
        //}

        //[HttpGet]
        //[Route("GetPersonEgitimBilgisi")]
        //public IActionResult GetPersonEgitimBilgisi(int id)
        //{
        //    var education = _educationService.GetEducationById(id);
        //    return Ok(education);
        //}

        //[HttpPost]
        //[Route("AddPersonEgitimBilgileri")]
        //public IActionResult AddPersonEgitimBilgileri(long personId, string? egitimTuru, int? baslangicYili, int? bitisYili, string? universite, string? alan)
        //{
        //    var education = new Education();
        //    education.Id = Convert.ToInt32(_educationService.GetIdTableName("EDU"));

        //    if (egitimTuru == null || egitimTuru == "")
        //    {
        //        return BadRequest("Lütfen Eğitim Türünü Seçiniz");
        //    }

        //    if (baslangicYili == null)
        //    {
        //        return BadRequest("Lütfen Eğitiminizin Başlangıç Yılını Giriniz");
        //    }

        //    if (baslangicYili < 1930 || baslangicYili > 2050)
        //    {
        //        return BadRequest("Geçerli bir başlangıç yılı giriniz. Örneğin: 2001");
        //    }

        //    if (bitisYili == null)
        //    {
        //        return BadRequest("Lütfen Eğitiminizin Bitiş Yılını Giriniz");
        //    }
        //    if (bitisYili < 1930 || bitisYili > 2050)
        //    {
        //        return BadRequest("Geçerli bir bitiş yılı giriniz. Örneğin: 2001");
        //    }

        //    if (bitisYili < baslangicYili)
        //    {
        //        return BadRequest("Bitiş yılı başlangıç yılından önce olamaz.");
        //    }

        //    if (universite == null || universite == "")
        //    {
        //        return BadRequest("Lütfen Eğitim Aldığınız Üniversite Adını Giriniz");
        //    }
        //    if (alan == null || alan == "")
        //    {
        //        return BadRequest("Lütfen Eğitim Aldığınız Alan Adını Giriniz");
        //    }

        //    education.Fyear = bitisYili;
        //    education.Syear = baslangicYili;
        //    education.University = universite;
        //    education.Type = egitimTuru;
        //    education.Expert = alan;
        //    education.PersonId = personId;
        //    _educationService.Add(education);
        //    return Ok("Ekleme işlemi başarıyla gerçeklemiştir.");
        //}

        //[HttpDelete]
        //[Route("DeletePersonEgitimBilgileri")]
        //public IActionResult DeletePersonEgitimBilgileri(int id)
        //{
        //    var education = _educationService.GetEducationById(id);
        //    _educationService.Remove(education);
        //    return Ok("Silme İşlemi Başarıyla Gerçekleşmiştir");
        //}

        //[HttpPost]
        //[Route("UpdatePersonEgitimBilgileri")]
        //public IActionResult UpdatePersonEgitimBilgileri(int egitimId, long personId, string? egitimTuru, int? baslangicYili, int? bitisYili, string? universite, string? alan)
        //{
        //    var education = _educationService.GetEducationById(egitimId);

        //    if (egitimTuru == null || egitimTuru == "")
        //    {
        //        return BadRequest("Lütfen Eğitim Türünü Seçiniz");
        //    }

        //    if (baslangicYili == null)
        //    {
        //        return BadRequest("Lütfen Eğitiminizin Başlangıç Yılını Giriniz");
        //    }

        //    if (baslangicYili < 1930 || baslangicYili > 2050)
        //    {
        //        return BadRequest("Geçerli bir başlangıç yılı giriniz. Örneğin: 2001");
        //    }

        //    if (bitisYili == null)
        //    {
        //        return BadRequest("Lütfen Eğitiminizin Bitiş Yılını Giriniz");
        //    }
        //    if (bitisYili < 1930 || bitisYili > 2050)
        //    {
        //        return BadRequest("Geçerli bir bitiş yılı giriniz. Örneğin: 2001");
        //    }

        //    if (bitisYili <= baslangicYili)
        //    {
        //        return BadRequest("Bitiş yılı başlangıç yılından önce olamaz.");
        //    }

        //    if (universite == null || universite == "")
        //    {
        //        return BadRequest("Lütfen Eğitim Aldığınız Üniversite Adını Giriniz");
        //    }
        //    if (alan == null || alan == "")
        //    {
        //        return BadRequest("Lütfen Eğitim Aldığınız Alan Adını Giriniz");
        //    }
        //    education.PersonId = personId;
        //    education.Type = egitimTuru;
        //    education.Fyear = bitisYili;
        //    education.Syear = baslangicYili;
        //    education.University = universite;
        //    education.Expert = alan;
        //    _educationService.Update(education);
        //    return Ok("Güncelleme işlemi başarıyla gerçekleşmiştir");
        //}
        //#endregion

        //#region KurumBilgileri
        //[HttpGet]
        //[Route("GetPersonKurumBilgi")] // kayıtlı oldugu kurum bılgılerı
        //public IActionResult GetPersonKurumBilgi(long personId)
        //{
        //    var person = _personService.GetPersonById(personId);
        //    var corpnode = _corpnodeService.GetCorpnode(person.NodeId);
        //    var listAna = new List<Corpnode>();
        //    var listBolum = new List<Corpnode>();
        //    var listFakulte = new List<Corpnode>();
        //    if (corpnode != null)
        //    {
        //        while (corpnode.Nodetypeid != 1)
        //        {
        //            // while dongusu ıcınde corpnodeun parent ıdsı bir olana kadar(1 ünüversite demek) api sonucuna gonderılecek listeleri atıyoz.
        //            if (corpnode.Nodetypeid == 4) // Abd
        //            {
        //                listAna.Add(corpnode);
        //            }
        //            else if (corpnode.Nodetypeid == 3) // Bölüm
        //            {
        //                listBolum.Add(corpnode); // Ornek Matematik ve Fen Bilimleri Eğitimi
        //            }
        //            else if (corpnode.Nodetypeid == 2) // Fakulte
        //            {
        //                listFakulte.Add(corpnode); // Ornek Eğitim Fakultesi
        //            }
        //            corpnode = _corpnodeService.GetCorpnode(corpnode.ParentId);//her dongude parentidsine göre coprnpdeumuzu yenıden atıyoruz.
        //        }
        //    }
        //    return Ok(new { listAna, listBolum, listFakulte });
        //}

        //[HttpGet]
        //[Route("GetPersonMissionKurumBilgi")] // görev yaptıgı kurum bılgılerı
        //public IActionResult GetPersonMissionKurumBilgi(long personId)
        //{
        //    var person = _personService.GetPersonById(personId);
        //    var corpnode = _corpnodeService.GetCorpnode(person.MissionNodeId);
        //    var listGorevAna = new List<Corpnode>();
        //    var listGorevBolum = new List<Corpnode>();
        //    var listGorevFakulte = new List<Corpnode>();
        //    if (corpnode != null)
        //    {
        //        while (corpnode.Nodetypeid != 1)
        //        {
        //            // while dongusu ıcınde corpnodeun parent ıdsı bir olana kadar(1 ünüversite demek) api sonucuna gonderılecek listeleri atıyoz.

        //            if (corpnode.Nodetypeid == 4) // Abd
        //            {
        //                listGorevAna.Add(corpnode);
        //            }
        //            else if (corpnode.Nodetypeid == 3) // Bölüm
        //            {
        //                listGorevBolum.Add(corpnode); // Ornek Matematik ve Fen Bilimleri Eğitimi
        //            }
        //            else if (corpnode.Nodetypeid == 2) // Fakulte
        //            {
        //                listGorevFakulte.Add(corpnode); // Ornek Eğitim Fakultesi
        //            }
        //            corpnode = _corpnodeService.GetCorpnode(corpnode.ParentId);//her dongude parentidsine göre coprnpdeumuzu yenıden atıyoruz.
        //        }
        //    }
        //    return Ok(new { listGorevAna, listGorevBolum, listGorevFakulte });
        //}
        //#endregion

        //#region YabanciDilBilgisi
        //[HttpGet]
        //[Route("GetPersonYabanciDilBilgileri")]
        //public IActionResult GetPersonYabanciDilBilgileri(long personId)
        //{
        //    var personYabanciDilBilgileri = _personYabanciDilService.ListPersonYabanciDilSinavlarByPersonId(personId);
        //    return Ok(personYabanciDilBilgileri);
        //}
        //[HttpGet]
        //[Route("GetPersonYabanciDilBilgisi")]
        //public IActionResult GetPersonYabanciDilBilgi(int personYabanciDilId)
        //{
        //    var personYabanciDilBilgi = _personYabanciDilService.GetPersonYabanciDilById(personYabanciDilId);
        //    return Ok(personYabanciDilBilgi);
        //}
        //[HttpPost]
        //[Route("AddPersonYabanciDilBilgisi")]

        //public IActionResult AddPersonYabanciDilBilgisi(long personId, int? yabanciDilId, int? yabanciDilSinavId, string? puan, int? seviye, string? yil, int? donem)
        //{
        //    var personYabanciDil = new PersonYabanciDil();
        //    personYabanciDil.Id = Convert.ToInt32(_personYabanciDilService.GetIdTableName("PERSON_YABANCI_DIL"));

        //    if (yabanciDilId == null || yabanciDilId == -1)
        //    {
        //        return BadRequest("Lütfen Yabancı Dil Seçiniz");
        //    }

        //    if (yabanciDilSinavId == null || yabanciDilSinavId == -1)
        //    {
        //        return BadRequest("Lütfen Sınav Adı Seçiniz");
        //    }

        //    if (puan == null || puan == "")
        //    {
        //        return BadRequest("Lütfen Puan Bilgisi Giriniz");
        //    }

        //    if (Convert.ToDecimal(puan) > 100 || Convert.ToDecimal(puan) < 0)
        //    {
        //        return BadRequest("Puanınız 0-100 arasında olmalıdır");
        //    }
        //    if (seviye == null || seviye == -1)
        //    {
        //        return BadRequest("Lütfen Düzey Seçiniz");
        //    }
        //    if (yil == null)
        //    {
        //        return BadRequest("Lütfen Yıl Bilgisi Giriniz");
        //    }

        //    if (Convert.ToDecimal(yil) < 1930 || Convert.ToDecimal(yil) > 2050)
        //    {
        //        return BadRequest("Geçerli bir yıl giriniz. Örneğin: 2001");
        //    }

        //    if (donem == null || donem == -1)
        //    {
        //        return BadRequest("Lütfen Dönem Seçiniz");
        //    }

        //    personYabanciDil.YabanciDilId = (int)yabanciDilId;
        //    personYabanciDil.YabanciDilSinavId = (int)yabanciDilSinavId;
        //    personYabanciDil.Puan = puan;
        //    personYabanciDil.Seviye = (int)seviye;
        //    personYabanciDil.Yil = yil;
        //    personYabanciDil.Donem = (int)donem;
        //    personYabanciDil.PersonId = personId;
        //    _personYabanciDilService.Add(personYabanciDil);
        //    return Ok("Ekleme İşlemi Başarıyla Gerçekleşti");
        //}
        //[HttpDelete]

        //[Route("DeletePersonYabanciDilBilgisi")]
        //public IActionResult DeletePersonYabanciDilBilgisi(int id)
        //{
        //    var personYabanciDil = _personYabanciDilService.GetPersonYabanciDilById(id);
        //    _personYabanciDilService.Remove(personYabanciDil);

        //    return Ok("Silme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpPost]
        //[Route("UpdatePersonYabanciDilBilgisi")]
        //public IActionResult UpdatePersonYabanciDilBilgisi(int? personYabanciDilId, long personId, int? yabanciDilId, int? yabanciDilSinavId, string? puan, int? seviye, string? yil, int? donem)
        //{
        //    var personYabanaciDil = _personYabanciDilService.GetPersonYabanciDilById(personYabanciDilId);

        //    if (yabanciDilId == null || yabanciDilId == -1)
        //    {
        //        return BadRequest("Lütfen Yabancı Dil Seçiniz");
        //    }

        //    if (yabanciDilSinavId == null || yabanciDilSinavId == -1)
        //    {
        //        return BadRequest("Lütfen Sınav Adı Seçiniz");
        //    }

        //    if (puan == null || puan == "")
        //    {
        //        return BadRequest("Lütfen Puan Bilgisi Giriniz");
        //    }

        //    if (Convert.ToDecimal(puan) > 100 || Convert.ToDecimal(puan) < 0)
        //    {
        //        return BadRequest("Puanınız 0-100 arasında olmalıdır");
        //    }
        //    if (seviye == null || seviye == -1)
        //    {
        //        return BadRequest("Lütfen Düzey Seçiniz");
        //    }
        //    if (yil == null)
        //    {
        //        return BadRequest("Lütfen Yıl Bilgisi Giriniz");
        //    }

        //    if (Convert.ToDecimal(yil) < 1930 || Convert.ToDecimal(yil) > 2050)
        //    {
        //        return BadRequest("Geçerli bir yıl giriniz. Örneğin: 2001");
        //    }

        //    if (donem == null || donem == -1)
        //    {
        //        return BadRequest("Lütfen Dönem Seçiniz");
        //    }
        //    personYabanaciDil.PersonId = personId;
        //    personYabanaciDil.YabanciDilId = (int)yabanciDilId;
        //    personYabanaciDil.YabanciDilSinavId = (int)yabanciDilSinavId;
        //    personYabanaciDil.Puan = puan;
        //    personYabanaciDil.Seviye = (int)seviye;
        //    personYabanaciDil.Yil = yil;
        //    personYabanaciDil.Donem = (int)donem;
        //    _personYabanciDilService.Update(personYabanaciDil);
        //    return Ok("Güncelleme İşlemi Başarıyla Gerçekleşti");
        //}
        //#endregion

        //#region AkademikDeneyim
        //[HttpGet]
        //[Route("GetPersonAkademikDeneyimleri")]
        //public IActionResult GetPersonAkademikDeneyimleri(long personId)
        //{
        //    var academicExpers = _academicExperService.GetAllAcademicExperByPersonId(personId);
        //    return Ok(academicExpers);
        //}

        //[HttpGet]
        //[Route("GetPersonAkademikDeneyimi")]
        //public IActionResult GetPersonAkademikDeneyimi(int akademikDeneyimId)
        //{
        //    var academicExpers = _academicExperService.GetAcademicExperById(akademikDeneyimId);
        //    return Ok(academicExpers);
        //}

        //[HttpPost]
        //[Route("AddPersonAkademikDeneyim")]
        //public IActionResult AddPersonAkademikDeneyim(long personId, string? unvan, int? year, int? fyear, string? kurum, string? birim, string? explain)
        //{
        //    var academicExper = new AcademicExper();
        //    academicExper.Id = Convert.ToInt32(_academicExperService.GetIdTableName("ACADEM"));

        //    if (unvan == null || unvan == "")
        //    {
        //        return BadRequest("Lütfen Unvan Bilgisini Seçiniz");
        //    }
        //    if (year == null)
        //    {
        //        return BadRequest("Lütfen Başlangıç Yılını Giriniz");
        //    }

        //    if (year < 1930 || year > 2050)
        //    {
        //        return BadRequest("Geçerli bir başlangıç yılı giriniz. Örneğin: 2001");
        //    }

        //    if (fyear != null)
        //    {
        //        if (fyear < 1930 || fyear > 2050)
        //        {
        //            return BadRequest("Geçerli bir bitiş yılı giriniz. Örneğin: 2001");
        //        }

        //        if (fyear <= year)
        //        {
        //            return BadRequest("Bitiş yılı başlangıç yılından önce olamaz.");
        //        }
        //    }

        //    if (kurum == null || kurum == "")
        //    {
        //        return BadRequest("Lütfen Üniversite Bilgisini Giriniz");
        //    }
        //    if (birim == null || birim == "")
        //    {
        //        return BadRequest("Lütfen Birim Bilgisini Giriniz");
        //    }

        //    academicExper.Unvan = unvan;
        //    academicExper.Year = year;
        //    academicExper.Fyear = fyear;
        //    academicExper.Kurum = kurum;
        //    academicExper.Birim = birim;
        //    academicExper.Explain = explain;
        //    academicExper.PersonId = personId;
        //    _academicExperService.Add(academicExper);
        //    return Ok("Ekleme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpDelete]
        //[Route("DeletePersonAkademikDeneyim")]
        //public IActionResult DeletePersonAkademikDeneyim(int id)
        //{
        //    var academicExper = _academicExperService.GetAcademicExperById(id);
        //    _academicExperService.Remove(academicExper);
        //    return Ok("Silme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpPost]
        //[Route("UpdatePersonAkademikDeneyim")]
        //public IActionResult UpdatePersonAkademikDeneyim(int akademikDeneyimId, long personId, string? unvan, int? year, int? fyear, string? kurum, string? birim, string? explain)
        //{
        //    var academicExper = _academicExperService.GetAcademicExperById(akademikDeneyimId);

        //    if (unvan == null || unvan == "")
        //    {
        //        return BadRequest("Lütfen Ünvan Bilgisini Seçiniz");
        //    }
        //    if (year == null)
        //    {
        //        return BadRequest("Lütfen Başlangıç Yılını Giriniz");
        //    }

        //    if (year < 1930 || year > 2050)
        //    {
        //        return BadRequest("Geçerli bir başlangıç yılı giriniz. Örneğin: 2001");
        //    }

        //    if (fyear != null)
        //    {
        //        if (fyear < 1930 || fyear > 2050)
        //        {
        //            return BadRequest("Geçerli bir bitiş yılı giriniz. Örneğin: 2001");
        //        }

        //        if (fyear <= year)
        //        {
        //            return BadRequest("Bitiş yılı başlangıç yılından önce olamaz.");
        //        }
        //    }

        //    if (kurum == null || kurum == "")
        //    {
        //        return BadRequest("Lütfen Üniversite Bilgisini Giriniz");
        //    }
        //    if (birim == null || birim == "")
        //    {
        //        return BadRequest("Lütfen Birim Bilgisini Giriniz");
        //    }
        //    academicExper.Unvan = unvan;
        //    academicExper.Year = year;
        //    academicExper.Fyear = fyear;
        //    academicExper.Kurum = kurum;
        //    academicExper.Birim = birim;
        //    academicExper.Explain = explain;
        //    academicExper.PersonId = personId;
        //    _academicExperService.Update(academicExper);
        //    return Ok("Güncelleme İşlemi Başarıyla Gerçekleşti");
        //}

        //#endregion

        //#region ÜniversiteIciIdariKomisyon
        //[HttpGet]
        //[Route("GetIdariKomisyonUyelikleri")]
        //public IActionResult GetIdariKomisyonUyelikleri(long personId)
        //{
        //    var workExpers = _workExperService.GetAllWorkExperByPersonId(personId);
        //    return Ok(workExpers);
        //}

        //[HttpGet]
        //[Route("GetIdariKomisyonUyelik")]
        //public IActionResult GetIdariKomisyonUyelik(int workExperId)
        //{
        //    var workExpers = _workExperService.GetWorkExperById(workExperId);
        //    return Ok(workExpers);
        //}

        //[HttpPost]
        //[Route("AddIdariKomisyonUyelikleri")]
        //public IActionResult AddIdariKomisyonUyelikleri(long personId, int? year, int? fyear, string? kurum, int? type, int? komisyonDuzeyi, string? unvan, string? explain)
        //{
        //    var workExper = new WorkExper();
        //    workExper.Id = Convert.ToInt32(_workExperService.GetIdTableName("WORKEX"));

        //    if (year == null)
        //    {
        //        return BadRequest("Lütfen Başlangıç Yılını Giriniz");
        //    }

        //    if (year < 1930 || year > 2050)
        //    {
        //        return BadRequest("Geçerli bir başlangıç yılı giriniz. Örneğin: 2001");
        //    }

        //    if (fyear != null)
        //    {
        //        if (fyear < 1930 || fyear > 2050)
        //        {
        //            return BadRequest("Geçerli bir bitiş yılı giriniz. Örneğin: 2001");
        //        }

        //        if (fyear <= year)
        //        {
        //            return BadRequest("Bitiş yılı başlangıç yılından önce olamaz.");
        //        }
        //    }

        //    if (type == null)
        //    {
        //        return BadRequest("Lütfen Görev Türünü Seçiniz");
        //    }

        //    if (type == 1)
        //    {
        //        if (komisyonDuzeyi == null)
        //        {
        //            return BadRequest("Lütfen Kurul/Komisyon Düzeyi Seçiniz");
        //        }
        //    }
        //    if (kurum == null)
        //    {
        //        return BadRequest("Lütfen Görev Yaptığınız Birim-Komisyon/Kurul Adını Giriniz");
        //    }
        //    if (unvan == null)
        //    {
        //        return BadRequest("Lütfen Görevinizi Giriniz. Örneğin:Komisyon Başkanı");
        //    }

        //    workExper.PersonId = personId;
        //    workExper.Year = year;
        //    workExper.Fyear = fyear;
        //    workExper.Kurum = kurum;
        //    workExper.Type = type;
        //    workExper.Unvan = unvan;
        //    workExper.KomisyonDuzeyi = komisyonDuzeyi;
        //    workExper.Explain = explain;

        //    _workExperService.Add(workExper);
        //    return Ok("Ekleme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpDelete]
        //[Route("DeleteIdariKomisyonUyelikleri")]
        //public IActionResult DeleteIdariKomisyonUyelikleri(int id)
        //{
        //    var workExper = _workExperService.GetWorkExperById(id);
        //    _workExperService.Remove(workExper);
        //    return Ok("Silme İşlemi Başarıyla Gerçekleşti");
        //}


        //[HttpPost]
        //[Route("UpdatePersonWorkExper")]
        //public IActionResult UpdatePersonWorkExper(int workExperId, long personId, int? year, int? fyear, string? kurum, int? type, int? komisyonDuzeyi, string? unvan, string? explain)
        //{
        //    var workExper = _workExperService.GetWorkExperById(workExperId);

        //    if (year == null)
        //    {
        //        return BadRequest("Lütfen Başlangıç Yılını Giriniz");
        //    }

        //    if (year < 1930 || year > 2050)
        //    {
        //        return BadRequest("Geçerli bir başlangıç yılı giriniz. Örneğin: 2001");
        //    }

        //    if (fyear != null)
        //    {
        //        if (fyear < 1930 || fyear > 2050)
        //        {
        //            return BadRequest("Geçerli bir bitiş yılı giriniz. Örneğin: 2001");
        //        }

        //        if (fyear <= year)
        //        {
        //            return BadRequest("Bitiş yılı başlangıç yılından önce olamaz.");
        //        }
        //    }

        //    if (type == null)
        //    {
        //        return BadRequest("Lütfen Görev Türünü Seçiniz");
        //    }

        //    if (type == 1)
        //    {
        //        if (komisyonDuzeyi == null)
        //        {
        //            return BadRequest("Lütfen Kurul/Komisyon Düzeyi Seçiniz");
        //        }
        //    }
        //    if (kurum == null)
        //    {
        //        return BadRequest("Lütfen Görev Yaptığınız Birim-Komisyon/Kurul Adını Giriniz");
        //    }
        //    if (unvan == null)
        //    {
        //        return BadRequest("Lütfen Görevinizi Giriniz. Örneğin:Komisyon Başkanı");
        //    }

        //    workExper.Unvan = unvan;
        //    workExper.Year = year;
        //    workExper.Fyear = fyear;
        //    workExper.Kurum = kurum;
        //    workExper.Type = type;
        //    workExper.Explain = explain;
        //    workExper.PersonId = personId;
        //    if (type == 2)
        //    {
        //        workExper.KomisyonDuzeyi = null;
        //    }
        //    else
        //    {
        //        workExper.KomisyonDuzeyi = komisyonDuzeyi;
        //    }

        //    _workExperService.Update(workExper);
        //    return Ok("Güncelleme İşlemi Başarıyla Gerçekleşti");
        //}
        //#endregion

        //#region UniversiteDisiBilimselKurumDeneyim
        //[HttpGet]
        //[Route("GetPersonExternalExperiences")]
        //public IActionResult GetPersonExternalExperiences(long personId)
        //{
        //    var externalExpers = _disbilimselKurumDeneyimService.GetAllDisBilimselKurumDeneyimByPersonId(personId);
        //    return Ok(externalExpers);
        //}

        //[HttpPost]
        //[Route("AddPersonExternalExperiences")]
        //public IActionResult AddPersonExternalExperiences(long personId, int? baslangicYil, int? bitisYil, string? kurum, string? gorev, string? aciklama)
        //{
        //    var disBilimselKurumDeneyim = new DisBilimselKurumDeneyim();
        //    disBilimselKurumDeneyim.Id = Convert.ToInt32(_disbilimselKurumDeneyimService.GetIdTableName("DIS_BILIMSEL_KURUM_DENEYIM"));

        //    if (baslangicYil == null)
        //    {
        //        return BadRequest("Lütfen Başlangıç Yılını Giriniz");
        //    }

        //    if (baslangicYil < 1930 || baslangicYil > 2050)
        //    {
        //        return BadRequest("Geçerli bir başlangıç yılı giriniz. Örneğin: 2001");
        //    }

        //    if (bitisYil != null)
        //    {
        //        if (bitisYil < 1930 || bitisYil > 2050)
        //        {
        //            return BadRequest("Geçerli bir bitiş yılı giriniz. Örneğin: 2001");
        //        }

        //        if (bitisYil <= baslangicYil)
        //        {
        //            return BadRequest("Bitiş yılı başlangıç yılından önce olamaz.");
        //        }
        //    }

        //    if (kurum == null)
        //    {
        //        return BadRequest("Lütfen Kurum Bilgisi Giriniz");
        //    }
        //    if (gorev == null)
        //    {
        //        return BadRequest("Lütfen Görev Bilgisi Giriniz");
        //    }

        //    disBilimselKurumDeneyim.PersonId = personId;
        //    disBilimselKurumDeneyim.BaslangicYil = (int)baslangicYil;
        //    disBilimselKurumDeneyim.BitisYil = (int)bitisYil;
        //    disBilimselKurumDeneyim.Kurum = kurum;
        //    disBilimselKurumDeneyim.Gorev = gorev;
        //    disBilimselKurumDeneyim.Aciklama = aciklama;
        //    _disbilimselKurumDeneyimService.Add(disBilimselKurumDeneyim);
        //    return Ok("Ekleme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpDelete]
        //[Route("DeletePersonExternalExperiences")]
        //public IActionResult DeletePersonExternalExperiences(int id)
        //{
        //    var disBilimselKurumDeneyim = _disbilimselKurumDeneyimService.GetDisBilimselKurumDeneyimById(id);
        //    _disbilimselKurumDeneyimService.Remove(disBilimselKurumDeneyim);
        //    return Ok("Silme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpGet]
        //[Route("GetPersonExternalExperience")]
        //public IActionResult GetPersonExternalExperience(int externalExperienceId)
        //{
        //    var disBilimselKurumDeneyimler = _disbilimselKurumDeneyimService.GetDisBilimselKurumDeneyimById(externalExperienceId);
        //    return Ok(disBilimselKurumDeneyimler);
        //}

        //[HttpPost]
        //[Route("UpdatePersonExternalExperience")]
        //public IActionResult UpdatePersonExternalExperience(int externalExperienceId, long personId, int? baslangicYil, int? bitisYil, string? kurum, string? gorev, string? aciklama)
        //{
        //    var disBilimselKurumDeneyim = _disbilimselKurumDeneyimService.GetDisBilimselKurumDeneyimById(externalExperienceId);

        //    if (baslangicYil == null)
        //    {
        //        return BadRequest("Lütfen Başlangıç Yılını Giriniz");
        //    }

        //    if (baslangicYil < 1930 || baslangicYil > 2050)
        //    {
        //        return BadRequest("Geçerli bir başlangıç yılı giriniz. Örneğin: 2001");
        //    }

        //    if (bitisYil != null)
        //    {
        //        if (bitisYil < 1930 || bitisYil > 2050)
        //        {
        //            return BadRequest("Geçerli bir bitiş yılı giriniz. Örneğin: 2001");
        //        }

        //        if (bitisYil <= baslangicYil)
        //        {
        //            return BadRequest("Bitiş yılı başlangıç yılından önce olamaz.");
        //        }
        //    }
        //    if (kurum == null)
        //    {
        //        return BadRequest("Lütfen Kurum Bilgisi Giriniz");
        //    }
        //    if (gorev == null)
        //    {
        //        return BadRequest("Lütfen Görev Bilgisi Giriniz");
        //    }
        //    disBilimselKurumDeneyim.Kurum = kurum;
        //    disBilimselKurumDeneyim.Aciklama = aciklama;
        //    disBilimselKurumDeneyim.BitisYil = (int)bitisYil;
        //    disBilimselKurumDeneyim.BaslangicYil = (int)baslangicYil;
        //    disBilimselKurumDeneyim.Gorev = gorev;
        //    disBilimselKurumDeneyim.PersonId = personId;
        //    _disbilimselKurumDeneyimService.Update(disBilimselKurumDeneyim);

        //    return Ok("Güncelleme İşlemi Başarıyla Gerçekleşti");
        //}

        //#endregion

        //#region UniversiteDisiIdariGorevler

        //[HttpGet]
        //[Route("GetPersonJobExperByPersonId")]
        //public IActionResult GetPersonJobExperByPersonId(long personId)
        //{
        //    var jobExpers = _jobExperService.GetAllJobExperByPersonId(personId);
        //    return Ok(jobExpers);
        //}

        //[HttpPost]
        //[Route("AddPersonJobExper")]
        //public IActionResult AddPersonJobExper(long personId, int? baslangicYil, int? bitisYil, string? kurum, int? gorevTuru, string? gorev, string? aciklama)
        //{
        //    var jobExper = new JobExper();
        //    jobExper.Id = Convert.ToInt32(_jobExperService.GetIdTableName("JOBEX"));

        //    if (baslangicYil == null)
        //    {
        //        return BadRequest("Lütfen Başlangıç Yılını Giriniz");
        //    }

        //    if (baslangicYil < 1930 || baslangicYil > 2050)
        //    {
        //        return BadRequest("Geçerli bir başlangıç yılı giriniz. Örneğin: 2001");
        //    }

        //    if (bitisYil != null)
        //    {
        //        if (bitisYil < 1930 || bitisYil > 2050)
        //        {
        //            return BadRequest("Geçerli bir bitiş yılı giriniz. Örneğin: 2001");
        //        }

        //        if (bitisYil <= baslangicYil)
        //        {
        //            return BadRequest("Bitiş yılı başlangıç yılından önce olamaz.");
        //        }
        //    }

        //    if (gorevTuru == null)
        //    {
        //        return BadRequest("Lütfen Görev Türü Seçiniz");
        //    }
        //    if (kurum == null)
        //    {
        //        return BadRequest("Lütfen Kurum Adı Giriniz");
        //    }
        //    if (gorev == null)
        //    {
        //        return BadRequest("Lütfen Görevinizi Giriniz");
        //    }

        //    jobExper.PersonId = personId;
        //    jobExper.Year = baslangicYil;
        //    jobExper.Fyear = bitisYil;
        //    jobExper.Kurum = kurum;
        //    jobExper.Unvan = gorev;
        //    jobExper.Explain = aciklama;
        //    jobExper.Type = gorevTuru;
        //    _jobExperService.Add(jobExper);

        //    return Ok("Ekleme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpDelete]
        //[Route("DeletePersonJobExper")]
        //public IActionResult DeletePersonJobExper(int id)
        //{
        //    var jobExper = _jobExperService.GetJobExperById(id);
        //    _jobExperService.Remove(jobExper);
        //    return Ok("Silme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpGet]
        //[Route("GetPersonJobExperi")]
        //public IActionResult GetPersonJobExperi(int jobExperId)
        //{
        //    var jobExper = _jobExperService.GetJobExperById(jobExperId);
        //    return Ok(jobExper);
        //}

        //[HttpPost]
        //[Route("UpdatePersonJobExper")]
        //public IActionResult UpdatePersonJobExper(int jobExperId, long personId, int? baslangicYil, int? bitisYil, string? kurum, int? gorevTuru, string? gorev, string? aciklama)
        //{
        //    var jobExper = _jobExperService.GetJobExperById(jobExperId);

        //    if (baslangicYil == null)
        //    {
        //        return BadRequest("Lütfen Başlangıç Yılını Giriniz");
        //    }

        //    if (baslangicYil < 1930 || baslangicYil > 2050)
        //    {
        //        return BadRequest("Geçerli bir başlangıç yılı giriniz. Örneğin: 2001");
        //    }

        //    if (bitisYil != null)
        //    {
        //        if (bitisYil < 1930 || bitisYil > 2050)
        //        {
        //            return BadRequest("Geçerli bir bitiş yılı giriniz. Örneğin: 2001");
        //        }

        //        if (bitisYil <= baslangicYil)
        //        {
        //            return BadRequest("Bitiş yılı başlangıç yılından önce olamaz.");
        //        }
        //    }

        //    if (gorevTuru == null)
        //    {
        //        return BadRequest("Lütfen Görev Türü Seçiniz");
        //    }
        //    if (kurum == null)
        //    {
        //        return BadRequest("Lütfen Kurum Adı Giriniz");
        //    }
        //    if (gorev == null)
        //    {
        //        return BadRequest("Lütfen Görevinizi Giriniz");
        //    }

        //    jobExper.PersonId = personId;
        //    jobExper.Year = baslangicYil;
        //    jobExper.Fyear = bitisYil;
        //    jobExper.Kurum = kurum;
        //    jobExper.Unvan = gorev;
        //    jobExper.Explain = aciklama;
        //    jobExper.Type = gorevTuru;
        //    _jobExperService.Update(jobExper);

        //    return Ok("Güncelleme İşlemi Başarıyla Gerçekleşti");
        //}
        //#endregion

        //#region Yayinlar

        //[HttpGet]
        //[Route("ListPublishesByMainTypeAndPersonId")]
        //public IActionResult ListPublishesByMainTypeAndPersonId(int type, long personId)
        //{
        //    var publishes = _publishingService.ListPublishesByMainTypeAndPersonId(type, personId);
        //    return Ok(publishes);
        //}

        //[HttpPost]
        //[Route("AddPersonYayin")]
        //public IActionResult AddPersonYayin(
        //    int? yayinTuru,
        //    int? makaleTuru,
        //    int? bildiriTuru,
        //    int? kitapTuru,
        //    int? raporTuru,
        //    int? digerTuru,
        //    string? yazar,
        //    int? yazarSayi,
        //    string? baslik,
        //    string? doiNo,
        //    string? yayimlananDergi,
        //    byte? bilimselIndex,
        //    string? ciltNo,
        //    string? sayiNo,
        //    string? sayfaAralik,
        //    short? basimYil,
        //    string? basimYeri,
        //    string? bildiriKitapAd,
        //    string? derleyenler,
        //    bool? kitapmi,
        //    bool? usbMi,
        //    bool? webMi,
        //    bool? cdMi,
        //    string? toplantiAd,
        //    string? toplantiYeri,
        //    short? toplantiTarih,
        //    string? kitapAdi,
        //    string? yayinEvi,
        //    string? isbn,
        //    byte? uluslarasiUlusal,
        //    string? editorler,
        //    string? cevirenler,
        //    string? kitapCeviriAd,
        //    string? bolumBasligi,
        //    string? sunulanKurulus,
        //    string? varsaKod,
        //    string? digerAciklama,
        //    string? sayfaSayisi,
        //    IFormFile? dosya,
        //    bool? projeSonuc,
        //    bool? atif,
        //    int? projectSupportType,
        //    int? bapProjectId,
        //    string? projeKod,
        //    int? startYear,
        //    int? finishYear,
        //    string? projeAd,
        //    string? destekKurum,
        //    long personId
        //  )
        //{
        //    if (yayinTuru == 1)
        //    {
        //        if (makaleTuru == null || makaleTuru == 0)
        //        {
        //            return BadRequest("Lütfen Makale Türü Kısmını Seçiniz.");
        //        }
        //        if (yayimlananDergi == null || yayimlananDergi == "")
        //        {
        //            return BadRequest("Lütfen Yayımlandığı Dergi Kısmını Giriniz.");
        //        }
        //        if (ciltNo == null || ciltNo == "")
        //        {
        //            return BadRequest("Lütfen Cilt No Kısmını Giriniz.");
        //        }
        //    }//Makale validasyonlar

        //    if (yayinTuru == 3)
        //    {
        //        if (bildiriTuru == null || bildiriTuru == 0)
        //        {
        //            return BadRequest("Lütfen Bildiri Türü Kısmını Seçiniz.");
        //        }
        //        if (toplantiAd == null || toplantiAd == "")
        //        {
        //            return BadRequest("Lütfen Toplantı Adı Kısmını Giriniz.");
        //        }
        //        if (toplantiYeri == null || toplantiYeri == "")
        //        {
        //            return BadRequest("Lütfen Toplantı Yeri Kısmını Giriniz.");
        //        }
        //        if (toplantiTarih == null)
        //        {
        //            return BadRequest("Lütfen Toplantı Tarihi Kısmını Giriniz.");
        //        }
        //        if (toplantiTarih < 1950 && toplantiTarih > 2040)
        //        {
        //            return BadRequest("Toplantı Tarihi 1950 den Küçük 2040 dan Büyük Olamaz.");
        //        }
        //        if (kitapmi == true)
        //        {
        //            if (bildiriKitapAd == null || bildiriKitapAd == "")
        //            {
        //                return BadRequest("Bildiri Çıktısı Kitap ise Bildiri Kitab Adı Kısmı Zorunludur.");
        //            }
        //        }
        //    }//Bildiri validasyonlar

        //    if (yayinTuru == 4)
        //    {
        //        if (kitapTuru == null || kitapTuru == 0)
        //        {
        //            return BadRequest("Lütfen Kitap Türü Kısmını Seçiniz.");
        //        }
        //        if (kitapTuru == 6 || kitapTuru == 8)
        //        {
        //            if (editorler == null || editorler == "")
        //            {
        //                return BadRequest("Lütfen Editörler Kısmını Giriniz.");
        //            }
        //        }//Editör ve kitap Bölümü
        //        if (kitapTuru == 7)
        //        {
        //            if (cevirenler == null || cevirenler == "")
        //            {
        //                return BadRequest("Lütfen Çevirenler Kısmını Giriniz.");
        //            }
        //            if (kitapCeviriAd == null || kitapCeviriAd == "")
        //            {
        //                return BadRequest("Lütfen Kitap Çeviri Ad Kısmını Giriniz.");
        //            }
        //        }//Çeviri
        //        if (kitapTuru == 8)
        //        {
        //            if (cevirenler == null || cevirenler == "")
        //            {
        //                return BadRequest("Lütfen Çevirenler Kısmını Giriniz.");
        //            }
        //            if (kitapCeviriAd == null || kitapCeviriAd == "")
        //            {
        //                return BadRequest("Lütfen Kitap Çeviri Ad Kısmını Giriniz.");
        //            }
        //        }//Kitap Bölümü
        //        if (bolumBasligi == null || bolumBasligi == "")
        //        {
        //            return BadRequest("Lütfen Bölüm Başlığı Kısmını Giriniz.");
        //        }
        //        if (sayfaSayisi == null)
        //        {
        //            return BadRequest("Lütfen Sayfa Sayısı Kısmını Giriniz.");
        //        }
        //        if (Convert.ToInt32(sayfaSayisi) < 0 && Convert.ToInt32(sayfaSayisi) > 100000)
        //        {
        //            return BadRequest("Sayfa Sayısı 0 dan Küçük 100000 dan Büyük Olamaz.");
        //        }
        //        if (yayinEvi == null || yayinEvi == "")
        //        {
        //            return BadRequest("Lütfen Yayın Evi Kısmını Giriniz.");
        //        }
        //    }//Kitap validasyonlar

        //    if (yayinTuru == 8)
        //    {
        //        if (raporTuru == null || raporTuru == 0)
        //        {
        //            return BadRequest("Lütfen Rapor Türü Kısmını Seçiniz.");
        //        }
        //        if (sunulanKurulus == null || sunulanKurulus == "")
        //        {
        //            return BadRequest("Lütfen Sunulan Kuruluş Kısmını Giriniz.");
        //        }
        //    }//Rapor validasyonlar

        //    if (yayinTuru != 3)
        //    {
        //        if (basimYil == null)
        //        {
        //            return BadRequest("Lütfen Basım Yılı Kısmını Giriniz.");
        //        }
        //        if (basimYil < 1950 && basimYil > 2040)
        //        {
        //            return BadRequest("Basım Yılı 1950 den Küçük 2040 dan Büyük Olamaz.");
        //        }
        //    }//bildiri dısında basım yılı zorunlu

        //    if (kitapTuru != 6)
        //    {
        //        if (yazar == null || yazar == "")
        //        {
        //            return BadRequest("Lütfen Yazar(lar) Kısmını Giriniz.");
        //        }
        //        if (yazarSayi == null || yazarSayi < 1)
        //        {
        //            return BadRequest("Lütfen Yazar Sayısı Kısmını Giriniz.");
        //        }
        //        if (yazarSayi > 20)
        //        {
        //            return BadRequest("Yazar Sayısı 20 den Fazla Olamaz.");
        //        }
        //    }//Kitap/Editor dısında zorunlu

        //    if (yayinTuru != 4)
        //    {
        //        if (baslik == null || baslik == "")
        //        {
        //            return BadRequest("Lütfen Başlık Kısmını Giriniz.");
        //        }
        //        if (baslik.Length > 1000)
        //        {
        //            return BadRequest("Başlık 1000 karakterden Büyük Olamaz.");
        //        }
        //    }//kitaplarda başlık yok

        //    if (yayinTuru == 1 || yayinTuru == 3)
        //    {
        //        if (bilimselIndex == null || bilimselIndex == 0)
        //        {
        //            return BadRequest("Lütfen Bilimsel İndeks Kısmını Seçiniz.");
        //        }
        //    }//aralarında ortak validasyon

        //    if (dosya == null)
        //    {
        //        return BadRequest("Lütfen İlgili Makale Dosyasını Yükleyiniz.");
        //    }

        //    if ((atif != null && atif == true) || (projeSonuc != null && projeSonuc == true))
        //    {
        //        if (projectSupportType == null || projectSupportType == 0)
        //        {
        //            return BadRequest("Lütfen Proje Destek Tipini Seçiniz.");
        //        }
        //        if (projectSupportType == 1)
        //        {
        //            if (bapProjectId == null || bapProjectId == 0)
        //            {
        //                return BadRequest("Lütfen İlgili Projeyi Seçiniz.");
        //            }
        //        }
        //        if (projectSupportType == 2)
        //        {
        //            if (projeKod == null || projeKod == "")
        //            {
        //                return BadRequest("Lütfen Proje Kodu Kısmını Giriniz.");
        //            }
        //            if (startYear != null)
        //            {
        //                if (startYear < 1950 && startYear > 2040)
        //                {
        //                    return BadRequest("Proje Başlangıç Yılı 1950 den Küçük 2040 dan Büyük Olamaz.");
        //                }
        //            }
        //            if (finishYear != null)
        //            {
        //                if (finishYear < 1950 && finishYear > 2040)
        //                {
        //                    return BadRequest("Proje Bitiş Yılı 1950 den Küçük 2040 dan Büyük Olamaz.");
        //                }
        //            }
        //            if (startYear > finishYear)
        //            {
        //                return BadRequest("Proje Başlangıç Yılı Bitiş Yılından Büyük Olamaz.");
        //            }
        //        }
        //    }

        //    var publishing = new Publishing();
        //    var publishUpload = new PublishUpload();

        //    publishing.Id = Convert.ToInt32(_publishingService.GetIdTableName("PUBLISH"));
        //    publishing.Appreciation = 0; // normalde java projesınde boyle atama yoktu 
        //                                 //otomatık null atanıyordu.
        //                                 //fakat null olunca java sayfası yuklenırken hata fırlatmasına sebep oldugu ııcn eklendı.
        //    publishing.MainType = yayinTuru;
        //    if (yayinTuru == 1)
        //    {
        //        publishing.Type = makaleTuru;
        //    }
        //    if (yayinTuru == 3)
        //    {
        //        publishing.Type = bildiriTuru;
        //    }
        //    publishing.Writers = yazar;
        //    publishing.YazarSayisi = yazarSayi;
        //    publishing.Title = baslik;
        //    publishing.MagazineName = yayimlananDergi;
        //    publishing.ScientificIndex = bilimselIndex;
        //    publishing.Tome = ciltNo;
        //    publishing.PrintingDate = basimYil;
        //    publishing.PublishingCity = basimYeri;
        //    publishing.DoiNo = doiNo;
        //    if (yayinTuru == 4)
        //    {
        //        publishing.Page = sayfaSayisi;
        //    }
        //    else
        //    {
        //        publishing.Page = sayiNo;
        //    }
        //    publishing.Page = sayiNo;
        //    publishing.PageNumbers = sayfaAralik;
        //    publishing.DeclarationBook = bildiriKitapAd;
        //    publishing.Compiler = derleyenler;
        //    if (kitapmi == true)
        //    {
        //        publishing.IsBook = 1;
        //    }
        //    if (cdMi == true)
        //    {
        //        publishing.IsCd = 1;
        //    }
        //    if (webMi == true)
        //    {
        //        publishing.IsWebsite = 1;
        //    }
        //    if (usbMi == true)
        //    {
        //        publishing.IsUsb = 1;
        //    }
        //    publishing.MeetingName = toplantiAd;
        //    publishing.MeetingPlace = toplantiYeri;
        //    publishing.MeetingDate = toplantiTarih;
        //    publishing.BookName = kitapAdi;
        //    publishing.Press = yayinEvi;
        //    publishing.Isbn = isbn;
        //    publishing.UluslararasiUlusal = uluslarasiUlusal;
        //    publishing.Compiler = editorler;
        //    publishing.Translators = cevirenler;
        //    publishing.BookTranslateName = kitapCeviriAd;
        //    publishing.ChapterName = bolumBasligi;
        //    publishing.PresentedEnterprise = sunulanKurulus;
        //    publishing.OrCode = varsaKod;
        //    publishing.Explain = digerAciklama;
        //    publishing.TuruDiger = digerTuru;
        //    publishing.PersonId = personId;
        //    if (projeSonuc == true)
        //    {
        //        publishing.IsProject = 1;
        //    }
        //    if (atif == true)
        //    {
        //        publishing.Thank = 1;
        //    }
        //    _publishingService.Add(publishing);

        //    var tempFileName = "yayin_" + Guid.NewGuid().ToString();
        //    var fileResult = _fileService.SaveFile(dosya, "yayinlar", tempFileName);
        //    if (fileResult.Item1 == 1)
        //    {
        //        publishUpload.Id = Convert.ToInt32(_publishUploadService.GetIdTableName("PUBLISHUPLOAD"));
        //        publishUpload.PublishId = publishing.Id;
        //        publishUpload.Success = false;
        //        publishUpload.Permission = false;
        //        publishUpload.Status = 2;
        //        publishUpload.UploadDate = DateTime.Now;
        //        publishUpload.TempName = fileResult.Item2;
        //        publishUpload.OrginalName = "Yayin.pdf";
        //        _publishUploadService.Add(publishUpload);
        //    }

        //    if ((atif != null && atif == true) || (projeSonuc != null && projeSonuc == true))
        //    {
        //        var publishProject = new PublishProject();
        //        publishProject.Id = Convert.ToInt32(_publishProjectService.GetIdTableName("PUBPRO"));
        //        if (projectSupportType == 2 && projeSonuc == true)
        //        {
        //            publishProject.ProjectSupportType = 2;
        //            publishProject.Explain = projeKod;
        //            publishProject.ProjectCode = projeKod;
        //            publishProject.PStartYear = startYear;
        //            publishProject.PFinishYear = finishYear;
        //            publishProject.ProjectName = projeAd;
        //            publishProject.PromoterCorp = destekKurum;
        //            publishProject.PersonId = personId;
        //            publishProject.PublishId = publishing.Id;
        //            publishProject.Publish = publishing.Id;
        //        }
        //        if (projectSupportType == 1 && atif == true)
        //        {
        //            publishProject.ProjectSupportType = 1;
        //            publishProject.IsSystemBapProject = 1;
        //            var proje = _projectService.GetProject(Convert.ToInt32(bapProjectId));
        //            publishProject.Explain = proje.Id.ToString();
        //            publishProject.ProjectName = proje.Title;
        //            publishProject.BapProjectId = proje.Id;
        //            publishProject.PersonId = personId;
        //            publishProject.PublishId = publishing.Id;
        //            publishProject.Publish = publishing.Id;
        //        }
        //        _publishProjectService.Add(publishProject);
        //    }

        //    return Ok("Ekleme İşlemi Başarıyla Gerçekleşti.");
        //}

        //[HttpDelete]
        //[Route("DeletePersonYayin")]
        //public IActionResult DeletePersonYayin(int id) // publish id
        //{
        //    var publishing = _publishingService.GetPublishingByPublishingId(id);
        //    if (publishing != null)
        //    {
        //        //yayını sılebılmek ıcın 3 farklı yerde kayıtı var mı dıye kontrol edıyoruz.
        //        //eger yoksa siliyoruz.
        //        if (_buvakBasvuruDetayService.YayinBuvakBasvurusundaKullanildimi(publishing.Id))
        //        {
        //            return BadRequest(publishing.Title + " adlı yayın buvak başvurunuzda kullanıldığı için silemezsiniz.");
        //        }
        //        if (_sonucraporUrunService.YayinSonucRaporUrunlerdeKullanildimi(publishing.Id))
        //        {
        //            return BadRequest(publishing.Title + " adlı yayın sonuc raporu ürünlerinde kullanıldığı için silemezsiniz.");
        //        }
        //        if (_yayinSunumuService.YayinYayinSunumundaKullanildimi(publishing.Id))
        //        {
        //            return BadRequest(publishing.Title + " adlı yayın yayın sunumunda kullanıldığı için silemezsiniz.");
        //        }
        //        _publishingService.Remove(publishing);
        //        return BadRequest("Yayın başarı ile silinmiştir.");
        //    }
        //    else
        //    {
        //        return BadRequest("Belirtilen yayın bulunamadığı için işleminiz yapılamammıştır.");
        //    }
        //}

        //[HttpDelete]
        //[Route("DeletePersonYayinDokuman")]
        //public IActionResult DeletePersonYayinDokuman(int id) // publishUpload id
        //{
        //    var publisUpload = _publishUploadService.GetPublishUploadById(id);
        //    if (publisUpload == null)
        //    {
        //        return BadRequest("Yayın Dökümanı Bulanamadığı için Silme İşlemi Gerçekleştirilememiştir.");
        //    }
        //    else
        //    {
        //        _publishUploadService.Remove(publisUpload);
        //        return BadRequest("Silme İşlemi Başarıyla Gerçekleşmiştir.");
        //    }
        //}

        //[HttpDelete]
        //[Route("DeletePublishProje")]
        //public IActionResult DeletePublishProje(int id) // publishproject id
        //{
        //    var publishProje = _publishProjectService.GetPublishProjectById(id);
        //    _publishProjectService.Remove(publishProje);

        //    var publishing = _publishingService.GetPublishingByPublishingId(publishProje.PublishId);
        //    publishing.IsProject = 0;
        //    _publishingService.Update(publishing);

        //    var publishProjects = _publishProjectService.ListSystemBapProject(publishProje.PublishId);
        //    return Ok(publishProjects);
        //}

        //[HttpGet]
        //[Route("GetPersonYayinMakale")]
        //public IActionResult GetPersonYayinMakale(int id) // publish id
        //{
        //    var publishing = _publishingService.GetPublishingByPublishingId(id);
        //    var guncenebilirmi = false;  // false guncellenemez
        //                                 // true guncellenebilir
        //    var listofPublishProjects = new List<PublishProject>();

        //    if (publishing != null)
        //    {
        //        if (_publishProjectService.IsSystemBapProject(publishing.Id) == true)
        //        {
        //            //yayın guncelleneblir   
        //            guncenebilirmi = true;
        //        }
        //        else
        //        {
        //            listofPublishProjects = _publishProjectService.ListSystemBapProject(publishing.Id);
        //            // guncelleme ekranına publishprojectı de eger sılmek ısterse dıye gonderıyoruz
        //        }
        //    }
        //    //her halukarda da ılgılı yayını(publishing) obje halınde apiye gonderiyorz.
        //    //güncelleneblirmi bılgısı ıle de front end te o bilgiye gore ınputları readonly yapacaz ya da yapmıcamıza bakacaz.
        //    return Ok(new { publishing, guncenebilirmi, listofPublishProjects });
        //}
        //#endregion

        //#region ProjeDigerFonlar

        //[HttpGet]
        //[Route("GetAllProjeDigerFonlarByPersonId")]
        //public IActionResult GetAllProjeDigerFonlarByPersonId(long personId)
        //{
        //    var projeDigerFonlar = _projeDigerFonlarService.GetAllProjeDigerFonlarByPersonId(personId);
        //    return Ok(projeDigerFonlar);
        //}

        //[HttpPost]
        //[Route("AddProjeDigerFonlar")]
        //public IActionResult AddProjeDigerFonlar(long personId, DateTime? baslangicYil, DateTime? bitisYil, string? projeAdi, string? projeKonusu, byte? desteklendigiFon, string? projeKodu, decimal? butce, string? gorev)
        //{
        //    var projeDigerFonlar = new ProjeDigerFonlar();
        //    projeDigerFonlar.Id = Convert.ToInt32(_projeDigerFonlarService.GetIdTableName("PROJE_DIGER_FONLAR"));
        //    if (projeAdi == null || projeAdi == "")
        //    {
        //        return BadRequest("Lütfen Proje Adını Giriniz");
        //    }
        //    if (projeKonusu == null || projeKonusu == "")
        //    {
        //        return BadRequest("Lütfen Proje Konusunu Giriniz");
        //    }
        //    if (desteklendigiFon == null)
        //    {
        //        return BadRequest("Lütfen Desteklendiği Fonu Seçiniz");
        //    }
        //    if (projeKodu == null || projeKodu == "")
        //    {
        //        return BadRequest("Lütfen Proje Kodu / Sözleşme No Giriniz");
        //    }
        //    if (gorev == null || gorev == "")
        //    {
        //        return BadRequest("Lütfen Projedeki Görevi Giriniz");
        //    }
        //    if (baslangicYil == null)
        //    {
        //        return BadRequest("Lütfen Projenin Başlangıç Tarihini Seçiniz");
        //    }
        //    if (bitisYil == null)
        //    {
        //        return BadRequest("Lütfen Projenin Bitiş Tarihini Seçiniz");
        //    }
        //    if (bitisYil < baslangicYil)
        //    {
        //        return BadRequest("Bitiş Tarihi, Başlangıç Tarihinden Önce Olamaz");
        //    }
        //    if (butce == null)
        //    {
        //        return BadRequest("Lütfen Proje Bütçesini Giriniz");
        //    }
        //    projeDigerFonlar.PersonId = personId;
        //    projeDigerFonlar.BaslangicTarihi = baslangicYil;
        //    projeDigerFonlar.BitisTarihi = bitisYil;
        //    projeDigerFonlar.ProjeAdi = projeAdi;
        //    projeDigerFonlar.ProjeKonu = projeKonusu;
        //    projeDigerFonlar.DesteklendigiFon = desteklendigiFon;
        //    projeDigerFonlar.ProjeKodu = projeKodu;
        //    projeDigerFonlar.ProjeButcesi = butce;
        //    projeDigerFonlar.OrtakYonetici = gorev;
        //    _projeDigerFonlarService.Add(projeDigerFonlar);

        //    return Ok("Ekleme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpGet]
        //[Route("GetProjeDigerFonu")]
        //public IActionResult GetProjeDigerFonu(int projeDigerFonuId)
        //{
        //    var projeDigerFon = _projeDigerFonlarService.GetProjeDigerFonlarById(projeDigerFonuId);
        //    return Ok(projeDigerFon);
        //}

        //[HttpDelete]
        //[Route("DeleteProjeDigerFonlar")]
        //public IActionResult DeleteProjeDigerFonlar(int id)
        //{
        //    var projeDigerFonlar = _projeDigerFonlarService.GetProjeDigerFonlarById(id);
        //    _projeDigerFonlarService.Remove(projeDigerFonlar);
        //    return Ok("Silme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpPost]
        //[Route("UpdateProjeDigerFonlar")]
        //public IActionResult UpdateProjeDigerFonlar(int projeDigerFonuId, long personId, DateTime? baslangicYil, DateTime? bitisYil, string? projeAdi, string? projeKonusu, byte? desteklendigiFon, string? projeKodu, decimal? butce, string? gorev)
        //{
        //    var projeDigerFonlar = _projeDigerFonlarService.GetProjeDigerFonlarById(projeDigerFonuId);

        //    if (projeAdi == null || projeAdi == "")
        //    {
        //        return BadRequest("Lütfen Proje Adını Giriniz");
        //    }
        //    if (projeKonusu == null || projeKonusu == "")
        //    {
        //        return BadRequest("Lütfen Proje Konusunu Giriniz");
        //    }
        //    if (desteklendigiFon == null)
        //    {
        //        return BadRequest("Lütfen Desteklendiği Fonu Seçiniz");
        //    }
        //    if (projeKodu == null || projeKodu == "")
        //    {
        //        return BadRequest("Lütfen Proje Kodu / Sözleşme No Giriniz");
        //    }
        //    if (gorev == null || gorev == "")
        //    {
        //        return BadRequest("Lütfen Projedeki Görevi Giriniz");
        //    }
        //    if (baslangicYil == null)
        //    {
        //        return BadRequest("Lütfen Projenin Başlangıç Tarihini Seçiniz");
        //    }
        //    if (bitisYil == null)
        //    {
        //        return BadRequest("Lütfen Projenin Bitiş Tarihini Seçiniz");
        //    }
        //    if (bitisYil < baslangicYil)
        //    {
        //        return BadRequest("Bitiş Tarihi, Başlangıç Tarihinden Önce Olamaz");
        //    }
        //    if (butce == null)
        //    {
        //        return BadRequest("Lütfen Proje Bütçesini Giriniz");
        //    }
        //    projeDigerFonlar.PersonId = personId;
        //    projeDigerFonlar.BaslangicTarihi = baslangicYil;
        //    projeDigerFonlar.BitisTarihi = bitisYil;
        //    projeDigerFonlar.ProjeAdi = projeAdi;
        //    projeDigerFonlar.ProjeKonu = projeKonusu;
        //    projeDigerFonlar.DesteklendigiFon = desteklendigiFon;
        //    projeDigerFonlar.ProjeKodu = projeKodu;
        //    projeDigerFonlar.ProjeButcesi = butce;
        //    projeDigerFonlar.OrtakYonetici = gorev;

        //    _projeDigerFonlarService.Update(projeDigerFonlar);
        //    return Ok("Güncelleme İşlemi Başarıyla Gerçekleşti");

        //}
        //#endregion

        //#region ProjeHakemlikler

        //[HttpGet]
        //[Route("GetAllProjeHakemliklerByPersonId")]
        //public IActionResult GetAllProjeHakemliklerByPersonId(long personId)
        //{
        //    var projeHakemlikler = _projelerdeHakemlikService.GetAllProjelerdeHakemliklerByPersonId(personId);
        //    return Ok(projeHakemlikler);
        //}

        //[HttpPost]
        //[Route("AddProjedeHakemlikler")]
        //public IActionResult AddProjedeHakemlikler(long personId, int? desteklendigiFon, string? kurum, int? projeTuru, string? digerProje, int? tarih, int? hakemlikAdedi)
        //{
        //    var projeHakemlik = new ProjelerdeHakemlik();
        //    projeHakemlik.Id = Convert.ToInt32(_projelerdeHakemlikService.GetIdTableName("PROJELERDE_HAKEMLIK"));

        //    if (desteklendigiFon == null)
        //    {
        //        return BadRequest("Lütfen Desteklendiği Fon Seçiniz");
        //    }
        //    if (desteklendigiFon == 6 && kurum == null)
        //    {
        //        return BadRequest("Lütfen Destekleyen Kurum Bilgisini Giriniz");
        //    }

        //    if (projeTuru == null)
        //    {
        //        return BadRequest("Lütfen Proje Tipini Seçiniz");
        //    }
        //    if (projeTuru == 6 && digerProje == null)
        //    {
        //        return BadRequest("Lütfen Diğer Proje Türü Bilgisini Giriniz");
        //    }
        //    if (tarih == null)
        //    {
        //        return BadRequest("Lütfen Tarih Giriniz");
        //    }
        //    if (hakemlikAdedi == null)
        //    {
        //        return BadRequest("Lütfen Hakemlik Adedini Bilgisini Giriniz");
        //    }
        //    projeHakemlik.PersonId = personId;
        //    projeHakemlik.DesteklendigiFon = desteklendigiFon;
        //    projeHakemlik.DestekleyenKurum = kurum;
        //    projeHakemlik.ProjeTuru = projeTuru;
        //    projeHakemlik.DigerProje = digerProje;
        //    projeHakemlik.Tarih = tarih;
        //    projeHakemlik.HakemlikAdedi = hakemlikAdedi;
        //    _projelerdeHakemlikService.Add(projeHakemlik);

        //    return Ok("Ekleme İşlemi Başarıyla Gerçekleşti");

        //}
        //[HttpGet]
        //[Route("GetProjedeHakemlik")]
        //public IActionResult GetProjedeHakemlik(int projeHakemlikId)
        //{
        //    var projeHakemlik = _projelerdeHakemlikService.GetProjedeHakemlikByPersonId(projeHakemlikId);
        //    return Ok(projeHakemlik);
        //}

        //[HttpDelete]
        //[Route("DeleteProjedeHakemlik")]
        //public IActionResult DeleteProjedeHakemlik(int id)
        //{
        //    var projeHakemlik = _projelerdeHakemlikService.GetProjedeHakemlikByPersonId(id);
        //    _projelerdeHakemlikService.Remove(projeHakemlik);
        //    return Ok("Silme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpPost]
        //[Route("UpdateProjedeHakemlik")]
        //public IActionResult UpdateProjedeHakemlik(long personId, int projeHakemlikId, int? desteklendigiFon, string? kurum, int? projeTuru, string? digerProje, int? tarih, int? hakemlikAdedi)
        //{
        //    var projeHakemlik = _projelerdeHakemlikService.GetProjedeHakemlikByPersonId(projeHakemlikId);

        //    if (desteklendigiFon == null)
        //    {
        //        return BadRequest("Lütfen Desteklendiği Fon Seçiniz");
        //    }
        //    if (desteklendigiFon == 6 && kurum == null)
        //    {
        //        return BadRequest("Lütfen Destekleyen Kurum Bilgisini Giriniz");
        //    }
        //    if (projeTuru == null)
        //    {
        //        return BadRequest("Lütfen Proje Tipini Seçiniz");
        //    }
        //    if (projeTuru == 6 && digerProje == null)
        //    {
        //        return BadRequest("Lütfen Diğer Proje Türü Bilgisini Giriniz");
        //    }
        //    if (tarih == null)
        //    {
        //        return BadRequest("Lütfen Tarih Giriniz");
        //    }
        //    if (hakemlikAdedi == null)
        //    {
        //        return BadRequest("Lütfen Hakemlik Adedini Bilgisini Giriniz");
        //    }
        //    projeHakemlik.PersonId = personId;
        //    projeHakemlik.DesteklendigiFon = desteklendigiFon;
        //    projeHakemlik.ProjeTuru = projeTuru;

        //    if (desteklendigiFon != 6)
        //    {
        //        projeHakemlik.DestekleyenKurum = null;
        //    }
        //    else
        //    {
        //        projeHakemlik.DestekleyenKurum = kurum;
        //    }
        //    if (projeTuru != 6)
        //    {
        //        projeHakemlik.DigerProje = null;
        //    }
        //    else
        //    {
        //        projeHakemlik.DigerProje = digerProje;

        //    }
        //    projeHakemlik.Tarih = tarih;
        //    projeHakemlik.HakemlikAdedi = hakemlikAdedi;
        //    _projelerdeHakemlikService.Update(projeHakemlik);
        //    return Ok("Güncelleme İşlemi Başarıyla Gerçekleşti");
        //}
        //#endregion

        //#region Patent

        //[HttpGet]
        //[Route("GetAllPatentsByPersonId")]
        //public IActionResult GetAllPatentsByPersonId(long personId)
        //{
        //    var patents = _patentService.GetAllPatentsByPersonId(personId);
        //    return Ok(patents);
        //}

        //[HttpGet]
        //[Route("GetPatentById")]
        //public IActionResult GetPatentById(int id)
        //{
        //    var patent = _patentService.GetPatentById(id);
        //    return Ok(patent);
        //}

        //[HttpGet]
        //[Route("GetPatentProjeByPatentId")]
        //public IActionResult GetPatentProjeByPatentId(int id)
        //{
        //    var patent = _patentService.GetPatentById(id);
        //    var patentProje = _patentProjeService.GetPatentProjeByPatentId(patent.Id);
        //    return Ok(patentProje);
        //}

        //[HttpDelete]
        //[Route("DeletePatentAndPatentProje")]
        //public IActionResult DeletePatentAndPatentProje(int id)
        //{
        //    var patent = _patentService.GetPatentById(id);
        //    var patentProje = _patentProjeService.GetPatentProjeByPatentId(patent.Id);
        //    if (patentProje != null)
        //    {
        //        _patentProjeService.Remove(patentProje);
        //    }
        //    _patentService.Remove(patent);

        //    return Ok("Silme İşlemi Başarıyla Gerçekleşti");
        //}
        //[HttpGet]
        //[Route("GetPatentProjeById")]
        //public IActionResult GetPatentProjeById(int id)
        //{
        //    var patentProje = _patentProjeService.GetPatentProjeById(id);
        //    return Ok(patentProje);
        //}

        //[HttpPost]
        //[Route("AddPatent")]
        //public IActionResult AddPatent(
        //    long personId,
        //    string? baslik,
        //    string? bulusSahibi,
        //    int? bulusSahibiSayisi,
        //    int? durum,
        //    string? patentNo,
        //    int? tarih,
        //    string? hakSahiplik,
        //    int? answer,
        //    int? thank,
        //    string? projeDestekTipi,
        //    int? bapProjectType,
        //    int? bapProjectId,
        //    string? projeKodu,
        //    int? baslangicYil,
        //    int? bitisYil,
        //    string? projeAdi,
        //    string? destekKurum

        //    )
        //{

        //    if (baslik == null || baslik == "")
        //    {
        //        return BadRequest("Lütfen Patent / Faydalı Modelin Başlığı Giriniz");
        //    }
        //    if (bulusSahibi == null || bulusSahibi == "")
        //    {
        //        return BadRequest("Lütfen Buluş Sahibi Bilgisini Giriniz");
        //    }
        //    if (durum == null || durum == 0)
        //    {
        //        return BadRequest("Lütfen Durumu Seçiniz");
        //    }
        //    if (tarih == null)
        //    {
        //        return BadRequest("Lütfen Tarih Giriniz");
        //    }
        //    if (tarih < 1930 || tarih > 2040)
        //    {
        //        return BadRequest("Geçerli bir başlangıç yılı giriniz. Örneğin: 2001");
        //    }
        //    else
        //    {
        //        var buYil = DateTime.Now.Year;
        //        if (tarih > buYil)
        //        {
        //            return BadRequest("Girmiş oldğunuz tarih bulunduğumuz yıldan büyük olamaz.");
        //        }
        //    }

        //    var patent = new Patent();
        //    patent.Id = Convert.ToInt32(_patentService.GetIdTableName("PATENTS"));
        //    patent.PersonId = personId;
        //    patent.Bsahip = bulusSahibi;
        //    patent.Title = baslik;
        //    patent.BulusSahibiSayisi = bulusSahibiSayisi;
        //    patent.Status = durum;
        //    patent.PatentNo = patentNo;
        //    patent.Yili = tarih;
        //    patent.Sahibi = hakSahiplik;
        //    _patentService.Add(patent);

        //    if ((answer != null && answer == 1) || (thank != null && thank == 1))
        //    {
        //        if (projeDestekTipi == null || projeDestekTipi == "")
        //        {
        //            return BadRequest("Lütfen Proje Destek Türünü Seçiniz");
        //        }
        //        else
        //        {
        //            if (projeDestekTipi == "BAP")
        //            {
        //                if (bapProjectType == 0 || bapProjectType == null)
        //                {
        //                    return BadRequest("Lütfen Projenin Sistemde Kayıtlı Olup Olmadığını Seçiniz");
        //                }
        //                else if (bapProjectType == 1)
        //                {
        //                    if (bapProjectId == null || bapProjectId == 0)
        //                    {
        //                        return BadRequest("Lütfen İlgili Bap Projesini Seçiniz");
        //                    }
        //                    var proje = _projectService.GetProject((int)bapProjectId);
        //                    if (proje != null)
        //                    {
        //                        var patentProje = new PatentProje();
        //                        patentProje.Id = Convert.ToInt32(_patentProjeService.GetIdTableName("PATENT_PROJE"));
        //                        patentProje.SupportType = projeDestekTipi;
        //                        patentProje.SysBapProject = 1;
        //                        patentProje.ProjectNo = Convert.ToString(bapProjectId);
        //                        if (proje.Title != null && proje.Title.Length > 100)
        //                        {
        //                            patentProje.ProjectName = proje.Title.Substring(0, 100);
        //                        }
        //                        else
        //                        {
        //                            patentProje.ProjectName = proje.Title;
        //                        }
        //                        patentProje.BapProjectId = bapProjectId;
        //                        patentProje.PersonId = personId;
        //                        patentProje.PatentId = patent.Id;
        //                        _patentProjeService.Add(patentProje);
        //                    }
        //                }
        //                else if (bapProjectType == 2)
        //                {
        //                    var patentProje1 = new PatentProje();
        //                    patentProje1.Id = Convert.ToInt32(_patentProjeService.GetIdTableName("PATENT_PROJE"));
        //                    if (projeKodu == null)
        //                    {
        //                        return BadRequest("Lütfen Proje Kodunu Giriniz");
        //                    }
        //                    patentProje1.SupportType = projeDestekTipi;
        //                    patentProje1.ProjectNo = projeKodu;


        //                    if (baslangicYil < 1930 || baslangicYil > 2050)
        //                    {
        //                        return BadRequest("Geçerli bir başlangıç yılı giriniz. Örneğin: 2001");
        //                    }

        //                    if (bitisYil < 1930 || bitisYil > 2050)
        //                    {
        //                        return BadRequest("Geçerli bir bitiş yılı giriniz. Örneğin: 2001");
        //                    }

        //                    if (bitisYil < baslangicYil)
        //                    {
        //                        return BadRequest("Bitiş yılı başlangıç yılından önce olamaz.");
        //                    }
        //                    patentProje1.PStartYear = baslangicYil;
        //                    patentProje1.PFinishYear = bitisYil;
        //                    patentProje1.ProjectName = projeAdi;
        //                    patentProje1.SupportCompany = destekKurum;
        //                    patentProje1.PersonId = personId;
        //                    patentProje1.PatentId = patent.Id;
        //                    _patentProjeService.Add(patentProje1);
        //                }
        //                else
        //                {
        //                    return BadRequest("Lütfen Projenin Sistemde Kayıtlı Olup Olmadığını Seçiniz");
        //                }
        //            }
        //            else if (projeDestekTipi == "Diger")
        //            {
        //                var patentProje2 = new PatentProje();
        //                patentProje2.Id = Convert.ToInt32(_patentProjeService.GetIdTableName("PATENT_PROJE"));
        //                if (projeKodu == null)
        //                {
        //                    return BadRequest("Lütfen Proje Kodunu Giriniz");
        //                }
        //                patentProje2.SupportType = projeDestekTipi;
        //                patentProje2.ProjectNo = projeKodu;

        //                if (baslangicYil < 1930 || baslangicYil > 2050)
        //                {
        //                    return BadRequest("Geçerli bir başlangıç yılı giriniz. Örneğin: 2001");
        //                }

        //                if (bitisYil < 1930 || bitisYil > 2050)
        //                {
        //                    return BadRequest("Geçerli bir bitiş yılı giriniz. Örneğin: 2001");
        //                }

        //                if (bitisYil < baslangicYil)
        //                {
        //                    return BadRequest("Bitiş yılı başlangıç yılından önce olamaz.");
        //                }
        //                patentProje2.PStartYear = baslangicYil;
        //                patentProje2.PFinishYear = bitisYil;
        //                patentProje2.ProjectName = projeAdi;
        //                patentProje2.SupportCompany = destekKurum;
        //                patentProje2.PersonId = personId;
        //                patentProje2.PatentId = patent.Id;
        //                _patentProjeService.Add(patentProje2);
        //            }
        //        }
        //    }
        //    return Ok("Ekleme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpPost]
        //[Route("UpdatePatent")]
        //public IActionResult UpdatePatent(
        //   long personId,
        //   int patentId,
        //   string? baslik,
        //   string? bulusSahibi,
        //   int? bulusSahibiSayisi,
        //   int? durum,
        //   string? patentNo,
        //   int? tarih,
        //   string? hakSahiplik,
        //   int? answer,
        //   int? thank,
        //   string? projeDestekTipi,
        //   int? bapProjectType,
        //   int? bapProjectId,
        //   string? projeKodu,
        //   int? baslangicYil,
        //   int? bitisYil,
        //   string? projeAdi,
        //   string? destekKurum

        //   )
        //{
        //    if (baslik == null || baslik == "")
        //    {
        //        return BadRequest("Lütfen Patent / Faydalı Modelin Başlığı Giriniz");
        //    }
        //    if (bulusSahibi == null || bulusSahibi == "")
        //    {
        //        return BadRequest("Lütfen Buluş Sahibi Bilgisini Giriniz");
        //    }
        //    if (durum == null || durum == 0)
        //    {
        //        return BadRequest("Lütfen Durumu Seçiniz");
        //    }
        //    if (tarih == null)
        //    {
        //        return BadRequest("Lütfen Tarih Giriniz");
        //    }
        //    if (tarih < 1930 || tarih > 2040)
        //    {
        //        return BadRequest("Geçerli bir başlangıç yılı giriniz. Örneğin: 2001");
        //    }
        //    else
        //    {
        //        var buYil = DateTime.Now.Year;
        //        if (tarih > buYil)
        //        {
        //            return BadRequest("Girmiş oldğunuz tarih bulunduğumuz yıldan büyük olamaz.");
        //        }
        //    }

        //    var patent = _patentService.GetPatentById(patentId);
        //    patent.PersonId = personId;
        //    patent.Bsahip = bulusSahibi;
        //    patent.Title = baslik;
        //    patent.BulusSahibiSayisi = bulusSahibiSayisi;
        //    patent.Status = durum;
        //    patent.PatentNo = patentNo;
        //    patent.Yili = tarih;
        //    patent.Sahibi = hakSahiplik;
        //    _patentService.Update(patent);

        //    if ((answer != null && answer == 1) || (thank != null && thank == 1))
        //    {
        //        if (projeDestekTipi == null || projeDestekTipi == "")
        //        {
        //            return BadRequest("Lütfen Proje Destek Türünü Seçiniz");
        //        }
        //        else
        //        {
        //            if (projeDestekTipi == "BAP")
        //            {
        //                if (bapProjectType == 0 || bapProjectType == null)
        //                {
        //                    return BadRequest("Lütfen Projenin Sistemde Kayıtlı Olup Olmadığını Seçiniz");
        //                }
        //                else if (bapProjectType == 1)
        //                {
        //                    if (bapProjectId == null || bapProjectId == 0)
        //                    {
        //                        return BadRequest("Lütfen İlgili Bap Projesini Seçiniz");
        //                    }
        //                    var proje = _projectService.GetProject((int)bapProjectId);
        //                    if (proje != null)
        //                    {
        //                        var patentProje = _patentProjeService.GetPatentProjeByPatentId(patent.Id);
        //                        patentProje.SupportType = projeDestekTipi;
        //                        patentProje.SysBapProject = 1;
        //                        patentProje.ProjectNo = Convert.ToString(bapProjectId);
        //                        if (proje.Title != null && proje.Title.Length > 100)
        //                        {
        //                            patentProje.ProjectName = proje.Title.Substring(0, 100);
        //                        }
        //                        else
        //                        {
        //                            patentProje.ProjectName = proje.Title;
        //                        }
        //                        patentProje.BapProjectId = bapProjectId;
        //                        patentProje.PersonId = personId;
        //                        patentProje.PatentId = patent.Id;
        //                        _patentProjeService.Update(patentProje);
        //                    }
        //                }
        //                else if (bapProjectType == 2)
        //                {
        //                    var patentProje1 = _patentProjeService.GetPatentProjeByPatentId(patent.Id);
        //                    if (projeKodu == null)
        //                    {
        //                        return BadRequest("Lütfen Proje Kodunu Giriniz");
        //                    }
        //                    patentProje1.SupportType = projeDestekTipi;
        //                    patentProje1.ProjectNo = projeKodu;


        //                    if (baslangicYil < 1930 || baslangicYil > 2050)
        //                    {
        //                        return BadRequest("Geçerli bir başlangıç yılı giriniz. Örneğin: 2001");
        //                    }

        //                    if (bitisYil < 1930 || bitisYil > 2050)
        //                    {
        //                        return BadRequest("Geçerli bir bitiş yılı giriniz. Örneğin: 2001");
        //                    }

        //                    if (bitisYil < baslangicYil)
        //                    {
        //                        return BadRequest("Bitiş yılı başlangıç yılından önce olamaz.");
        //                    }
        //                    patentProje1.PStartYear = baslangicYil;
        //                    patentProje1.PFinishYear = bitisYil;
        //                    patentProje1.ProjectName = projeAdi;
        //                    patentProje1.SupportCompany = destekKurum;
        //                    patentProje1.PersonId = personId;
        //                    patentProje1.PatentId = patent.Id;
        //                    _patentProjeService.Update(patentProje1);
        //                }
        //                else
        //                {
        //                    return BadRequest("Lütfen Projenin Sistemde Kayıtlı Olup Olmadığını Seçiniz");
        //                }
        //            }
        //            else if (projeDestekTipi == "Diger")
        //            {
        //                var patentProje2 = _patentProjeService.GetPatentProjeByPatentId(patent.Id);
        //                if (projeKodu == null)
        //                {
        //                    return BadRequest("Lütfen Proje Kodunu Giriniz");
        //                }
        //                patentProje2.SupportType = projeDestekTipi;
        //                patentProje2.ProjectNo = projeKodu;

        //                if (baslangicYil < 1930 || baslangicYil > 2050)
        //                {
        //                    return BadRequest("Geçerli bir başlangıç yılı giriniz. Örneğin: 2001");
        //                }

        //                if (bitisYil < 1930 || bitisYil > 2050)
        //                {
        //                    return BadRequest("Geçerli bir bitiş yılı giriniz. Örneğin: 2001");
        //                }

        //                if (bitisYil < baslangicYil)
        //                {
        //                    return BadRequest("Bitiş yılı başlangıç yılından önce olamaz.");
        //                }
        //                patentProje2.PStartYear = baslangicYil;
        //                patentProje2.PFinishYear = bitisYil;
        //                patentProje2.ProjectName = projeAdi;
        //                patentProje2.SupportCompany = destekKurum;
        //                patentProje2.PersonId = personId;
        //                patentProje2.PatentId = patent.Id;
        //                _patentProjeService.Update(patentProje2);
        //            }
        //        }
        //    }
        //    return Ok("Güncelleme İşlemi Başarıyla Gerçekleşti");
        //}

        //#endregion

        //#region Kazandiğim Oduller

        //[HttpGet]
        //[Route("GetAllKazandigimOdullerByPersonId")]
        //public IActionResult GetAllKazandigimOdullerByPersonId(long personId)
        //{
        //    var kazandigimOduller = _kazandigimOdullerService.GetAllKazandigimOdullerByPersonId(personId);
        //    return Ok(kazandigimOduller);
        //}

        //[HttpPost]
        //[Route("AddKazandigimOduller")]
        //public IActionResult AddKazandigimOduller(long personId, string? odulAdi, string? kurulusAdi, string? tarih, string? odulAlani)
        //{
        //    var kazandigimOdul = new KazandigimOduller();
        //    kazandigimOdul.Id = Convert.ToInt32(_kazandigimOdullerService.GetIdTableName("KAZANDIGIM_ODULLER"));

        //    if (odulAdi == null)
        //    {
        //        return BadRequest("Lütfen Ödül Adı Giriniz");
        //    }
        //    if (kurulusAdi == null || kurulusAdi == "")
        //    {
        //        return BadRequest("Lütfen Kuruluş Adı Giriniz");
        //    }
        //    if (tarih == null)
        //    {
        //        return BadRequest("Lütfen Tarih Giriniz. Örneğin:2015");
        //    }
        //    if (Convert.ToInt32(tarih) < 1950 && Convert.ToInt32(tarih) > 2030)
        //    {
        //        return BadRequest("Geçerli Tarih Aralığı:1950-2030");
        //    }
        //    kazandigimOdul.PersonId = personId;
        //    kazandigimOdul.Oadi = odulAdi;
        //    kazandigimOdul.Kadi = kurulusAdi;
        //    kazandigimOdul.Tarihyil = tarih;
        //    kazandigimOdul.Odulalani = odulAlani;
        //    kazandigimOdul.Tarihay = null;
        //    _kazandigimOdullerService.Add(kazandigimOdul);
        //    return Ok("Ekleme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpGet]
        //[Route("GetKazandigimOdul")]
        //public IActionResult GetKazandigimOdul(int kazandigimOdulId)
        //{
        //    var kazandigimOdul = _kazandigimOdullerService.GetKazandigimOdulById(kazandigimOdulId);
        //    return Ok(kazandigimOdul);
        //}

        //[HttpDelete]
        //[Route("DeleteKazandigimOdul")]
        //public IActionResult DeleteKazandigimOdul(int id)
        //{
        //    var kazandigimOdul = _kazandigimOdullerService.GetKazandigimOdulById(id);
        //    _kazandigimOdullerService.Remove(kazandigimOdul);
        //    return Ok("Silme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpPost]
        //[Route("UpdateKazandigimOduller")]
        //public IActionResult UpdateKazandigimOduller(long personId, int odulId, string? odulAdi, string? kurulusAdi, string? tarih, string? odulAlani)
        //{
        //    var kazandigimOdul = _kazandigimOdullerService.GetKazandigimOdulById(odulId);
        //    if (personId == null)
        //    {
        //        return BadRequest("Kullanıcı Bulunamadı");
        //    }

        //    if (odulAdi == null)
        //    {
        //        return BadRequest("Lütfen Ödül Adı Giriniz");
        //    }
        //    if (kurulusAdi == null || kurulusAdi == "")
        //    {
        //        return BadRequest("Lütfen Kuruluş Adı Giriniz");
        //    }
        //    if (tarih == null)
        //    {
        //        return BadRequest("Lütfen Tarih Giriniz. Örneğin:2015");
        //    }
        //    kazandigimOdul.PersonId = personId;
        //    kazandigimOdul.Oadi = odulAdi;
        //    kazandigimOdul.Kadi = kurulusAdi;
        //    kazandigimOdul.Tarihyil = tarih;
        //    kazandigimOdul.Odulalani = odulAlani;
        //    kazandigimOdul.Tarihay = null;
        //    _kazandigimOdullerService.Update(kazandigimOdul);
        //    return Ok("Güncelleme İşlemi Başarıyla Gerçekleşti");
        //}

        //#endregion

        //#region Doktora Sonrası Burslar

        //[HttpGet]
        //[Route("GetAllKazandigimBurslarByPersonId")]
        //public IActionResult GetAllKazandigimBurslarByPersonId(long personId)
        //{
        //    var kazandigimBurslar = _kazandigimBurslarService.GetAllKazandigimBurslarByPersonId(personId);
        //    return Ok(kazandigimBurslar);
        //}

        //[HttpGet]
        //[Route("GetDoktoraSonrasiKazandigimBurs")]
        //public IActionResult GetDoktoraSonrasiKazandigimBurs(int bursId)
        //{
        //    var burs = _kazandigimBurslarService.GetKazandigimBurslarById(bursId);
        //    return Ok(burs);
        //}

        //[HttpPost]
        //[Route("AddDoktoraSonrasiKazandigimBurslar")]
        //public IActionResult AddDoktoraSonrasiKazandigimBurslar(long personId, string? kurulusAdi, string? bursAdi, DateTime? tarih, string? kullanildigiYer)
        //{
        //    var kazandigimBurs = new KazandigimBurslar();
        //    kazandigimBurs.Id = Convert.ToInt32(_kazandigimBurslarService.GetIdTableName("KAZANDIGIM_BURSLAR"));

        //    if (kurulusAdi == null || kurulusAdi == "")
        //    {
        //        return BadRequest("Lütfen Kuruluş Adı Giriniz");
        //    }
        //    if (bursAdi == null || bursAdi == "")
        //    {
        //        return BadRequest("Lütfen Burs Adı Giriniz");
        //    }
        //    if (tarih == null)
        //    {
        //        return BadRequest("Lütfen Tarih Giriniz. ");
        //    }
        //    if (kullanildigiYer == null)
        //    {
        //        return BadRequest("Lütfen Kullanıldığı Yeri Giriniz");
        //    }
        //    kazandigimBurs.PersonId = personId;
        //    kazandigimBurs.Kadi = kurulusAdi;
        //    kazandigimBurs.Badi = bursAdi;
        //    kazandigimBurs.Tarih = tarih;
        //    kazandigimBurs.Yer = kullanildigiYer;
        //    _kazandigimBurslarService.Add(kazandigimBurs);
        //    return Ok("Ekleme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpDelete]
        //[Route("DeleteDoktoraSonrasiKazandigimBurslar")]
        //public IActionResult DeleteDoktoraSonrasiKazandigimBurslar(int id)
        //{
        //    var kazandigimBurs = _kazandigimBurslarService.GetKazandigimBurslarById(id);
        //    _kazandigimBurslarService.Remove(kazandigimBurs);
        //    return Ok("Silme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpPost]
        //[Route("UpdateDoktoraSonrasiKazandigimBurslar")]
        //public IActionResult UpdateDoktoraSonrasiKazandigimBurslar(long personId, int bursId, string? kurulusAdi, string? bursAdi, DateTime? tarih, string? kullanildigiYer)
        //{
        //    var kazandigimBurs = _kazandigimBurslarService.GetKazandigimBurslarById(bursId);

        //    if (kurulusAdi == null || kurulusAdi == "")
        //    {
        //        return BadRequest("Lütfen Kuruluş Adı Giriniz");
        //    }
        //    if (bursAdi == null || bursAdi == "")
        //    {
        //        return BadRequest("Lütfen Burs Adı Giriniz");
        //    }
        //    if (tarih == null)
        //    {
        //        return BadRequest("Lütfen Tarih Giriniz. ");
        //    }
        //    if (kullanildigiYer == null)
        //    {
        //        return BadRequest("Lütfen Kullanıldığı Yeri Giriniz");
        //    }
        //    kazandigimBurs.PersonId = personId;
        //    kazandigimBurs.Kadi = kurulusAdi;
        //    kazandigimBurs.Badi = bursAdi;
        //    kazandigimBurs.Tarih = tarih;
        //    kazandigimBurs.Yer = kullanildigiYer;
        //    _kazandigimBurslarService.Update(kazandigimBurs);
        //    return Ok("Güncelleme İşlemi Başarıyla Gerçekleşti");
        //}
        //#endregion

        //#region Dergilerde Editörlük

        //[HttpGet]
        //[Route("GetAllBDHakemlikFaaliyetlerimByPersonId")]
        //public IActionResult GetAllBDHakemlikFaaliyetlerimByPersonId(long personId)
        //{
        //    var bdHakemlikFaaliyetlerim = _bdHakemlikFaaliyetlerimService.GetAllBdHakemlikFaaliyetlerimByPersonId(personId);
        //    return Ok(bdHakemlikFaaliyetlerim);
        //}

        //[HttpDelete]
        //[Route("DeleteBdHakemlik")]
        //public IActionResult DeleteBdHakemlik(int id)
        //{
        //    var bdhakemlik = _bdHakemlikFaaliyetlerimService.GetBdHakemlikFaaliyetlerimById(id);
        //    _bdHakemlikFaaliyetlerimService.Remove(bdhakemlik);
        //    return Ok("Silme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpGet]
        //[Route("GetBdHakemlikById")]
        //public IActionResult GetBdHakemlikById(int Id)
        //{
        //    var bdHakemlik = _bdHakemlikFaaliyetlerimService.GetBdHakemlikFaaliyetlerimById(Id);
        //    return Ok(bdHakemlik);
        //}

        //[HttpPost]
        //[Route("AddDergiHakemlik")]
        //public IActionResult AddDergiHakemlik(long personId, string? dergiAdi, int? bIndeks, int? gorev, int? dergiAy, int? dergiYil, DateTime? basTarih, DateTime? bitTarih)
        //{
        //    var hakemlik = new BdHakemlikFaaliyetlerim();
        //    hakemlik.Id = Convert.ToInt32(_ayService.GetIdTableName("BD_HAKEMLIK_FAALIYETLERIM"));

        //    if (dergiAdi == null)
        //    {
        //        return BadRequest("Lütfen Dergi Adını Giriniz");
        //    }
        //    if (bIndeks == null)
        //    {
        //        return BadRequest("Lütfen Bilimsel Indeks Seçiniz");
        //    }
        //    if (gorev == null)
        //    {
        //        return BadRequest("Lütfen Görevi Seçiniz");
        //    }
        //    if (gorev == 1 || gorev == 7 || gorev == 6 || gorev == 2 || gorev == 3 || gorev == 4 || gorev == 5)
        //    {
        //        if (dergiAy == null)
        //        {
        //            return BadRequest("Lütfen Dergi Ayını Seçiniz");
        //        }
        //        if (dergiYil == null)
        //        {
        //            return BadRequest("Lütfen Dergi Yılını Giriniz");
        //        }
        //    }
        //    if (gorev == 8 || gorev == 9)
        //    {
        //        if (basTarih == null)
        //        {
        //            return BadRequest("Lütfen Başlangıç Tarihini Seçiniz");
        //        }
        //        if (bitTarih == null)
        //        {
        //            return BadRequest("Lütfen Bitiş Tarihini Seçiniz");
        //        }
        //        if (bitTarih < basTarih)
        //        {
        //            return BadRequest("Bitiş Tarihi, Başlanıç Tarihinden Önce Olamaz");
        //        }
        //    }

        //    hakemlik.PersonId = personId;
        //    hakemlik.DergiAdi = dergiAdi;
        //    hakemlik.ScientificIndex = Convert.ToByte(bIndeks);
        //    hakemlik.Gorev = Convert.ToByte(gorev);
        //    if (gorev == 8 || gorev == 9)
        //    {
        //        hakemlik.DergiAyId = null;
        //        hakemlik.DergiYili = null;
        //    }
        //    else
        //    {
        //        hakemlik.DergiAyId = dergiAy;
        //        hakemlik.DergiYili = dergiYil;
        //    }
        //    if (gorev >= 1 && gorev <= 7)
        //    {
        //        hakemlik.BitisTarihi = null;
        //        hakemlik.BaslangicTarihi = null;
        //    }
        //    else
        //    {
        //        hakemlik.BitisTarihi = bitTarih;
        //        hakemlik.BaslangicTarihi = basTarih;
        //    }
        //    _bdHakemlikFaaliyetlerimService.Add(hakemlik);
        //    return Ok("Ekleme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpPost]
        //[Route("UpdateDergiHakemlik")]
        //public IActionResult UpdateDergiHakemlik(long personId, int? hId, string? dergiAdi, int? bIndeks, int? gorev, int? dergiAy, int? dergiYil, DateTime? basTarih, DateTime? bitTarih)
        //{
        //    var hakemlik = _bdHakemlikFaaliyetlerimService.GetBdHakemlikFaaliyetlerimById((int)hId);
        //    if (dergiAdi == null)
        //    {
        //        return BadRequest("Lütfen Dergi Adını Giriniz");
        //    }
        //    if (bIndeks == null)
        //    {
        //        return BadRequest("Lütfen Bilimsel Indeks Seçiniz");
        //    }
        //    if (gorev == null)
        //    {
        //        return BadRequest("Lütfen Görevi Seçiniz");
        //    }
        //    if (gorev == 1 || gorev == 7 || gorev == 6 || gorev == 2 || gorev == 3 || gorev == 4 || gorev == 5)
        //    {
        //        if (dergiAy == null)
        //        {
        //            return BadRequest("Lütfen Dergi Ayını Seçiniz");
        //        }
        //        if (dergiYil == null)
        //        {
        //            return BadRequest("Lütfen Dergi Yılını Giriniz");
        //        }
        //    }
        //    if (gorev == 8 || gorev == 9)
        //    {
        //        if (basTarih == null)
        //        {
        //            return BadRequest("Lütfen Başlangıç Tarihini Seçiniz");
        //        }
        //        if (bitTarih == null)
        //        {
        //            return BadRequest("Lütfen Bitiş Tarihini Seçiniz");
        //        }
        //        if (bitTarih < basTarih)
        //        {
        //            return BadRequest("Bitiş Tarihi, Başlanıç Tarihinden Önce Olamaz");
        //        }
        //    }

        //    hakemlik.PersonId = personId;
        //    hakemlik.DergiAdi = dergiAdi;
        //    hakemlik.ScientificIndex = Convert.ToByte(bIndeks);
        //    hakemlik.Gorev = Convert.ToByte(gorev);
        //    if (gorev == 8 || gorev == 9)
        //    {
        //        hakemlik.DergiAyId = null;
        //        hakemlik.DergiYili = null;
        //    }
        //    else
        //    {
        //        hakemlik.DergiAyId = dergiAy;
        //        hakemlik.DergiYili = dergiYil;
        //    }
        //    if (gorev >= 1 && gorev <= 7)
        //    {
        //        hakemlik.BitisTarihi = null;
        //        hakemlik.BaslangicTarihi = null;
        //    }
        //    else
        //    {
        //        hakemlik.BitisTarihi = bitTarih;
        //        hakemlik.BaslangicTarihi = basTarih;
        //    }
        //    _bdHakemlikFaaliyetlerimService.Update(hakemlik);
        //    return Ok("Güncelleme İşlemi Başarıyla Gerçekleşti");
        //}
        //#endregion

        //#region Yayinlarda Hakemlik

        //[HttpGet]
        //[Route("GetAllYayinHakemliklerByPersonId")]
        //public IActionResult GetAllYayinHakemliklerByPersonId(long personId)
        //{
        //    var yayinHakemlikler = _yayinHakemlikService.GetAllYayinHakemlikByPersonId(personId);
        //    return Ok(yayinHakemlikler);
        //}

        //[HttpGet]
        //[Route("GetYayinHakemlik")]
        //public IActionResult GetYayinHakemlik(int hId)
        //{
        //    var hakemlik = _yayinHakemlikService.GetYayinHakemlikById(hId);
        //    return Ok(hakemlik);
        //}

        //[HttpPost]
        //[Route("AddYayinHakemlik")]
        //public IActionResult AddYayinHakemlik(long personId, string? dergiAdi, int? bIndeks, string? tarih, string? makaleAdedi)
        //{
        //    var hakemlik = new YayinHakemlik();
        //    hakemlik.Id = Convert.ToInt32(_yayinHakemlikService.GetIdTableName("YAYIN_HAKEMLIK"));

        //    if (dergiAdi == null || dergiAdi == "")
        //    {
        //        return BadRequest("Lütfen Derginin Adını Giriniz");
        //    }
        //    if (bIndeks == null)
        //    {
        //        return BadRequest("Lütfen Bilimsel İndeks Seçiniz");
        //    }
        //    if (tarih == null)
        //    {
        //        return BadRequest("Lütfen Tarih Giriniz. ");
        //    }
        //    if (Convert.ToInt32(tarih) < 1930 || Convert.ToInt32(tarih) > 2040)
        //    {
        //        return BadRequest("Geçerli bir tarih formatı giriniz. Örneğin: 2001");
        //    }
        //    if (makaleAdedi == null || makaleAdedi == "")
        //    {
        //        return BadRequest("Lütfen Makale Adedi Giriniz");
        //    }
        //    hakemlik.PersonId = personId;
        //    hakemlik.DergiAdi = dergiAdi;
        //    hakemlik.ScientificIndex = bIndeks;
        //    hakemlik.Tarihyil = tarih;
        //    hakemlik.Madedi = makaleAdedi;
        //    hakemlik.Tarihay = null;
        //    _yayinHakemlikService.Add(hakemlik);
        //    return Ok("Ekleme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpDelete]
        //[Route("DeleteYayinHakemlik")]
        //public IActionResult DeleteYayinHakemlik(int id)
        //{
        //    var hakemlik = _yayinHakemlikService.GetYayinHakemlikById(id);
        //    _yayinHakemlikService.Remove(hakemlik);
        //    return Ok("Silme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpPost]
        //[Route("UpdateYayinHakemlik")]
        //public IActionResult UpdateYayinHakemlik(long personId, int hId, string? dergiAdi, int? bIndeks, string? tarih, string? makaleAdedi)
        //{
        //    var hakemlik = _yayinHakemlikService.GetYayinHakemlikById(hId);

        //    if (dergiAdi == null || dergiAdi == "")
        //    {
        //        return BadRequest("Lütfen Derginin Adı Giriniz");
        //    }
        //    if (bIndeks == null)
        //    {
        //        return BadRequest("Lütfen Bilimsel İndeks Seçiniz");
        //    }
        //    if (tarih == null)
        //    {
        //        return BadRequest("Lütfen Tarih Giriniz. ");
        //    }
        //    if (Convert.ToInt32(tarih) < 1930 || Convert.ToInt32(tarih) > 2040)
        //    {
        //        return BadRequest("Geçerli bir tarih formatı giriniz. Örneğin: 2001");
        //    }
        //    if (makaleAdedi == null || makaleAdedi == "")
        //    {
        //        return BadRequest("Lütfen Makale Adedi Giriniz");
        //    }
        //    hakemlik.PersonId = personId;
        //    hakemlik.DergiAdi = dergiAdi;
        //    hakemlik.ScientificIndex = bIndeks;
        //    hakemlik.Tarihyil = tarih;
        //    hakemlik.Madedi = makaleAdedi;
        //    hakemlik.Tarihay = null;
        //    _yayinHakemlikService.Update(hakemlik);
        //    return Ok("Güncelleme İşlemi Başarıyla Gerçekleşti");
        //}
        //#endregion

        //#region Arastirma Alanlariniz

        //#endregion

        //#region Lisansüstü Tezler
        //[HttpGet]
        //[Route("GetAllYonetilenLisansustuTezlerByPersonId")]
        //public IActionResult GetAllYonetilenLisansustuTezlerByPersonId(long personId)
        //{
        //    var lisansustuTezler = _yonetilenLisansustuTezlerService.GetAllYonetilenLisansustuTezlerByPersonId(personId);
        //    return Ok(lisansustuTezler);
        //}
        ////yonetilen lisansüstütezlerde fakulte listesi için
        //[HttpGet]
        //[Route("GetFakulteListType1")]
        //public IActionResult GetFakulteListType1()
        //{
        //    var fakulte = _corpnodeService.FakulteListType1();
        //    return Ok(fakulte);
        //}

        //[HttpGet]
        //[Route("GetLisansUstuTezById")]
        //public IActionResult GetLisansUstuTezById(int Id)
        //{
        //    var tez = _yonetilenLisansustuTezlerService.GetYonetilenLisansustuTez(Id);
        //    return Ok(tez);
        //}

        //[HttpGet]
        //[Route("GetYonetilenLuTezProjeTezByLuTezId")]
        //public IActionResult GetYonetilenLuTezProjeTezByLuTezId(int Id)
        //{
        //    var tez = _yonetilenLisansustuTezlerService.GetYonetilenLisansustuTez(Id);
        //    var tezProje = _yonetilenLutezProjeService.GetYonetilenLutezProjeByLutezId(tez.Id);
        //    return Ok(tezProje);
        //}

        //[HttpGet]
        //[Route("GetYonetilenLisansustutUploadGetByID")]
        //public IActionResult GetYonetilenLisansustutUploadGetByID(decimal Id)
        //{
        //    var tezUpload = _yonetilenLisansustutUploadService.YonetilenLisansustutUploadGetByID(Id);
        //    return Ok(tezUpload);
        //}

        //[HttpDelete]
        //[Route("DeleteLisansUstuTez")]
        //public IActionResult DeleteLisansUstuTez(int Id)
        //{
        //    var tez = _yonetilenLisansustuTezlerService.GetYonetilenLisansustuTez(Id);

        //    var tezProje = _yonetilenLutezProjeService.GetYonetilenLutezProjeByLutezId(tez.Id);

        //    if (tezProje != null)
        //    {
        //        _yonetilenLutezProjeService.Remove(tezProje);
        //    }
        //    _yonetilenLisansustuTezlerService.Remove(tez);

        //    return Ok("Silme İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpPost]
        //[Route("TezSunumBasvur")]
        //public IActionResult TezSunumBasvur(int tezId, long? projectId, long personId)
        //{
        //    var tez = _yonetilenLisansustuTezlerService.GetYonetilenLisansustuTez(tezId);
        //    var proje = _projectService.GetProject(projectId);
        //    if (proje == null)
        //    {
        //        return BadRequest("Lütfen Projeyi Seçiniz");
        //    }
        //    tez.ProjectNo = proje.Id;
        //    tez.PersonId = personId;
        //    _yonetilenLisansustuTezlerService.Update(tez);
        //    return Ok("Başvuru İşlemi Başarıyla Gerçekleşti");
        //}

        //[HttpPost]
        //[Route("AddLisansUstuTezler")]
        //public IActionResult AddLisansUstuTezler
        //    (long personId,
        //    string? tezTuru,
        //    string? tezBaslik,
        //    string? ogrAdi,
        //    string? tezDurumu,
        //    DateTime? bitisTarihi,
        //    short? enstituId,
        //    string? esDanisman,
        //    IFormFile? file,
        //    int? answer,
        //    int? thank,
        //    string? projeDestekTipi,
        //    int? bapProjectType,
        //    int? bapProjectId,
        //    string? projeKodu,
        //    int? baslangicYil,
        //    int? bitisYil,
        //    string? projeAdi,
        //    string? destekKurum
        //    )
        //{
        //    var tez = new YonetilenLisansustuTezler();
        //    var tezUpload = new YonetilenLisansustutUpload();
        //    //tez.Id = Convert.ToInt32(_yonetilenLisansustuTezlerService.GetIdTableName("YONETILENLISANSUSTUTEZLER"));

        //    if (personId == null)
        //    {
        //        return BadRequest("Kullanıcı Bulunamadı");
        //    }
        //    if (tezTuru == null)
        //    {
        //        return BadRequest("Lütfen Tezin Türünü Seçiniz");
        //    }
        //    if (enstituId == null)
        //    {
        //        return BadRequest("Lütfen Enstitü Seçiniz");
        //    }
        //    if (tezBaslik == null)
        //    {
        //        return BadRequest("Lütfen Tez Başlığını Giriniz");
        //    }
        //    if (ogrAdi == null)
        //    {
        //        return BadRequest("Lütfen Öğrenci Adını Giriniz");
        //    }
        //    if (tezDurumu == null)
        //    {
        //        return BadRequest("Lütfen Tez Durumunu Seçiniz");
        //    }
        //    if (tezDurumu == "Tamamlandı")
        //    {
        //        if (bitisTarihi == null)
        //        {
        //            return BadRequest("Lütfen Bitiş Tarihini Seçiniz");

        //        }
        //    }
        //    if (file == null)
        //    {
        //        return BadRequest("Lütfen Yayın Dokumanı Yükleyiniz");
        //    }

        //    if (file != null)
        //    {
        //        // Dosya uzantısını al
        //        var fileExtension = Path.GetExtension(file.FileName).ToLower();

        //        // Dosya uzantısının geçerli olup olmadığını kontrol et
        //        if (fileExtension == ".doc" || fileExtension == ".docx" || fileExtension == ".pdf")
        //        {
        //            string fileName = "tezdokumani_" + tez.Id;
        //            var fileResult = _fileService.SaveFile(file, "LisansUstuTezFile", fileName);
        //            if (fileResult.Item1 == 1)
        //            {
        //                //tezUpload.Id = Convert.ToInt32(_yonetilenLisansustutUploadService.GetIdTableName("YONETILENLISANSUSTUTUPLOAD"));
        //                tezUpload.YonetilenLisansustuTezlerId = tez.Id;
        //                tezUpload.UploadDate = DateTime.Now;
        //                tezUpload.TempName = fileResult.Item2;
        //                tezUpload.OriginalName = "Tezdokumani.pdf";
        //                tezUpload.Permission = 0;
        //                tezUpload.Status = 1;
        //                tezUpload.Success = 0;
        //            }
        //            _yonetilenLisansustutUploadService.Add(tezUpload);
        //        }
        //        else
        //        {
        //            // Geçersiz dosya türü için hata mesajı
        //            return BadRequest("Geçersiz dosya türü. Lütfen Yüklemiş Olduğunuz Dosyanın Uzantılarını Kontrol Ediniz, Dosya Uzantıları doc, docx ya da pdf Olmalıdır.");
        //        }
        //    }

        //    tez.PersonId = personId;
        //    tez.TezinTuru = tezTuru;
        //    tez.TezinBasligi = tezBaslik;
        //    tez.OgrAdi = ogrAdi;
        //    tez.TezinDurumu = tezDurumu;
        //    tez.BitisTarihi = bitisTarihi;
        //    tez.YonetilenLisansustuTezler1 = null;
        //    tez.Type = 0;
        //    tez.EnstituId = enstituId;
        //    tez.EsDanisman = esDanisman;
        //    tez.TempName = tezUpload.OriginalName;
        //    tez.Name = null;
        //    tez.Answer = answer;
        //    tez.Thank = thank;
        //    tez.YayinSunumuId = null;
        //    _yonetilenLisansustuTezlerService.Add(tez);

        //    if ((answer != null && answer == 1) || (thank != null && thank == 1))
        //    {
        //        if (projeDestekTipi == null || projeDestekTipi == "")
        //        {
        //            return BadRequest("Lütfen Proje Destek Türünü Seçiniz");
        //        }
        //        else
        //        {
        //            if (projeDestekTipi == "BAP")
        //            {
        //                if (bapProjectType == 0 || bapProjectType == null)
        //                {
        //                    return BadRequest("Lütfen Projenin Sistemde Kayıtlı Olup Olmadığını Seçiniz");
        //                }
        //                else if (bapProjectType == 1)
        //                {
        //                    if (bapProjectId == null || bapProjectId == 0)
        //                    {
        //                        return BadRequest("Lütfen İlgili Bap Projesini Seçiniz");
        //                    }
        //                    var proje = _projectService.GetProject((int)bapProjectId);
        //                    if (proje != null)
        //                    {
        //                        var tezProje = new YonetilenLutezProje();
        //                        tezProje.Id = Convert.ToInt32(_yonetilenLutezProjeService.GetIdTableName("YONETILEN_LUTEZ_PROJE"));
        //                        tezProje.SupportType = projeDestekTipi;
        //                        tezProje.SysBapProject = 1;
        //                        tezProje.ProjectNo = Convert.ToString(bapProjectId);
        //                        if (proje.Title != null && proje.Title.Length > 100)
        //                        {
        //                            tezProje.ProjectName = proje.Title.Substring(0, 100);
        //                        }
        //                        else
        //                        {
        //                            tezProje.ProjectName = proje.Title;
        //                        }
        //                        tezProje.BapProjectId = bapProjectId;
        //                        tezProje.PersonId = personId;
        //                        tezProje.YonetilenLutezId = tez.Id;
        //                        _yonetilenLutezProjeService.Add(tezProje);
        //                    }
        //                }
        //                else if (bapProjectType == 2)
        //                {
        //                    var tezProje1 = new YonetilenLutezProje();
        //                    tezProje1.Id = Convert.ToInt32(_yonetilenLutezProjeService.GetIdTableName("YONETILEN_LUTEZ_PROJE"));
        //                    if (projeKodu == null)
        //                    {
        //                        return BadRequest("Lütfen Proje Kodunu Giriniz");
        //                    }
        //                    tezProje1.SupportType = projeDestekTipi;
        //                    tezProje1.ProjectNo = projeKodu;


        //                    if (baslangicYil < 1930 || baslangicYil > 2050)
        //                    {
        //                        return BadRequest("Geçerli bir başlangıç yılı giriniz. Örneğin: 2001");
        //                    }

        //                    if (bitisYil < 1930 || bitisYil > 2050)
        //                    {
        //                        return BadRequest("Geçerli bir bitiş yılı giriniz. Örneğin: 2001");
        //                    }

        //                    if (bitisYil < baslangicYil)
        //                    {
        //                        return BadRequest("Bitiş yılı başlangıç yılından önce olamaz.");
        //                    }
        //                    tezProje1.PStartYear = baslangicYil;
        //                    tezProje1.PFinishYear = bitisYil;
        //                    tezProje1.ProjectName = projeAdi;
        //                    tezProje1.SupportCompany = destekKurum;
        //                    tezProje1.PersonId = personId;
        //                    tezProje1.YonetilenLutezId = tez.Id;
        //                    _yonetilenLutezProjeService.Add(tezProje1);
        //                }
        //                else
        //                {
        //                    return BadRequest("Lütfen Projenin Sistemde Kayıtlı Olup Olmadığını Seçiniz");
        //                }
        //            }
        //            else if (projeDestekTipi == "Diger")
        //            {
        //                var tezProje2 = new YonetilenLutezProje();
        //                tezProje2.Id = Convert.ToInt32(_yonetilenLutezProjeService.GetIdTableName("YONETILEN_LUTEZ_PROJE"));
        //                if (projeKodu == null)
        //                {
        //                    return BadRequest("Lütfen Proje Kodunu Giriniz");
        //                }
        //                tezProje2.SupportType = projeDestekTipi;
        //                tezProje2.ProjectNo = projeKodu;


        //                if (baslangicYil < 1930 || baslangicYil > 2050)
        //                {
        //                    return BadRequest("Geçerli bir başlangıç yılı giriniz. Örneğin: 2001");
        //                }

        //                if (bitisYil < 1930 || bitisYil > 2050)
        //                {
        //                    return BadRequest("Geçerli bir bitiş yılı giriniz. Örneğin: 2001");
        //                }

        //                if (bitisYil < baslangicYil)
        //                {
        //                    return BadRequest("Bitiş yılı başlangıç yılından önce olamaz.");
        //                }
        //                tezProje2.PStartYear = baslangicYil;
        //                tezProje2.PFinishYear = bitisYil;
        //                tezProje2.ProjectName = projeAdi;
        //                tezProje2.SupportCompany = destekKurum;
        //                tezProje2.PersonId = personId;
        //                tezProje2.YonetilenLutezId = tez.Id;
        //                _yonetilenLutezProjeService.Add(tezProje2);
        //            }
        //        }
        //    }
        //    return Ok("Ekleme İşlemi Başarıyla Gerçekleşti");
        //}
        //#endregion

        //#region Düzenlenen Toplantılar
        //[HttpGet]
        //[Route("GetAllDuzenlenenBilimselToplantilarByPersonId")]
        //public IActionResult GetAllDuzenlenenBilimselToplantilarByPersonId(long personId)
        //{
        //    var duzenlenenToplantilar = _dbilimselToplantiService.GetAllDbilimselToplantiByPersonId(personId);
        //    return Ok(duzenlenenToplantilar);
        //}

        //[HttpPost]
        //[Route("AddPersonDuzenlenenToplanti")]
        //public IActionResult AddPersonDuzenlenenToplanti(long personId, string? toplantiAdi, string? toplantiTuru, string? toplantiYeri, DateTime? toplantiTarihi, int? toplantiNiteligi, int? sunulanBildiriAdedi)
        //{
        //    var duzenlenenToplanti = new DbilimselToplanti();
        //    duzenlenenToplanti.Id = Convert.ToInt32(_dbilimselToplantiService.GetIdTableName("DBILIMSEL_TOPLANTI"));

        //    if (toplantiAdi == null || toplantiAdi == "")

        //    {
        //        return BadRequest("Lütfen Toplantı Adını Giriniz");
        //    }
        //    if (toplantiTuru == null || toplantiTuru == "")
        //    {
        //        return BadRequest("Lütfen Toplantı Türünü Seçiniz");
        //    }
        //    if (toplantiNiteligi == null)
        //    {
        //        return BadRequest("Lütfen Toplantı Niteliğini Seçiniz");
        //    }
        //    if (toplantiYeri == null || toplantiYeri == "")
        //    {
        //        return BadRequest("Lütfen Toplantı Yerini Giriniz");
        //    }
        //    if (toplantiTarihi == null)
        //    {
        //        return BadRequest("Lütfen Toplantı Tarihini Seçiniz");
        //    }
        //    if (sunulanBildiriAdedi == null)
        //    {
        //        return BadRequest("Lütfen Sunulan Bildiri Adedini Giriniz");
        //    }

        //    duzenlenenToplanti.PersonId = personId;
        //    duzenlenenToplanti.ToplantiAdi = toplantiAdi;
        //    duzenlenenToplanti.ToplantiTuru = toplantiTuru;
        //    duzenlenenToplanti.ToplantiYeri = toplantiYeri;
        //    duzenlenenToplanti.ToplantiTarihi = toplantiTarihi;
        //    duzenlenenToplanti.ToplantiNiteligi = toplantiNiteligi;
        //    duzenlenenToplanti.SunulanBildiriAdedi = sunulanBildiriAdedi;
        //    _dbilimselToplantiService.Add(duzenlenenToplanti);

        //    var duzenlenenToplantilar = _dbilimselToplantiService.GetAllDbilimselToplantiByPersonId(personId);
        //    return Ok("Ekleme İşlemi Başarıyla Gerçekleşmiştir");

        //}

        //[HttpDelete]
        //[Route("DeletePersonDuzenlenenToplanti")]
        //public IActionResult DeletePersonDuzenlenenToplanti(int id)
        //{
        //    var duzenlenenToplanti = _dbilimselToplantiService.GetDuzenledigimToplantiById(id);
        //    _dbilimselToplantiService.Remove(duzenlenenToplanti);

        //    var duzenlenenToplantilar = _dbilimselToplantiService.GetAllDbilimselToplantiByPersonId(Convert.ToInt32(duzenlenenToplanti.PersonId));
        //    return Ok("Silme İşlemi Başarıyla Gerçekleşmiştir");
        //}

        //[HttpGet]
        //[Route("GetPersonDuzenlenenToplanti")]
        //public IActionResult GetPersonDuzenlenenToplanti(int dToplantiId)
        //{
        //    var duzenlenenToplanti = _dbilimselToplantiService.GetDuzenledigimToplantiById(dToplantiId);
        //    return Ok(duzenlenenToplanti);

        //}

        //[HttpPost]
        //[Route("UpdatePersonDuzenlenenToplanti")]
        //public IActionResult UpdatePersonDuzenlenenToplanti(int dToplantiId, long personId, string? toplantiAdi, string? toplantiTuru, string? toplantiYeri, DateTime? toplantiTarihi, int? toplantiNiteligi, int? sunulanBildiriAdedi)
        //{
        //    var duzenlenenToplanti = _dbilimselToplantiService.GetDuzenledigimToplantiById(dToplantiId);

        //    if (toplantiAdi == null || toplantiAdi == "")

        //    {
        //        return BadRequest("Lütfen Toplantı Adını Giriniz");
        //    }
        //    if (toplantiTuru == null || toplantiTuru == "")
        //    {
        //        return BadRequest("Lütfen Toplantı Türünü Seçiniz");
        //    }
        //    if (toplantiNiteligi == null)
        //    {
        //        return BadRequest("Lütfen Toplantı Niteliğini Seçiniz");
        //    }
        //    if (toplantiYeri == null || toplantiYeri == "")
        //    {
        //        return BadRequest("Lütfen Toplantı Yerini Giriniz");
        //    }
        //    if (toplantiTarihi == null)
        //    {
        //        return BadRequest("Lütfen Toplantı Tarihini Seçiniz");
        //    }
        //    if (sunulanBildiriAdedi == null)
        //    {
        //        return BadRequest("Lütfen Sunulan Bildiri Adedini Giriniz");
        //    }

        //    duzenlenenToplanti.PersonId = personId;
        //    duzenlenenToplanti.ToplantiAdi = toplantiAdi;
        //    duzenlenenToplanti.ToplantiTuru = toplantiTuru;
        //    duzenlenenToplanti.ToplantiYeri = toplantiYeri;
        //    duzenlenenToplanti.ToplantiTarihi = toplantiTarihi;
        //    duzenlenenToplanti.ToplantiNiteligi = toplantiNiteligi;
        //    duzenlenenToplanti.SunulanBildiriAdedi = sunulanBildiriAdedi;
        //    _dbilimselToplantiService.Update(duzenlenenToplanti);

        //    var duzenlenenToplantilar = _dbilimselToplantiService.GetAllDbilimselToplantiByPersonId(Convert.ToInt32(duzenlenenToplanti.PersonId));
        //    return Ok("Güncelleme İşlemi Başarıyla Gerçekleşmiştir");
        //}

        //#endregion

        //#region Katılınan Toplantılar
        //[HttpGet]
        //[Route("GetAllKatilinanBilimselToplantilarByPersonId")]
        //public IActionResult GetAllKatilinanBilimselToplantilarByPersonId(long personId)
        //{
        //    var katilinanToplantilar = _kbilimselToplantiService.GetAllKbilimselToplantiByPersonId(personId);
        //    return Ok(katilinanToplantilar);
        //}

        //[HttpPost]
        //[Route("AddPersonKatilinanToplanti")]
        //public IActionResult AddPersonKatilinanToplanti(long personId, string? toplantiAdi, string? toplantiKonusu, string? toplantiTuru, DateTime? toplantiTarihi, int? toplantiNiteligi, string? toplantiYeri, int? toplantiUlke, string? katki)
        //{
        //    var katilinanToplanti = new KbilimselToplanti();
        //    katilinanToplanti.Id = Convert.ToInt32(_kbilimselToplantiService.GetIdTableName("KBILIMSEL_TOPLANTI"));

        //    if (toplantiAdi == null || toplantiAdi == "")
        //    {
        //        return BadRequest("Lütfen Toplantı Adını Giriniz");
        //    }
        //    if (toplantiKonusu == null || toplantiKonusu == "")
        //    {
        //        return BadRequest("Lütfen Toplantı Konusunu Giriniz");
        //    }
        //    if (toplantiTuru == null || toplantiTuru == "")
        //    {
        //        return BadRequest("Lütfen Toplantı Türünü Seçiniz");
        //    }
        //    if (toplantiNiteligi == null)
        //    {
        //        return BadRequest("Lütfen Toplantı Niteliğini Seçiniz");
        //    }
        //    if (toplantiYeri == null || toplantiYeri == "")
        //    {
        //        return BadRequest("Lütfen Toplantı Yerini Giriniz");
        //    }

        //    if (toplantiUlke == null)
        //    {
        //        return BadRequest("Lütfen Toplantı Ülkesini Seçiniz");
        //    }
        //    if (toplantiTarihi == null)
        //    {
        //        return BadRequest("Lütfen Toplantı Tarihini Giriniz");
        //    }
        //    if (katki == null)
        //    {
        //        return BadRequest("Lütfen Toplantının Katkısını Giriniz");
        //    }

        //    katilinanToplanti.PersonId = personId;
        //    katilinanToplanti.ToplantiAdi = toplantiAdi;
        //    katilinanToplanti.ToplantiKonu = toplantiKonusu;
        //    katilinanToplanti.ToplantiTuru = toplantiTuru;
        //    katilinanToplanti.ToplantiTarihi = toplantiTarihi;
        //    katilinanToplanti.ToplantiNiteligi = toplantiNiteligi;
        //    katilinanToplanti.ToplantiYeri = toplantiYeri;
        //    katilinanToplanti.CountriesId = toplantiUlke;
        //    katilinanToplanti.Katkisi = katki;
        //    _kbilimselToplantiService.Add(katilinanToplanti);

        //    return Ok("Ekleme İşlemi Başarıyla Gerçekleşmiştir");

        //}

        //[HttpDelete]
        //[Route("DeletePersonKatilinanToplanti")]
        //public IActionResult DeletePersonKatilinanToplanti(int id)
        //{
        //    var katilinanToplanti = _kbilimselToplantiService.GetKatildigimToplantiById(id);
        //    _kbilimselToplantiService.Remove(katilinanToplanti);
        //    return Ok("Silme İşlemi Başarıyla Gerçekleşmiştir");
        //}

        //[HttpGet]
        //[Route("GetPersonKatilinanToplanti")]
        //public IActionResult GetPersonKatilinanToplanti(int kToplantiId)
        //{
        //    var katilinanToplanti = _kbilimselToplantiService.GetKatildigimToplantiById(kToplantiId);
        //    return Ok(katilinanToplanti);
        //}

        //[HttpPost]
        //[Route("UpdatePersonKatilinanToplanti")]
        //public IActionResult UpdatePersonKatilinanToplanti(int kToplantiId, long personId, string? toplantiAdi, string? toplantiKonusu, string? toplantiTuru, DateTime? toplantiTarihi, int? toplantiNiteligi, string? toplantiYeri, int? toplantiUlke, string? katki)
        //{
        //    var katilinanToplanti = _kbilimselToplantiService.GetKatildigimToplantiById(kToplantiId);

        //    if (toplantiAdi == null || toplantiAdi == "")
        //    {
        //        return BadRequest("Lütfen Toplantı Adını Giriniz");
        //    }
        //    if (toplantiKonusu == null || toplantiKonusu == "")
        //    {
        //        return BadRequest("Lütfen Toplantı Konusunu Giriniz");
        //    }
        //    if (toplantiTuru == null || toplantiTuru == "")
        //    {
        //        return BadRequest("Lütfen Toplantı Türünü Seçiniz");
        //    }
        //    if (toplantiNiteligi == null)
        //    {
        //        return BadRequest("Lütfen Toplantı Niteliğini Seçiniz");
        //    }
        //    if (toplantiYeri == null || toplantiYeri == "")
        //    {
        //        return BadRequest("Lütfen Toplantı Yerini Giriniz");
        //    }

        //    if (toplantiUlke == null)
        //    {
        //        return BadRequest("Lütfen Toplantı Ülkesini Seçiniz");
        //    }
        //    if (toplantiTarihi == null)
        //    {
        //        return BadRequest("Lütfen Toplantı Tarihini Giriniz");
        //    }
        //    if (katki == null)
        //    {
        //        return BadRequest("Lütfen Toplantının Katkısını Giriniz");
        //    }
        //    katilinanToplanti.PersonId = personId;
        //    katilinanToplanti.ToplantiAdi = toplantiAdi;
        //    katilinanToplanti.ToplantiKonu = toplantiKonusu;
        //    katilinanToplanti.ToplantiTuru = toplantiTuru;
        //    katilinanToplanti.ToplantiTarihi = toplantiTarihi;
        //    katilinanToplanti.ToplantiNiteligi = toplantiNiteligi;
        //    katilinanToplanti.ToplantiYeri = toplantiYeri;
        //    katilinanToplanti.CountriesId = toplantiUlke;
        //    katilinanToplanti.Katkisi = katki;
        //    _kbilimselToplantiService.Update(katilinanToplanti);

        //    return Ok("Güncelleme İşlemi Başarıyla Gerçekleşti");
        //}
        //#endregion

        //#region Düzenlenen Eğitim Seminerleri
        //[HttpGet]
        //[Route("GetAllDuzenlenenEgitimSeminerlerByPersonId")]
        //public IActionResult GetAllDuzenlenenEgitimSeminerlerByPersonId(long personId)
        //{
        //    var duzenledigimEgitimSeminerler = _duzenledigimEgitimSeminerService.GetAllDuzenlenenEgitimSeminerByPersonId(personId);
        //    return Ok(duzenledigimEgitimSeminerler);
        //}

        //[HttpPost]
        //[Route("AddPersonDuzenlenenEgitimSeminer")]
        //public IActionResult AddPersonDuzenlenenEgitimSeminer(long personId, string? baslik, string? yonetici, string? gorevliOgretimElemanlar, DateTime? Tarih, int? kisi)
        //{
        //    var duzenledigimEgitimSeminer = new DuzenledigimEgitimSeminer();
        //    duzenledigimEgitimSeminer.Id = Convert.ToInt32(_duzenledigimEgitimSeminerService.GetIdTableName("DEGITIM_SEMINER"));

        //    if (baslik == null)
        //    {
        //        return BadRequest("Lütfen Eğitim Seminerinin Başlığını Giriniz");
        //    }
        //    if (yonetici == null)
        //    {
        //        return BadRequest("Lütfen Eğitim Seminerinin Yöneticisini Giriniz");
        //    }
        //    if (gorevliOgretimElemanlar == null)
        //    {
        //        return BadRequest("Lütfen Görev Alan Öğretim Elemanlarını Giriniz");
        //    }
        //    if (Tarih == null)
        //    {
        //        return BadRequest("Lütfen Eğitim Seminerinin Tarihini Giriniz");
        //    }
        //    if (kisi == null)
        //    {
        //        return BadRequest("Lütfen Eğitim Seminerine Katılan Kişi Sayısını Giriniz");
        //    }
        //    duzenledigimEgitimSeminer.PersonId = personId;
        //    duzenledigimEgitimSeminer.Baslik = baslik;
        //    duzenledigimEgitimSeminer.Yonetici = yonetici;
        //    duzenledigimEgitimSeminer.GorevAlanOgretimElemanlari = gorevliOgretimElemanlar;
        //    duzenledigimEgitimSeminer.Tarih = Tarih;
        //    duzenledigimEgitimSeminer.KatilanKisiSayisi = kisi;
        //    _duzenledigimEgitimSeminerService.Add(duzenledigimEgitimSeminer);

        //    return Ok("Ekleme İşlemi Başarıyla Gerçekleşmiştir");
        //}


        //[HttpDelete]
        //[Route("DeletePersonDuzenledigimSeminer")]
        //public IActionResult DeletePersonDuzenledigimSeminer(int id)
        //{
        //    var duzenledigimEgitimSeminer = _duzenledigimEgitimSeminerService.GetDuzenledigimEgitimSeminerById(id);
        //    _duzenledigimEgitimSeminerService.Remove(duzenledigimEgitimSeminer);

        //    return Ok("Silme İşlemi Başarıyla Gerçekleşmiştir");
        //}

        //[HttpGet]
        //[Route("GetPersonDuzenledigimSeminer")]
        //public IActionResult GetPersonDuzenledigimSeminer(int duzenledigimSeminerId)
        //{
        //    var duzenledigimEgitimSeminer = _duzenledigimEgitimSeminerService.GetDuzenledigimEgitimSeminerById(duzenledigimSeminerId);
        //    return Ok(duzenledigimEgitimSeminer);
        //}

        //[HttpPost]
        //[Route("UpdatePersonDuzenledigimSeminer")]
        //public IActionResult UpdatePersonDuzenledigimSeminer(int duzenledigimSeminerId, long personId, string? baslik, string? yonetici, string? gorevliOgretimElemanlar, DateTime? Tarih, int? kisi)
        //{
        //    var duzenledigimEgitimSeminer = _duzenledigimEgitimSeminerService.GetDuzenledigimEgitimSeminerById(duzenledigimSeminerId);
        //    if (baslik == null)
        //    {
        //        return BadRequest("Lütfen Eğitim Seminerinin Başlığını Giriniz");
        //    }
        //    if (yonetici == null)
        //    {
        //        return BadRequest("Lütfen Eğitim Seminerinin Yöneticisini Giriniz");
        //    }
        //    if (gorevliOgretimElemanlar == null)
        //    {
        //        return BadRequest("Lütfen Görev Alan Öğretim Elemanlarını Giriniz");
        //    }
        //    if (Tarih == null)
        //    {
        //        return BadRequest("Lütfen Eğitim Seminerinin Tarihini Giriniz");
        //    }
        //    if (kisi == null)
        //    {
        //        return BadRequest("Lütfen Eğitim Seminerine Katılan Kişi Sayısını Giriniz");
        //    }
        //    duzenledigimEgitimSeminer.PersonId = personId;
        //    duzenledigimEgitimSeminer.Baslik = baslik;
        //    duzenledigimEgitimSeminer.Yonetici = yonetici;
        //    duzenledigimEgitimSeminer.GorevAlanOgretimElemanlari = gorevliOgretimElemanlar;
        //    duzenledigimEgitimSeminer.Tarih = Tarih;
        //    duzenledigimEgitimSeminer.KatilanKisiSayisi = kisi;
        //    _duzenledigimEgitimSeminerService.Update(duzenledigimEgitimSeminer);

        //    return Ok("Güncelleme İşlemi Başarıyla Gerçekleşti");
        //}
        //#endregion

        //#region Hakemliklerim
        //[HttpGet]
        //[Route("GetAllHakemliklerimByPersonId")]
        //public IActionResult GetAllHakemliklerimByPersonId(long personId, bool status)
        //{
        //    var hakemliklerim = _hakemliklerimService.GetAllHakemliklerimByPersonId(personId, status);
        //    return Ok(hakemliklerim);
        //}

        //[HttpGet]
        //[Route("GetAllHakemliklOnayiBekleyenlerByPersonId")]
        //public IActionResult GetAllHakemliklOnayiBekleyenlerByPersonId(long personId)
        //{
        //    var hakemlikOnayiBekleyenler = _hakemlikOnayiBekleyenlerService.GetAllHakemlikOnayiBekleyenlerByPersonId(personId);
        //    return Ok(hakemlikOnayiBekleyenler);
        //}

        //[HttpGet]
        //[Route("GetAllHakemlikProjeListesiByPersonId")]
        //public IActionResult GetAllHakemlikProjeListesiByPersonId(long personId)
        //{
        //    var hakemlikProjeListesi = _hakemlikProjeListesiService.GetAllHakemlikProjeListesiByPersonId(personId);
        //    return Ok(hakemlikProjeListesi);
        //}

        //[HttpGet]
        //[Route("GetMarkByMarkId")]
        //public IActionResult GetMarkByMarkId(int markId)
        //{
        //    var mark = _hakemliklerimService.GetMarkById(markId);
        //    return Ok(mark);
        //}

        //#endregion

        /////////////////////////////////////////////////

        //[HttpGet]
        //[Route("GetPersonByIdIncludeRelatedDatas")]
        //public IActionResult GetPersonByIdIncludeRelatedDatas(long personId)
        //{
        //    var person = _personService.GetPersonByIdIncludeRelatedDatas(personId);
        //    return Ok(person);
        //}


        //[HttpGet]
        //[Route("GetAllCommmissioner")]
        //public IActionResult GetAllCommmissioner()
        //{
        //    var commissioners = _personService.GetAllCommissioner();
        //    return Ok(commissioners);
        //}

        //[HttpGet]
        //[Route("HakemleriBirimeGoreListele")]
        //public IActionResult HakemleriBirimeGoreListele(int birim)
        //{
        //    var hakemler = _personService.TumHakemleriListeleme(birim);
        //    return Ok(hakemler);
        //}


        //[HttpGet]
        //[Route("HakemleriAdinaGoreListele")]
        //public IActionResult HakemleriAdinaGoreListele(string isim)
        //{
        //    var buyukIsım = isim.ToUpper(new CultureInfo("tr-TR", true)).ToString();
        //    var hakemler = _personService.HakemAdinaGoreListeleme(buyukIsım);

        //    return Ok(hakemler);
        //}

        //[HttpGet]
        //[Route("HakemleriSoyadinaGoreListele")]
        //public IActionResult HakemleriSoyadinaGoreListele(string soyisim)
        //{
        //    var buyukIsım = soyisim.ToUpper(new CultureInfo("tr-TR", true)).ToString();
        //    var hakemler = _personService.HakemSoyadinaGoreListeleme(buyukIsım);

        //    return Ok(hakemler);
        //}

        //[HttpGet]
        //[Route("HakemleriKeywordeGoreListele")]
        //public IActionResult HakemleriKeywordeGoreListele(string keyword)
        //{

        //    var hakemler = _personService.KeywordeGoreHakemListeleme(keyword);

        //    return Ok(hakemler);
        //}


        //[HttpGet]
        //[Route("CorpnodeGoreKisileriListele")]
        //public IActionResult CorpnodeGoreKisileriListele(int missionCorpnodeId)
        //{

        //    var person = _personService.GetAllPersonByCorpnodeId(missionCorpnodeId);

        //    return Ok(person);
        //}
        //[HttpGet]
        //[Route("GetPersonByProjectId")]
        //public IActionResult GetPersonByProjectId(long projectId)
        //{
        //    var person = _personService.PersonByProjectId(projectId);
        //    return Ok(person);
        //}


        //[HttpPost]
        //[Route("ChangePassword")]
        //public IActionResult ChangePassword(long personId, string? oldsifre, string? newsifre, string? newsifreagain)
        //{
        //    if (oldsifre == null || oldsifre == "")
        //    {
        //        return BadRequest("Lütfen eski şifrenizi giriniz.");
        //    }
        //    if (oldsifre.Length > 150)
        //    {
        //        return BadRequest("Eski şifreniz 150 karakterden uzun olamaz.");
        //    }
        //    if (newsifre == null || newsifre == "")
        //    {
        //        return BadRequest("Lütfen yeni şifrenizi giriniz.");
        //    }
        //    if (newsifre.Length > 150)
        //    {
        //        return BadRequest("Yeni şifreniz 150 karakterden uzun olamaz.");
        //    }
        //    if (newsifreagain == null || newsifreagain == "")
        //    {
        //        return BadRequest("Lütfen yeni şifrenizi tekrar giriniz.");
        //    }
        //    if (newsifreagain.Length > 150)
        //    {
        //        return BadRequest("Tekrar girilen yeni şifreniz 150 karakterden uzun olamaz.");
        //    }
        //    var login = _loginService.GetLoginUserByPersonIdAndPassword(personId, oldsifre);
        //    if (login == null)
        //    {
        //        return BadRequest("Parolanızı hatalı girdiniz");
        //    }
        //    if (login.Password == newsifre)
        //    {
        //        return BadRequest("Yeni parolanız eski paola ile aynı olamaz.");
        //    }
        //    if (newsifre != newsifreagain)
        //    {
        //        return BadRequest("Yeni parolanız ve yeni parola tekrarı aynı olmalıdır.");
        //    }
        //    login.Password = newsifre;
        //    login.LastChange = DateTime.Now;
        //    _loginService.Update(login);

        //    return Ok("Şifreniz başarı ile değiştirilmiştir.");
        //}

        //[HttpGet]
        //[Route("GetAllMonth")]
        //public IActionResult GetAllMonth()
        //{
        //    var aylar = _ayService.GetAllMonth();
        //    return Ok(aylar);
        //}

    }
}
