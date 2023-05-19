using Entities.DataTransferObjects;
using Microsoft.EntityFrameworkCore;
using Presentation.ActionFiltters;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contacts;

namespace WebApi.Extentions
{
    public static class ServicesExtentions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>


            services.AddDbContext<RepositoryContext>(
                options =>
            options.UseSqlServer(configuration.GetConnectionString("sqlConnection"))
            );

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerService, LoggerManager>();

        public static void ConfigureActionFilters(this IServiceCollection services)
        {
            services.AddScoped<ValidationFilterAttribute>();//IoC
            services.AddScoped<LogFilterAttribute>();//IoC
        }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(option => {
                option.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("X-Pagination")
                );
            }); 
        }
        
        public static void ConfigureDataShape(this IServiceCollection service)
        {
            service.AddScoped<IDataShaper<BookDto>,DataShaper<BookDto>>();
        }
    }
}
