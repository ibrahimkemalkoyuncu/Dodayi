using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace Dodayi.Services.PersonAPI.Models
{
    public partial class Person
    {

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int? Role { get; set; }
        public string? Adress { get; set; }
        public string? Fax { get; set; }
        public string? WorkPhone { get; set; }
        public string? AcademicTitle { get; set; }
        public string? HomePhone { get; set; }
        public string? Gsm { get; set; }
        public string? Email { get; set; }
        public string? TcIdentityNumber { get; set; }
        public DateTime? Birthday { get; set; }
        public string? BirthdayCity { get; set; }
        public int? Nationality { get; set; }
        public decimal? Foreign { get; set; }
        public int? CvId { get; set; }
        public string? Email1 { get; set; }

        public int? NodeId { get; set; }
        public Corpnode? Corpnode { get; set; }

        public string? SicilNo { get; set; }
        public string? WorkDahili { get; set; }
        public int? NotId { get; set; }
        public bool? Retired { get; set; }
        public int? FakulteId { get; set; }
        public Corpnode? Fakulte { get; set; }
        public decimal? CommSort { get; set; }
        public string? WorkPhone2 { get; set; }
        public string? WorkDahili2 { get; set; }
        //
        public int? MissionNodeId { get; set; }
        public Corpnode? MissionCorpnode { get; set; }

        public int? MissionFakulteId { get; set; }
        public Corpnode? MissionFakulteNode { get; set; }
        //

        public string? SicilNoYeni { get; set; }
        public bool? ServisHata { get; set; }
        public bool? EskiPerson { get; set; }
        public bool? IsRefreeAssign { get; set; }
        public int? EskiPersonId { get; set; }
        public int? DefaultIfRumuzId { get; set; }
        public int? TempId { get; set; }
        public bool? PostDoc { get; set; }
        public string? SskNo { get; set; }
        public int? Status { get; set; }
        public string? IbanNo { get; set; }
        public DateTime? UnvanTarihi { get; set; }
        public DateTime? UnvandaFiilenBaslamaTarihi { get; set; }
        public DateTime? UnvandaKararnameTarihi { get; set; }
        public decimal? YoksisOnay { get; set; }
        public string? Sube { get; set; }
        public string? HesapNumarasi { get; set; }
        public decimal? YoksisEkipId { get; set; }
        public string? OrcidId { get; set; }
        public string? ResearcherId { get; set; }

        //public ICollection<Message>? Messages { get; set; }

        public ICollection<Keyword>? Keyword { get; set; }

        //status 0 = aktif
        //status 1 = emekli
        //status 2 = istifa
        //status 3 = disiplincezalı
    }
}
