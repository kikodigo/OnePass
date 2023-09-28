using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using OnePass.Repository.Interfaces;

namespace OnePass.Repository.IoC
{
    public static class RepositoryServiceCollection
    {
        public static void AddRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton(new MySqlConnection(connectionString));
            services.AddSingleton<IOnePassRepository, OnePassRepository>();
        }
    }
}
