using Dodayi.Services.BapAPI.Data;
using Dodayi.Services.BapAPI.Repository.IRepository;
using Dodayi.Services.BapAPI.Repository;
using System.Reflection;

namespace Dodayi.Services.BapAPI.IoC
{
    public static class ModuleInjector
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddDbContext<ModelContext>();
            //services.AddDbContext<TtsModelContext>();
            //services.AddDbContext<DTeminContext>();
            //services.AddDbContext<DiskaynakContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IUnitOfWorkTTS, UnitOfWorkTTS>();
            //services.AddScoped<IUnitOfDTemin, UnitOfWorkDTemin>();
            //services.AddScoped<IUnitOfDiskaynak, UnitOfDiskaynak>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return services;

        }
    }
}
