using Dodayi.Services.BapAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Dodayi.Services.BapAPI.Data
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {
        }


        public virtual DbSet<ArbisKeyword> ArbisKeywords { get; set; } = null!;
        public virtual DbSet<Detail> Details { get; set; } = null!;

        //
        //public virtual DbSet<Person> People { get; set; } = null!;
        //public virtual DbSet<Corpnode> Corpnodes { get; set; } = null!;
        //public virtual DbSet<Nodeuser> Nodeusers { get; set; } = null!;

        //






        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        IConfigurationRoot configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())  // Yapılandırma dosyasının bulunduğu dizini belirtir
        //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)  // appsettings.json dosyasını yükler
        //        .Build();

        //        string connectionString = configuration.GetConnectionString("BapConnection");

        //        optionsBuilder.UseSqlServer(connectionString);
        //        //optionsBuilder.UseOracle("User Id=bounbap;Password=bounbap;Data Source=161.9.151.189:1521/pdbmfdb.localdomain;");
        //    }
        //}



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BOUNBAP");


            modelBuilder.Entity<ArbisKeyword>(entity =>
            {
                entity.ToTable("ARBIS_KEYWORDS", "BOUNBAP");

                entity.HasKey(e => e.Id)
                      .HasName("PK_ARBIS_KEYWORDS");

                entity.Property(e => e.Id)
                      .HasColumnName("ID")
                      .HasColumnType("int")
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Turkish)
                      .HasColumnName("TURKISH")
                      .HasColumnType("varchar(500)")
                      .HasMaxLength(500)
                      .IsUnicode(false); // Unicode değil, varchar

                entity.Property(e => e.English)
                      .HasColumnName("ENGLISH")
                      .HasColumnType("varchar(500)")
                      .HasMaxLength(500)
                      .IsUnicode(false);

                entity.Property(e => e.ArbisId)
                      .HasColumnName("ARBIS_ID")
                      .HasColumnType("int");

                entity.Property(e => e.TempId)
                      .HasColumnName("TEMPID")
                      .HasColumnType("int");

                entity.Property(e => e.ParentId)
                      .HasColumnName("PARENT_ID")
                      .HasColumnType("int");
            });

            modelBuilder.Entity<Detail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("DETAILS_PK");

                entity.ToTable("DETAILS", "BOUNBAP");

                entity.Property(e => e.Id)
                      .HasColumnName("ID")
                       .HasColumnType("bigint");
                //.UseIdentityColumn(); // IDENTITY özelliği için


                // Diğer alanlar
                entity.Property(e => e.Code)
                      .HasColumnName("CODE")
                      .HasColumnType("int");

                entity.Property(e => e.ProjectId)
                      .HasColumnName("PROJECT_ID")
                      .HasColumnType("bigint");

                entity.Property(e => e.Name)
                      .HasMaxLength(4000)
                      .IsUnicode(false)
                      .HasColumnName("NAME");

                entity.Property(e => e.Unit)
                      .HasColumnName("UNIT")
                      .HasColumnType("numeric(13, 2)");

                entity.Property(e => e.Count)
                      .HasColumnName("COUNT")
                      .HasColumnType("int");

                entity.Property(e => e.KdvPrice)
                      .HasColumnName("KDV_PRICE")
                      .HasColumnType("numeric(13, 2)");

                entity.Property(e => e.Type)
                      .HasMaxLength(100)
                      .IsUnicode(false)
                      .HasColumnName("TYPE");

                entity.Property(e => e.Year)
                      .HasColumnName("YEAR")
                      .HasColumnType("int");

                entity.Property(e => e.Sum)
                      .HasColumnName("SUM")
                      .HasColumnType("numeric(13, 2)");

                entity.Property(e => e.Alindi)
                      .HasColumnName("ALINDI")
                      .HasColumnType("numeric(38, 0)");

                entity.Property(e => e.IsNew)
                      .HasColumnName("ISNEW")
                      .HasColumnType("bit");

                entity.Property(e => e.Text)
                      .HasColumnName("TEXT")
                      .HasColumnType("varchar(max)");

                entity.Property(e => e.Kalan)
                      .HasColumnName("KALAN")
                      .HasColumnType("numeric(38, 0)");

                entity.Property(e => e.NewRow)
                      .HasColumnName("NEWROW")
                      .HasColumnType("bit")
                      .HasDefaultValue(false);

                entity.Property(e => e.Status)
                      .HasColumnName("STATUS")
                      .HasColumnType("bit")
                      .HasDefaultValue(false);

                entity.Property(e => e.Why)
                      .HasColumnName("WHY")
                      .HasColumnType("varchar(max)");

                entity.Property(e => e.TtsGrupAd)
                      .HasMaxLength(120)
                      .IsUnicode(false)
                      .HasColumnName("TTS_GRUP_AD");

                entity.Property(e => e.TtsHesapPlanId)
                      .HasColumnName("TTS_HESAP_PLAN_ID")
                      .HasColumnType("int");

                entity.Property(e => e.TtsHesapPlanKod)
                      .HasMaxLength(20)
                      .IsUnicode(false)
                      .HasColumnName("TTS_HESAP_PLAN_KOD");

                entity.Property(e => e.TtsHesapPlanGelirKod)
                      .HasMaxLength(40)
                      .IsUnicode(false)
                      .HasColumnName("TTS_HESAP_PLAN_GELIR_KOD");

                entity.Property(e => e.TtsHesapPlanGelirId)
                      .HasColumnName("TTS_HESAP_PLAN_GELIR_ID")
                      .HasColumnType("int");

                entity.Property(e => e.ProformoId)
                      .HasColumnName("PROFORMO_ID")
                      .HasColumnType("int");

                entity.Property(e => e.UnitUsd)
                      .HasColumnName("UNITUSD")
                      .HasColumnType("numeric(10, 2)");

                entity.Property(e => e.TechnicalPros)
                      .HasColumnName("TECHNICAL_PROS")
                      .HasColumnType("varchar(max)");

                entity.Property(e => e.Work)
                      .HasMaxLength(200)
                      .IsUnicode(false)
                      .HasColumnName("WORK");

                entity.Property(e => e.YurticiYerler)
                      .HasMaxLength(2000)
                      .IsUnicode(false)
                      .HasColumnName("YURTICI_YERLER");

                entity.Property(e => e.YurtdisiYerler)
                      .HasMaxLength(2000)
                      .IsUnicode(false)
                      .HasColumnName("YURTDISI_YERLER");

                entity.Property(e => e.Oid)
                      .HasMaxLength(20)
                      .IsUnicode(false)
                      .HasColumnName("OID");

                entity.Property(e => e.FromCommission)
                      .HasColumnName("FROM_COMMISSION")
                      .HasColumnType("numeric(2, 0)");

                entity.Property(e => e.TtsHesapPlanAciklama)
                      .HasMaxLength(300)
                      .IsUnicode(false)
                      .HasColumnName("TTS_HESAP_PLAN_ACIKLAMA");

                entity.Property(e => e.ButceFisiKesildi)
                      .HasColumnName("BUTCE_FISI_KESILDI")
                      .HasColumnType("bit");

                entity.Property(e => e.Version)
                      .HasColumnName("VERSION")
                      .HasColumnType("int")
                      .HasDefaultValue(1);

                entity.Property(e => e.TtsFonksiyonelSinifId)
                      .HasColumnName("TTS_FONKSIYONEL_SINIF_ID")
                      .HasColumnType("int");

                entity.Property(e => e.HizmetTanimi)
                      .HasMaxLength(500)
                      .IsUnicode(false)
                      .HasColumnName("HIZMET_TANIMI");

                entity.Property(e => e.Unused)
                      .HasColumnName("UNUSED")
                      .HasColumnType("bit")
                      .HasDefaultValue(false);

                entity.Property(e => e.ReferenceId)
                      .HasColumnName("REFERENCE_ID")
                      .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.MisafirFormuId)
                      .HasColumnName("MISAFIR_FORMU_ID")
                      .HasColumnType("int");

                entity.Property(e => e.AraziFormuId)
                      .HasColumnName("ARAZI_FORMU_ID")
                      .HasColumnType("int");

                entity.Property(e => e.EgitimTipi)
                      .HasColumnName("EGITIM_TIPI")
                      .HasColumnType("int");

                entity.Property(e => e.ArastirmaciPersonelAd)
                      .HasMaxLength(1000)
                      .IsUnicode(false)
                      .HasColumnName("ARASTIRMACI_PERSONEL_AD");

                entity.Property(e => e.MalzemeDegisikligi)
                      .HasColumnName("MALZEME_DEGISIKLIGI")
                      .HasColumnType("int");

                entity.Property(e => e.MalzemeDegisiklikId)
                      .HasColumnName("MALZEME_DEGISIKLIK_ID")
                      .HasColumnType("int");

                entity.Property(e => e.MalzemeDegistirmeDurum)
                      .HasColumnName("MALZEME_DEGISTIRME_DURUM")
                      .HasColumnType("int");

                entity.Property(e => e.DegisiklikTalebiId)
                      .HasColumnName("DEGISIKLIK_TALEBI_ID")
                      .HasColumnType("int");

                entity.Property(e => e.Amac)
                      .HasMaxLength(4000)
                      .IsUnicode(false)
                      .HasColumnName("AMAC");

                entity.Property(e => e.Yetkinlik)
                      .HasMaxLength(4000)
                      .IsUnicode(false)
                      .HasColumnName("YETKINLIK");

                entity.Property(e => e.Kurum)
                      .HasMaxLength(1000)
                      .IsUnicode(false)
                      .HasColumnName("KURUM");

                entity.Property(e => e.Gereklilik)
                      .HasMaxLength(4000)
                      .IsUnicode(false)
                      .HasColumnName("GEREKLILIK");

                entity.Property(e => e.Sehir)
                      .HasMaxLength(400)
                      .IsUnicode(false)
                      .HasColumnName("SEHIR");

                entity.Property(e => e.DonusTarihi)
                      .HasColumnName("DONUS_TARIHI")
                      .HasColumnType("datetime2(0)");

                entity.Property(e => e.Nitelik)
                      .HasMaxLength(4000)
                      .IsUnicode(false)
                      .HasColumnName("NITELIK");

                entity.Property(e => e.Izin)
                      .HasColumnName("IZIN")
                      .HasColumnType("bit");

                entity.Property(e => e.GidisTarihi)
                      .HasColumnName("GIDIS_TARIHI")
                      .HasColumnType("datetime2(0)");

                entity.Property(e => e.UlkeId)
                      .HasColumnName("ULKE_ID")
                      .HasColumnType("int");

                entity.Property(e => e.SehirId)
                      .HasColumnName("SEHIR_ID")
                      .HasColumnType("int");

                entity.Property(e => e.Katki)
                      .HasMaxLength(4000)
                      .IsUnicode(false)
                      .HasColumnName("KATKI");

                entity.Property(e => e.KisiBilgi)
                      .HasMaxLength(1000)
                      .IsUnicode(false)
                      .HasColumnName("KISI_BILGI");

                entity.Property(e => e.GundelikBedeli)
                      .HasColumnName("GUNDELIK_BEDELI")
                      .HasColumnType("numeric(13, 3)");

                entity.Property(e => e.KonaklamaBedeli)
                      .HasColumnName("KONAKLAMA_BEDELI")
                      .HasColumnType("numeric(13, 3)");

                entity.Property(e => e.UlasimBedeli)
                      .HasColumnName("ULASIM_BEDELI")
                      .HasColumnType("numeric(13, 3)");

                entity.Property(e => e.PersonelTuru)
                      .HasColumnName("PERSONEL_TURU")
                      .HasColumnType("int");

                entity.Property(e => e.AylikOdenecekBurs)
                      .HasColumnName("AYLIK_ODENECEK_BURS")
                      .HasColumnType("numeric(13, 0)");

                entity.Property(e => e.BpTcKimlikNo)
                      .HasMaxLength(20)
                      .IsUnicode(false)
                      .HasColumnName("B_P_TC_KIMLIK_NO");

                entity.Property(e => e.BpEposta)
                      .HasMaxLength(4000)
                      .IsUnicode(false)
                      .HasColumnName("B_P_EPOSTA");

                entity.Property(e => e.BpGsm)
                      .HasMaxLength(4000)
                      .IsUnicode(false)
                      .HasColumnName("B_P_GSM");

                entity.Property(e => e.BpIsevTel)
                      .HasMaxLength(4000)
                      .IsUnicode(false)
                      .HasColumnName("B_P_ISEV_TEL");

                entity.Property(e => e.BpBursBasTar)
                      .HasColumnName("B_P_BURS_BAS_TAR")
                      .HasColumnType("datetime2(0)");

                entity.Property(e => e.BpBursBitTar)
                      .HasColumnName("B_P_BURS_BIT_TAR")
                      .HasColumnType("datetime2(0)");

                entity.Property(e => e.BpAdres)
                      .HasMaxLength(4000)
                      .IsUnicode(false)
                      .HasColumnName("B_P_ADRES");

                entity.Property(e => e.BpBankaAdi)
                      .HasMaxLength(50)
                      .IsUnicode(false)
                      .HasColumnName("B_P_BANKA_ADI");

                entity.Property(e => e.BpSubeAdi)
                      .HasMaxLength(75)
                      .IsUnicode(false)
                      .HasColumnName("B_P_SUBE_ADI");

                entity.Property(e => e.BpIbanNo)
                      .HasMaxLength(50)
                      .IsUnicode(false)
                      .HasColumnName("B_P_IBAN_NO");

                entity.Property(e => e.BpGss)
                      .HasColumnName("B_P_GSS")
                      .HasColumnType("int");

                entity.Property(e => e.ArastirmaciPersonelSoyad)
                      .HasMaxLength(4000)
                      .IsUnicode(false)
                      .HasColumnName("ARASTIRMACI_PERSONEL_SOYAD");

                entity.Property(e => e.EgitimTipiB)
                      .HasColumnName("EGITIM_TIPI_B")
                      .HasColumnType("int");

                entity.Property(e => e.PiyasaTuru)
                      .HasColumnName("PIYASA_TURU")
                      .HasColumnType("int");

                entity.Property(e => e.YurtdisiGerekce)
                      .HasMaxLength(4000)
                      .IsUnicode(false)
                      .HasColumnName("YURTDISI_GEREKCE");

                entity.Property(e => e.Distributor)
                      .HasColumnName("DISTRIBUTOR")
                      .HasColumnType("int");

                entity.Property(e => e.BursiyerIstifa)
                      .HasColumnName("BURSIYER_ISTIFA")
                      .HasColumnType("int");
            });


            // Person Servise yapa biliriz
            //modelBuilder.Entity<Person>(entity =>
            //{
            //    entity.ToTable("PERSON", "BOUNBAP");

            //    entity.HasKey(e => e.Id)
            //          .HasName("PERSON_PK");

            //    entity.Property(e => e.Id)
            //          .HasColumnName("ID")
            //          .HasColumnType("bigint");

            //    entity.Property(e => e.Name)
            //          .HasColumnName("NAME")
            //          .HasMaxLength(50)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.Surname)
            //          .HasColumnName("SURNAME")
            //          .HasMaxLength(50)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.Role)
            //          .HasColumnName("ROLE")
            //          .HasColumnType("int");

            //    entity.Property(e => e.Adress)
            //          .HasColumnName("ADRESS")
            //          .HasMaxLength(4000)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.Fax)
            //          .HasColumnName("FAX")
            //          .HasMaxLength(4000)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.WorkPhone)
            //          .HasColumnName("WORK_PHONE")
            //          .HasMaxLength(20)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.AcademicTitle)
            //          .HasColumnName("ACADEMIC_TITLE")
            //          .HasMaxLength(50)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.HomePhone)
            //          .HasColumnName("HOME_PHONE")
            //          .HasMaxLength(20)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.Gsm)
            //          .HasColumnName("GSM")
            //          .HasMaxLength(20)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.Email)
            //          .HasColumnName("EMAIL")
            //          .HasMaxLength(4000)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.TcIdentityNumber)
            //          .HasColumnName("TC_IDENTITY_NUMBER")
            //          .HasMaxLength(50)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.Birthday)
            //          .HasColumnName("BIRTHDAY")
            //          .HasColumnType("datetime2");

            //    entity.Property(e => e.BirthdayCity)
            //          .HasColumnName("BIRTHDAY_CITY")
            //          .HasMaxLength(100)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.Nationality)
            //          .HasColumnName("NATIONALITY")
            //          .HasColumnType("numeric(10, 0)");

            //    entity.Property(e => e.Foreign)
            //          .HasColumnName("FOREIGN")
            //          .HasColumnType("numeric(38, 0)");

            //    entity.Property(e => e.CvId)
            //          .HasColumnName("CV_ID")
            //          .HasColumnType("numeric(10, 0)");

            //    entity.Property(e => e.Email1)
            //          .HasColumnName("EMAIL1")
            //          .HasMaxLength(150)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.NodeId)
            //          .HasColumnName("NODE_ID")
            //          .HasColumnType("numeric(10, 0)");

            //    entity.Property(e => e.SicilNo)
            //          .HasColumnName("SICIL_NO")
            //          .HasMaxLength(15)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.WorkDahili)
            //          .HasColumnName("WORK_DAHILI")
            //          .HasMaxLength(5)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.NotId)
            //          .HasColumnName("NOT_ID")
            //          .HasColumnType("numeric(10, 0)");

            //    entity.Property(e => e.Retired)
            //          .HasColumnName("RETIRED")
            //          .HasColumnType("bit")
            //          .HasDefaultValue(false);

            //    entity.Property(e => e.FakulteId)
            //          .HasColumnName("FAKULTE_ID")
            //          .HasColumnType("numeric(10, 0)");

            //    entity.Property(e => e.CommSort)
            //          .HasColumnName("COMM_SORT")
            //          .HasColumnType("float");

            //    entity.Property(e => e.WorkPhone2)
            //          .HasColumnName("WORK_PHONE2")
            //          .HasMaxLength(20)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.WorkDahili2)
            //          .HasColumnName("WORK_DAHILI2")
            //          .HasMaxLength(20)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.MissionNodeId)
            //          .HasColumnName("MISSION_NODE_ID")
            //          .HasColumnType("numeric(10, 0)");

            //    entity.Property(e => e.MissionFakulteId)
            //          .HasColumnName("MISSION_FAKULTE_ID")
            //          .HasColumnType("numeric(10, 0)");

            //    entity.Property(e => e.SicilNoYeni)
            //          .HasColumnName("SICIL_NO_YENI")
            //          .HasMaxLength(15)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.ServisHata)
            //          .HasColumnName("SERVIS_HATA")
            //          .HasColumnType("bit")
            //          .HasDefaultValue(false);

            //    entity.Property(e => e.EskiPerson)
            //          .HasColumnName("ESKI_PERSON")
            //          .HasColumnType("bit")
            //          .HasDefaultValue(false);

            //    entity.Property(e => e.IsRefreeAssign)
            //          .HasColumnName("IS_REFREE_ASSIGN")
            //          .HasColumnType("bit")
            //          .HasDefaultValue(false);

            //    entity.Property(e => e.EskiPersonId)
            //          .HasColumnName("ESKI_PERSON_ID")
            //          .HasColumnType("numeric(10, 0)");

            //    entity.Property(e => e.DefaultIfRumuzId)
            //          .HasColumnName("DEFAULT_IF_RUMUZ_ID")
            //          .HasColumnType("numeric(10, 0)");

            //    entity.Property(e => e.TempId)
            //          .HasColumnName("TEMP_ID")
            //          .HasColumnType("numeric(10, 0)");

            //    entity.Property(e => e.PostDoc)
            //          .HasColumnName("POST_DOC")
            //          .HasColumnType("bit")
            //          .HasDefaultValue(false);

            //    entity.Property(e => e.SskNo)
            //          .HasColumnName("SSK_NO")
            //          .HasMaxLength(20)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.Status)
            //          .HasColumnName("STATUS")
            //          .HasColumnType("numeric(10, 0)");

            //    entity.Property(e => e.IbanNo)
            //          .HasColumnName("IBAN_NO")
            //          .HasMaxLength(50)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.UnvanTarihi)
            //          .HasColumnName("UNVAN_TARIHI")
            //          .HasColumnType("datetime2");

            //    entity.Property(e => e.UnvandaFiilenBaslamaTarihi)
            //          .HasColumnName("UNVANDA_FIILEN_BASLAMA_TARIHI")
            //          .HasColumnType("datetime2");

            //    entity.Property(e => e.UnvandaKararnameTarihi)
            //          .HasColumnName("UNVANDA_KARARNAME_TARIHI")
            //          .HasColumnType("datetime2");

            //    entity.Property(e => e.YoksisOnay)
            //          .HasColumnName("YOKSIS_ONAY")
            //          .HasColumnType("float");

            //    entity.Property(e => e.Sube)
            //          .HasColumnName("SUBE")
            //          .HasMaxLength(4000)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.HesapNumarasi)
            //          .HasColumnName("HESAP_NUMARASI")
            //          .HasMaxLength(4000)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.YoksisEkipId)
            //          .HasColumnName("YOKSIS_EKIP_ID")
            //          .HasColumnType("int");

            //    entity.Property(e => e.OrcidId)
            //          .HasColumnName("ORCID_ID")
            //          .HasMaxLength(50)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.Property(e => e.ResearcherId)
            //          .HasColumnName("RESEARCHER_ID")
            //          .HasMaxLength(50)
            //          .HasColumnType("varchar")
            //          .IsUnicode(false);

            //    entity.HasOne(d => d.Fakulte)
            //              .WithMany()
            //              .HasForeignKey(d => d.FakulteId)
            //              .HasPrincipalKey(d => d.Id);
            //    entity.HasOne(d => d.MissionCorpnode)
            //              .WithMany()
            //              .HasForeignKey(d => d.MissionNodeId)
            //              .HasPrincipalKey(d => d.Id);
            //    entity.HasOne(d => d.MissionFakulteNode)
            //              .WithMany()
            //              .HasForeignKey(d => d.MissionFakulteId)
            //              .HasPrincipalKey(d => d.Id);
            //    entity.HasOne(d => d.Corpnode)
            //              .WithMany()
            //              .HasForeignKey(d => d.NodeId)
            //              .HasPrincipalKey(d => d.Id);

            //    entity.HasMany(x => x.Keyword);
            //});

            //modelBuilder.Entity<Corpnode>(entity =>
            //{
            //    entity.ToTable("CORPNODE", "BOUNBAP");

            //    entity.HasKey(e => e.Id)
            //          .HasName("SYS_C0012784"); // PRIMARY KEY

            //    // IDENTITY column
            //    entity.Property(e => e.Id)
            //          .HasColumnName("ID")
            //          .ValueGeneratedOnAdd() // Otomatik artan
            //          .HasColumnType("int");

            //    // String columns
            //    entity.Property(e => e.Name)
            //          .HasColumnName("NAME")
            //          .HasMaxLength(255) // varchar(255)
            //          .IsRequired()
            //          .IsUnicode(false); // Unicode kapalı

            //    entity.Property(e => e.BounKod)
            //          .HasColumnName("BOUN_KOD")
            //          .HasMaxLength(20) // varchar(20)
            //          .IsUnicode(false);

            //    entity.Property(e => e.YukseltmeKriteri)
            //          .HasColumnName("YUKSELTME_KRITERI")
            //          .HasMaxLength(500) // varchar(500)
            //          .IsUnicode(false);

            //    // int columns
            //    entity.Property(e => e.ParentId)
            //          .HasColumnName("PARENT_ID")
            //          .HasColumnType("int")
            //          .IsRequired();

            //    entity.Property(e => e.Nodetypeid)
            //          .HasColumnName("NODETYPEID")
            //          .HasColumnType("int");

            //    entity.Property(e => e.UstId)
            //          .HasColumnName("UST_ID")
            //          .HasColumnType("int");

            //    entity.Property(e => e.DoktoraProgrami)
            //          .HasColumnName("DOKTORA_PROGRAMI")
            //          .HasColumnType("int");

            //    entity.Property(e => e.YeniId)
            //          .HasColumnName("YENI_ID")
            //          .HasColumnType("int");

            //    entity.Property(e => e.Enstitu)
            //          .HasColumnName("ENSTITU")
            //          .HasColumnType("int");

            //    // bit columns
            //    entity.Property(e => e.Temp)
            //          .HasColumnName("TEMP")
            //          .HasColumnType("bit");

            //    entity.Property(e => e.Tip)
            //          .HasColumnName("TIP")
            //          .HasColumnType("bit");

            //    entity.Property(e => e.Fen)
            //          .HasColumnName("FEN")
            //          .HasColumnType("bit")
            //          .HasDefaultValue(false); // Default: 0

            //    entity.Property(e => e.Sosyal)
            //          .HasColumnName("SOSYAL")
            //          .HasColumnType("bit")
            //          .HasDefaultValue(false); // Default: 0

            //    entity.Property(e => e.FenOther)
            //          .HasColumnName("FEN_OTHER")
            //          .HasColumnType("bit")
            //          .HasDefaultValue(false); // Default: 0

            //    entity.Property(e => e.SosyalOther)
            //          .HasColumnName("SOSYAL_OTHER")
            //          .HasColumnType("bit")
            //          .HasDefaultValue(false); // Default: 0

            //    entity.Property(e => e.TemelBilimler)
            //          .HasColumnName("TEMEL_BILIMLER")
            //          .HasColumnType("bit")
            //          .HasDefaultValue(false); // Default: 0

            //    entity.Property(e => e.TeknikBilimler)
            //          .HasColumnName("TEKNIK_BILIMLER")
            //          .HasColumnType("bit")
            //          .HasDefaultValue(false); // Default: 0

            //    entity.Property(e => e.OncelikliAlan)
            //          .HasColumnName("ONCELIKLI_ALAN")
            //          .HasColumnType("bit")
            //          .HasDefaultValue(false); // Default: 0

            //    // Number column
            //    entity.Property(e => e.Kod)
            //          .HasColumnName("KOD")
            //          .HasColumnType("int");

            //    // Relationships
            //    entity.HasOne(d => d.Nodetype)
            //        .WithMany(p => (IEnumerable<Corpnode>)p.Corpnodes)
            //        .HasForeignKey(d => d.Nodetypeid)
            //        .HasConstraintName("FK_CORPNODE_311");


            //    entity.HasOne(d => d.Parent)
            //     .WithMany()
            //     .HasForeignKey(d => d.ParentId)
            //     .HasPrincipalKey(d => d.Id);


            //    //entity.HasOne(d => d.Parent)
            //    //      .WithMany(p => p.Children)
            //    //      .HasForeignKey(d => d.ParentId)
            //    //      .OnDelete(DeleteBehavior.Restrict) // Parent silinirse, child etkilenmez
            //    //      .HasConstraintName("FK_CORPNODE_PARENT");
            //});

            //modelBuilder.Entity<Nodeuser>(entity =>
            //{
            //    entity.ToTable("NODEUSER", "BOUNBAP");

            //    entity.HasKey(e => e.Id).HasName("SYS_C0012983");

            //    entity.Property(e => e.Id)
            //          .HasColumnName("ID")
            //          .HasColumnType("int");

            //    entity.Property(e => e.Userid)
            //          .HasColumnName("USERID")
            //          .HasColumnType("int")
            //          .IsRequired();

            //    entity.Property(e => e.Corpnodeid)
            //          .HasColumnName("CORPNODEID")
            //          .HasColumnType("int");

            //    // Foreign Key to CorpNode
            //    entity.HasOne(e => e.Corpnodes)
            //          .WithMany()
            //          .HasForeignKey(e => e.Corpnodeid)
            //          .HasConstraintName("FK_NODEUSER_CORPNODE");

            //    // Foreign Key to User (if applicable)
            //    // Uncomment and modify if USER table exists and USERID is a foreign key
            //    // entity.HasOne(e => e.User)
            //    //       .WithMany()
            //    //       .HasForeignKey(e => e.UserId)
            //    //       .HasConstraintName("FK_NODEUSER_USER");
            //});









            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
