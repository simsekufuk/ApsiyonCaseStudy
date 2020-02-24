using ApsiyonCaseStudy.Utilies.Abstract;
using Microsoft.Extensions.DependencyInjection;

namespace ApsiyonCaseStudy.Utilies.IOC
{
    public class UtiliesDependencyResolver
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IFileProcess, FileProcess>();
        }
    }
}
