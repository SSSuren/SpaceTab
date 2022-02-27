using Logcast.Recruitment.Application.UseCases.AudioFileMetadatas;
using Logcast.Recruitment.Application.UseCases.AudioFiles;
using Logcast.Recruitment.Application.UseCases.Subscriptions;
using Microsoft.Extensions.DependencyInjection;

namespace Logcast.Recruitment.Shared.Configuration
{
    public static class ServiceCollectionExtension
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ISubscriptionService, SubscriptionService>();
            services.AddTransient<IAudioFileService, AudioFileService>();
            services.AddTransient<IAudioFileMetadataService, AudioFileMetadataService>();
        }
    }
}
