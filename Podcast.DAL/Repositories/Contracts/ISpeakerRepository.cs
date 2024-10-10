using Podcast.DAL.DataContext.Entities;

namespace Podcast.DAL.Repositories.Contracts;

public interface ISpeakerRepository : IRepositoryAsync<Speaker>
{
    Speaker OnlySpeaker();
}