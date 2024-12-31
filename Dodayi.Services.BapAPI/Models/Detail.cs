namespace Dodayi.Services.BapAPI.Models
{
    public partial class Detail
    {
        public long Id { get; set; }
        public int? Code { get; set; }
        public long? ProjectId { get; set; }
        public string? Name { get; set; }
        public decimal? Unit { get; set; }
        public int? Count { get; set; }
        public decimal? KdvPrice { get; set; }
        public string? Type { get; set; }
        public int? Year { get; set; }
        public decimal? Sum { get; set; }
        public decimal? Alindi { get; set; }
        public bool? IsNew { get; set; }
        public string? Text { get; set; }
        public decimal? Kalan { get; set; }
        public bool? NewRow { get; set; } = false;
        public bool? Status { get; set; } = false;
        public string? Why { get; set; }
        public string? TtsGrupAd { get; set; }
        public int? TtsHesapPlanId { get; set; }
        public string? TtsHesapPlanKod { get; set; }
        public string? TtsHesapPlanGelirKod { get; set; }
        public int? TtsHesapPlanGelirId { get; set; }
        public int? ProformoId { get; set; }
        public decimal? UnitUsd { get; set; }
        public string? TechnicalPros { get; set; }
        public string? Work { get; set; }
        public string? YurticiYerler { get; set; }
        public string? YurtdisiYerler { get; set; }
        public string? Oid { get; set; }
        public decimal? FromCommission { get; set; }
        public string? TtsHesapPlanAciklama { get; set; }
        public bool? ButceFisiKesildi { get; set; }
        public int? Version { get; set; }
        public int? TtsFonksiyonelSinifId { get; set; }
        public string? HizmetTanimi { get; set; }
        public bool? Unused { get; set; } = false;
        public decimal? ReferenceId { get; set; }
        public int? MisafirFormuId { get; set; }
        public int? AraziFormuId { get; set; }
        public int? EgitimTipi { get; set; }
        public string? ArastirmaciPersonelAd { get; set; }
        public int? MalzemeDegisikligi { get; set; }
        public int? MalzemeDegisiklikId { get; set; }
        public int? MalzemeDegistirmeDurum { get; set; }
        public int? DegisiklikTalebiId { get; set; }
        public string? Amac { get; set; }
        public string? Yetkinlik { get; set; }
        public string? Kurum { get; set; }
        public string? Gereklilik { get; set; }
        public string? Sehir { get; set; }
        public DateTime? DonusTarihi { get; set; }
        public string? Nitelik { get; set; }
        public bool? Izin { get; set; }
        public DateTime? GidisTarihi { get; set; }
        public int? UlkeId { get; set; }
        public int? SehirId { get; set; }
        public string? Katki { get; set; }
        public string? KisiBilgi { get; set; }
        public decimal? GundelikBedeli { get; set; }
        public decimal? KonaklamaBedeli { get; set; }
        public decimal? UlasimBedeli { get; set; }
        public int? PersonelTuru { get; set; }
        public decimal? AylikOdenecekBurs { get; set; }
        public string? BpTcKimlikNo { get; set; }
        public string? BpEposta { get; set; }
        public string? BpGsm { get; set; }
        public string? BpIsevTel { get; set; }
        public DateTime? BpBursBasTar { get; set; }
        public DateTime? BpBursBitTar { get; set; }
        public string? BpAdres { get; set; }
        public string? BpBankaAdi { get; set; }
        public string? BpSubeAdi { get; set; }
        public string? BpIbanNo { get; set; }
        public int? BpGss { get; set; }
        public string? ArastirmaciPersonelSoyad { get; set; }
        public int? EgitimTipiB { get; set; }
        public int? PiyasaTuru { get; set; }
        public string? YurtdisiGerekce { get; set; }
        public int? Distributor { get; set; }
        public int? BursiyerIstifa { get; set; }
    }
}
