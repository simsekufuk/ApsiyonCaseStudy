using ApsiyonCaseStudy.Data.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace ApsiyonCaseStudy.Data.IOC
{
    public class DataDependencyResolver
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ILoggerRepository, LoggerRepository>();
        }
    }
}
