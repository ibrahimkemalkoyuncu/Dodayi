using Dodayi.Services.BapAPI.Abstract;
using Dodayi.Services.BapAPI.Concrete;
using Dodayi.Services.BapAPI.Data;
using Dodayi.Services.BapAPI.Repository.IRepository;
using Dodayi.Services.BapAPI.Repository;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Dodayi.Services.BapAPI;

var builder = WebApplication.CreateBuilder(args);

// Database Context
builder.Services.AddDbContext<ModelContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("BapConnection")
    );
});

// Mapping
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Controller ve API related
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//// Repository Registrations
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//// Service Registrations
//builder.Services.AddScoped<IArbisKeywordService, ArbisKeywordManager>();


var app = builder.Build();

// Middleware Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();