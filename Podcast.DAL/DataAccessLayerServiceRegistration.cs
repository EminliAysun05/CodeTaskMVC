using Microsoft.Extensions.DependencyInjection;
using Podcast.DAL.Repositories.Contracts;
using Podcast.DAL.Repositories;
using Podcast.DAL.DataContext;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Podcast.DAL;

public static class DataAccessLayerServiceRegistration
{
    public static IServiceCollection AddDalServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Default"));
        });

        services.AddScoped(typeof(IRepositoryAsync<>), typeof(EfCoreRepository<>));
        services.AddScoped<ISpeakerRepository, SpeakerRepository>();
        services.AddScoped<ITopicRepository, TopicRepository>();
        services.AddScoped<IEpisodeRepository, EpisodeRepository>();
        services.AddScoped<ISpeakerProfessionRepository, SpeakerProfessionRepository>();

        return services;
    }
}
