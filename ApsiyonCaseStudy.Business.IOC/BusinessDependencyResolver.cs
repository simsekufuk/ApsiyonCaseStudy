using ApsiyonCaseStudy.Business.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace ApsiyonCaseStudy.Business.IOC
{
    public class BusinessDependencyResolver
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ILoggerManager, LoggerManager>();
        }
    }
}
