using Microsoft.Extensions.DependencyInjection;
using NetCoreAudio;
using NetCoreAudio.Interfaces;
using Podcast.BLL.Services;
using Podcast.BLL.Services.Contracts;
using Podcast.BLL.UI.Services;
using Podcast.BLL.UI.Services.Contracts;
using System.Reflection;

namespace Podcast.BLL;

public static class BusinessLogicLayerServiceRegistration
{
    public static IServiceCollection AddBllServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped(typeof(ICrudService<,,,>), typeof(CrudManager<,,,>));
        services.AddScoped<ISpeakerService, SpeakerManager>();
        services.AddScoped<IEpisodeService, EpisodeManager>();
        services.AddScoped<IProfessionService, ProfessionManager>();
        services.AddScoped<ITopicService, TopicManager>();
        services.AddScoped<ISpeakerProfessionService, SpeakerProfessionManager>();
        services.AddScoped<IHomeService, HomeManager>();
        services.AddScoped<IFileService, FileManager>();
        services.AddScoped<ICloudinaryService, CloudinaryManager>();
        services.AddScoped<IPlayer, Player>();
        services.AddScoped<IAudioService, AudioManager>();

        return services;
    }
}
