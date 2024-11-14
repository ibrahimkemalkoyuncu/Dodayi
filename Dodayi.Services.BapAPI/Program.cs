using Dodayi.Services.BapAPI.Abstract;
using Dodayi.Services.BapAPI.Concrete;
using Dodayi.Services.BapAPI.Data;
using Dodayi.Services.BapAPI.Repository.IRepository;
using Dodayi.Services.BapAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Database Context
builder.Services.AddDbContext<ModelContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("BapConnection")
    );
});

// Repository Registrations
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Service Registrations
builder.Services.AddScoped<IArbisKeywordService, ArbisKeywordManager>();

// Controller ve API related
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS Policy
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

// Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();