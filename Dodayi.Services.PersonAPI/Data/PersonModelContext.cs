using Dodayi.Services.PersonAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Dodayi.Services.PersonAPI.Data
{
    public class PersonModelContext : DbContext
    {
        public PersonModelContext(DbContextOptions<PersonModelContext> options) : base(options)
        {
        }


        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Corpnode> Corpnodes { get; set; } = null!;
        public virtual DbSet<Nodeuser> Nodeusers { get; set; } = null!;
        public virtual DbSet<Keyword> Keywords { get; set; } = null!;
        public virtual DbSet<Nodetype> Nodetypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BOUNBAP");


            // Person Servise yapa biliriz
            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("PERSON", "BOUNBAP");

                entity.HasKey(e => e.Id)
                      .HasName("PERSON_PK");

                entity.Property(e => e.Id)
                      .HasColumnName("ID")
                      .HasColumnType("bigint");

                entity.Property(e => e.Name)
                      .HasColumnName("NAME")
                      .HasMaxLength(50)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.Surname)
                      .HasColumnName("SURNAME")
                      .HasMaxLength(50)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.Role)
                      .HasColumnName("ROLE")
                      .HasColumnType("int");

                entity.Property(e => e.Adress)
                      .HasColumnName("ADRESS")
                      .HasMaxLength(4000)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.Fax)
                      .HasColumnName("FAX")
                      .HasMaxLength(4000)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.WorkPhone)
                      .HasColumnName("WORK_PHONE")
                      .HasMaxLength(20)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.AcademicTitle)
                      .HasColumnName("ACADEMIC_TITLE")
                      .HasMaxLength(50)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.HomePhone)
                      .HasColumnName("HOME_PHONE")
                      .HasMaxLength(20)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.Gsm)
                      .HasColumnName("GSM")
                      .HasMaxLength(20)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.Email)
                      .HasColumnName("EMAIL")
                      .HasMaxLength(4000)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.TcIdentityNumber)
                      .HasColumnName("TC_IDENTITY_NUMBER")
                      .HasMaxLength(50)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.Birthday)
                      .HasColumnName("BIRTHDAY")
                      .HasColumnType("datetime2");

                entity.Property(e => e.BirthdayCity)
                      .HasColumnName("BIRTHDAY_CITY")
                      .HasMaxLength(100)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.Nationality)
                      .HasColumnName("NATIONALITY")
                      .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Foreign)
                      .HasColumnName("FOREIGN")
                      .HasColumnType("numeric(38, 0)");

                entity.Property(e => e.CvId)
                      .HasColumnName("CV_ID")
                      .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Email1)
                      .HasColumnName("EMAIL1")
                      .HasMaxLength(150)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.NodeId)
                      .HasColumnName("NODE_ID")
                      .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.SicilNo)
                      .HasColumnName("SICIL_NO")
                      .HasMaxLength(15)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.WorkDahili)
                      .HasColumnName("WORK_DAHILI")
                      .HasMaxLength(5)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.NotId)
                      .HasColumnName("NOT_ID")
                      .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.Retired)
                      .HasColumnName("RETIRED")
                      .HasColumnType("bit")
                      .HasDefaultValue(false);

                entity.Property(e => e.FakulteId)
                      .HasColumnName("FAKULTE_ID")
                      .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.CommSort)
                      .HasColumnName("COMM_SORT")
                      .HasColumnType("float");

                entity.Property(e => e.WorkPhone2)
                      .HasColumnName("WORK_PHONE2")
                      .HasMaxLength(20)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.WorkDahili2)
                      .HasColumnName("WORK_DAHILI2")
                      .HasMaxLength(20)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.MissionNodeId)
                      .HasColumnName("MISSION_NODE_ID")
                      .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.MissionFakulteId)
                      .HasColumnName("MISSION_FAKULTE_ID")
                      .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.SicilNoYeni)
                      .HasColumnName("SICIL_NO_YENI")
                      .HasMaxLength(15)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.ServisHata)
                      .HasColumnName("SERVIS_HATA")
                      .HasColumnType("bit")
                      .HasDefaultValue(false);

                entity.Property(e => e.EskiPerson)
                      .HasColumnName("ESKI_PERSON")
                      .HasColumnType("bit")
                      .HasDefaultValue(false);

                entity.Property(e => e.IsRefreeAssign)
                      .HasColumnName("IS_REFREE_ASSIGN")
                      .HasColumnType("bit")
                      .HasDefaultValue(false);

                entity.Property(e => e.EskiPersonId)
                      .HasColumnName("ESKI_PERSON_ID")
                      .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.DefaultIfRumuzId)
                      .HasColumnName("DEFAULT_IF_RUMUZ_ID")
                      .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.TempId)
                      .HasColumnName("TEMP_ID")
                      .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.PostDoc)
                      .HasColumnName("POST_DOC")
                      .HasColumnType("bit")
                      .HasDefaultValue(false);

                entity.Property(e => e.SskNo)
                      .HasColumnName("SSK_NO")
                      .HasMaxLength(20)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.Status)
                      .HasColumnName("STATUS")
                      .HasColumnType("numeric(10, 0)");

                entity.Property(e => e.IbanNo)
                      .HasColumnName("IBAN_NO")
                      .HasMaxLength(50)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.UnvanTarihi)
                      .HasColumnName("UNVAN_TARIHI")
                      .HasColumnType("datetime2");

                entity.Property(e => e.UnvandaFiilenBaslamaTarihi)
                      .HasColumnName("UNVANDA_FIILEN_BASLAMA_TARIHI")
                      .HasColumnType("datetime2");

                entity.Property(e => e.UnvandaKararnameTarihi)
                      .HasColumnName("UNVANDA_KARARNAME_TARIHI")
                      .HasColumnType("datetime2");

                entity.Property(e => e.YoksisOnay)
                      .HasColumnName("YOKSIS_ONAY")
                      .HasColumnType("float");

                entity.Property(e => e.Sube)
                      .HasColumnName("SUBE")
                      .HasMaxLength(4000)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.HesapNumarasi)
                      .HasColumnName("HESAP_NUMARASI")
                      .HasMaxLength(4000)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.YoksisEkipId)
                      .HasColumnName("YOKSIS_EKIP_ID")
                      .HasColumnType("int");

                entity.Property(e => e.OrcidId)
                      .HasColumnName("ORCID_ID")
                      .HasMaxLength(50)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.Property(e => e.ResearcherId)
                      .HasColumnName("RESEARCHER_ID")
                      .HasMaxLength(50)
                      .HasColumnType("varchar")
                      .IsUnicode(false);

                entity.HasOne(d => d.Fakulte)
                          .WithMany()
                          .HasForeignKey(d => d.FakulteId)
                          .HasPrincipalKey(d => d.Id);
                entity.HasOne(d => d.MissionCorpnode)
                          .WithMany()
                          .HasForeignKey(d => d.MissionNodeId)
                          .HasPrincipalKey(d => d.Id);
                entity.HasOne(d => d.MissionFakulteNode)
                          .WithMany()
                          .HasForeignKey(d => d.MissionFakulteId)
                          .HasPrincipalKey(d => d.Id);
                entity.HasOne(d => d.Corpnode)
                          .WithMany()
                          .HasForeignKey(d => d.NodeId)
                          .HasPrincipalKey(d => d.Id);

                entity.HasMany(x => x.Keyword);
            });

            modelBuilder.Entity<Corpnode>(entity =>
            {
                entity.ToTable("CORPNODE", "BOUNBAP");

                entity.HasKey(e => e.Id)
                      .HasName("SYS_C0012784"); // PRIMARY KEY

                // IDENTITY column
                entity.Property(e => e.Id)
                      .HasColumnName("ID")
                      .ValueGeneratedOnAdd() // Otomatik artan
                      .HasColumnType("int");

                // String columns
                entity.Property(e => e.Name)
                      .HasColumnName("NAME")
                      .HasMaxLength(255) // varchar(255)
                      .IsRequired()
                      .IsUnicode(false); // Unicode kapalı

                entity.Property(e => e.BounKod)
                      .HasColumnName("BOUN_KOD")
                      .HasMaxLength(20) // varchar(20)
                      .IsUnicode(false);

                entity.Property(e => e.YukseltmeKriteri)
                      .HasColumnName("YUKSELTME_KRITERI")
                      .HasMaxLength(500) // varchar(500)
                      .IsUnicode(false);

                // int columns
                entity.Property(e => e.ParentId)
                      .HasColumnName("PARENT_ID")
                      .HasColumnType("int")
                      .IsRequired();

                entity.Property(e => e.Nodetypeid)
                      .HasColumnName("NODETYPEID")
                      .HasColumnType("int");

                entity.Property(e => e.UstId)
                      .HasColumnName("UST_ID")
                      .HasColumnType("int");

                entity.Property(e => e.DoktoraProgrami)
                      .HasColumnName("DOKTORA_PROGRAMI")
                      .HasColumnType("int");

                entity.Property(e => e.YeniId)
                      .HasColumnName("YENI_ID")
                      .HasColumnType("int");

                entity.Property(e => e.Enstitu)
                      .HasColumnName("ENSTITU")
                      .HasColumnType("int");

                // bit columns
                entity.Property(e => e.Temp)
                      .HasColumnName("TEMP")
                      .HasColumnType("bit");

                entity.Property(e => e.Tip)
                      .HasColumnName("TIP")
                      .HasColumnType("bit");

                entity.Property(e => e.Fen)
                      .HasColumnName("FEN")
                      .HasColumnType("bit")
                      .HasDefaultValue(false); // Default: 0

                entity.Property(e => e.Sosyal)
                      .HasColumnName("SOSYAL")
                      .HasColumnType("bit")
                      .HasDefaultValue(false); // Default: 0

                entity.Property(e => e.FenOther)
                      .HasColumnName("FEN_OTHER")
                      .HasColumnType("bit")
                      .HasDefaultValue(false); // Default: 0

                entity.Property(e => e.SosyalOther)
                      .HasColumnName("SOSYAL_OTHER")
                      .HasColumnType("bit")
                      .HasDefaultValue(false); // Default: 0

                entity.Property(e => e.TemelBilimler)
                      .HasColumnName("TEMEL_BILIMLER")
                      .HasColumnType("bit")
                      .HasDefaultValue(false); // Default: 0

                entity.Property(e => e.TeknikBilimler)
                      .HasColumnName("TEKNIK_BILIMLER")
                      .HasColumnType("bit")
                      .HasDefaultValue(false); // Default: 0

                entity.Property(e => e.OncelikliAlan)
                      .HasColumnName("ONCELIKLI_ALAN")
                      .HasColumnType("bit")
                      .HasDefaultValue(false); // Default: 0

                // Number column
                entity.Property(e => e.Kod)
                      .HasColumnName("KOD")
                      .HasColumnType("int");

                // Relationships
                entity.HasOne(d => d.Nodetype)
                    .WithMany(p => p.Corpnodes)
                    .HasForeignKey(d => d.Nodetypeid)
                    .HasConstraintName("FK_CORPNODE_311");


                entity.HasOne(d => d.Parent)
                 .WithMany()
                 .HasForeignKey(d => d.ParentId)
                 .HasPrincipalKey(d => d.Id);


                //entity.HasOne(d => d.Parent)
                //      .WithMany(p => p.Children)
                //      .HasForeignKey(d => d.ParentId)
                //      .OnDelete(DeleteBehavior.Restrict) // Parent silinirse, child etkilenmez
                //      .HasConstraintName("FK_CORPNODE_PARENT");
            });

            modelBuilder.Entity<Nodeuser>(entity =>
            {
                entity.ToTable("NODEUSER", "BOUNBAP");

                entity.HasKey(e => e.Id).HasName("SYS_C0012983");

                entity.Property(e => e.Id)
                      .HasColumnName("ID")
                      .HasColumnType("int");

                entity.Property(e => e.Userid)
                      .HasColumnName("USERID")
                      .HasColumnType("int")
                      .IsRequired();

                entity.Property(e => e.Corpnodeid)
                      .HasColumnName("CORPNODEID")
                      .HasColumnType("int");

                // Foreign Key to CorpNode
                entity.HasOne(e => e.Corpnode)
                      .WithMany()
                      .HasForeignKey(e => e.Corpnodeid)
                      .HasConstraintName("FK_NODEUSER_CORPNODE");

                // Foreign Key to User (if applicable)
                // Uncomment and modify if USER table exists and USERID is a foreign key
                // entity.HasOne(e => e.User)
                //       .WithMany()
                //       .HasForeignKey(e => e.UserId)
                //       .HasConstraintName("FK_NODEUSER_USER");
            });

            modelBuilder.Entity<Keyword>(entity =>
            {
                entity.ToTable("KEYWORD", "BOUNBAP");

                entity.HasKey(e => e.Id)
                    .HasName("KEYWORD_PK");  // Primary Key adı

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int")  // SQL 'int' karşılığı
                    .ValueGeneratedNever();  // IDENTITY özelliği yok

                entity.Property(e => e.Keyword1)
                    .HasColumnName("KEYWORD")
                    .HasMaxLength(4000)  // SQL 'varchar(4000)' karşılığı
                    .IsUnicode(false);

                entity.Property(e => e.ProjectId)
                    .HasColumnName("PROJECT_ID")
                    .HasColumnType("bigint");  // SQL 'bigint' karşılığı

                entity.Property(e => e.PersonId)
                    .HasColumnName("PERSON_ID")
                    .HasColumnType("bigint");  // SQL 'bigint' karşılığı

                entity.Property(e => e.Type)
                    .HasColumnName("TYPE")
                    .HasColumnType("int");  // SQL 'numeric(38, 0)' karşılığı

                entity.Property(e => e.Line)
                    .HasColumnName("LINE")
                    .HasColumnType("int");  // SQL 'numeric(38, 0)' karşılığı
            });

            modelBuilder.Entity<Nodetype>(entity =>
            {
                entity.ToTable("NODETYPE");

                entity.Property(e => e.Id)
                    .HasPrecision(10)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });





            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
