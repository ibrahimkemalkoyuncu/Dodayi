using AutoMapper;
using Dodayi.Services.CouponAPI;
using Dodayi.Services.CouponAPI.Data;
using Dodayi.Services.CouponAPI.Extension;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

// Web uygulaması builder'ını oluştur
var builder = WebApplication.CreateBuilder(args);

// Veritabanı bağlantısını yapılandır
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// AutoMapper yapılandırması
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Controller'ları ekle
builder.Services.AddControllers();

// API endpoint keşfini ekle
builder.Services.AddEndpointsApiExplorer();

// Swagger belgelendirmesini yapılandır
builder.Services.AddSwaggerGen(options =>
{
    // JWT kimlik doğrulama şemasını tanımla
    options.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    
    // Swagger UI'da güvenlik gereksinimlerini yapılandır
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            new string[] {}
        }
    });
});

// Kimlik doğrulama ayarlarını ekle
builder.AddAppAuthentication(); 

// Yetkilendirme servisini ekle
builder.Services.AddAuthorization();

// Web uygulamasını oluştur
var app = builder.Build();

// HTTP istek pipeline'ını yapılandır
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();

    // Swagger arayüzünü etkinleştir (sadece geliştirme ortamında)
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS yönlendirmesini etkinleştir
app.UseHttpsRedirection();

// Kimlik doğrulama middleware'ini etkinleştir
app.UseAuthentication();

// Yetkilendirme middleware'ini etkinleştir
app.UseAuthorization();

// Controller endpoint'lerini ayarla
app.MapControllers();

// Bekleyen tüm veritabanı migrasyonlarını uygula
ApplyMigration();

// Uygulamayı başlat
app.Run();

/// <summary>
/// Bekleyen tüm veritabanı migrasyonlarını uygular
/// </summary>
void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        if(_db.Database.GetPendingMigrations().Count() > 0) { _db.Database.Migrate(); }
    }
}
