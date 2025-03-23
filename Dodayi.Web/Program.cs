using Dodayi.Web.Service;
using Dodayi.Web.Service.IService;
using Dodayi.Web.Utility;
using Dodayi.Web.Service;
using Microsoft.AspNetCore.Authentication.Cookies;

// Web uygulaması builder'ını oluştur
var builder = WebApplication.CreateBuilder(args);

// MVC Controller ve View desteği ekle
builder.Services.AddControllersWithViews();

// HTTP istek işlemleri için gerekli servisleri ekle
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

// Mikroservisler için HTTP istemcileri tanımla
builder.Services.AddHttpClient<IProductService, ProductService>();
builder.Services.AddHttpClient<ICouponService, CouponService>();
builder.Services.AddHttpClient<ICartService, CartService>();
builder.Services.AddHttpClient<IAuthService, AuthService>();
//builder.Services.AddHttpClient<IOrderService, OrderService>();

// Mikroservis API URL'lerini yapılandırma dosyasından al
SD.CouponAPIBase = builder.Configuration["ServiceUrls:CouponAPI"];
SD.OrderAPIBase = builder.Configuration["ServiceUrls:OrderAPI"];
SD.ShoppingCartAPIBase = builder.Configuration["ServiceUrls:ShoppingCartAPI"];
SD.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];
SD.ProductAPIBase = builder.Configuration["ServiceUrls:ProductAPI"];
SD.BapAPIBase = builder.Configuration["ServiceUrls:BapAPI"];

// Servis bağımlılıklarını Dependency Injection Container'a ekle
builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IBaseService, BaseService>();
//builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<IArbisKeywordService, ArbisKeywordService>();
builder.Services.AddScoped<IDetailService, DetailService>();

// Cookie tabanlı kimlik doğrulama yapılandırması
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(10); // Cookie geçerlilik süresi
        options.LoginPath = "/Auth/Login"; // Giriş sayfası yolu
        options.AccessDeniedPath = "/Auth/AccessDenied"; // Erişim reddedildiğinde yönlendirilecek sayfa
    });

// Web uygulamasını oluştur
var app = builder.Build();

// HTTP istek pipeline'ını yapılandır
if (!app.Environment.IsDevelopment())
{
    // Hata yönetimi (sadece Production ortamında)
    app.UseExceptionHandler("/Home/Error");
    // HSTS (HTTP Strict Transport Security) yapılandırması
    app.UseHsts();
}

// HTTPS yönlendirmesini etkinleştir
app.UseHttpsRedirection();

// Statik dosyaları (CSS, JS, vb.) sunmayı etkinleştir
app.UseStaticFiles();

// Routing mekanizmasını etkinleştir
app.UseRouting();

// Kimlik doğrulama middleware'ini ekle
app.UseAuthentication();

// Yetkilendirme middleware'ini ekle
app.UseAuthorization();

// Varsayılan controller route yapılandırması
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Uygulamayı başlat
app.Run();
