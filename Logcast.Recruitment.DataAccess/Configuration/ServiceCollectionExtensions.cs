using Logcast.Recruitment.Application.Interfaces.Persistance;
using Logcast.Recruitment.DataAccess.Factories;
using Logcast.Recruitment.DataAccess.Repositories;
using Logcast.Recruitment.DataAccess.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Logcast.Recruitment.DataAccess.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static void AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IDbContext, ApplicationDbContext>();
        }

        public static void AddDataAccessServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddFactories();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ISubscriptionRepository, SubscriptionRepository>();
            services.AddTransient<IAudioFileRepository, AudioFileRepository>();
            services.AddTransient<IAudioFileMetaDataRepository, AudioFileMetadataRepository>();
        }

        private static void AddFactories(this IServiceCollection services)
        {
            services.AddTransient<IDbContextFactory, DbContextFactory>();
        }
    }
}