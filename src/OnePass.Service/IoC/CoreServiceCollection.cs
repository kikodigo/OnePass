using Microsoft.Extensions.DependencyInjection;
using OnePass.Core.Services;
using OnePass.Core.Services.Interface;

namespace OnePass.Core.IoC
{
    public static class CoreServiceCollection
    {
        public static void AddCoreServices(this IServiceCollection services)
        {
            services.AddSingleton<IOnePassServices, OnePassServices>();
        }
    }
}
