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


          


            //OnModelCreatingPartial(modelBuilder);
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
