using Dodayi.Web.Service;
using Dodayi.Web.Service.IService;
using Dodayi.Web.Utility;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();


builder.Services.AddHttpClient<ICouponService, CouponService>();
SD.CouponAPIBase = builder.Configuration["ServiceUrls:CouponAPI"] ?? string.Empty;

builder.Services.AddHttpClient<IArbisKeywordService, ArbisKeywordService>();
builder.Services.AddHttpClient<IDetailService, DetailService>();
SD.BapAPIBase = builder.Configuration["ServiceUrls:BapAPI"] ?? string.Empty;



builder.Services.AddScoped<IBaseService, BaseService>();    
builder.Services.AddScoped<ICouponService, CouponService>();
builder.Services.AddScoped<IArbisKeywordService, ArbisKeywordService>();
builder.Services.AddScoped<IDetailService, DetailService>();

// CORS Policy Tanýmlama
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
