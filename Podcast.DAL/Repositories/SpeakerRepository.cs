using Podcast.DAL.DataContext;
using Podcast.DAL.DataContext.Entities;
using Podcast.DAL.Repositories.Contracts;

namespace Podcast.DAL.Repositories;

public class SpeakerRepository : EfCoreRepository<Speaker>, ISpeakerRepository
{
    private readonly AppDbContext _dbContext;

    public SpeakerRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public Speaker OnlySpeaker()
    {
        throw new NotImplementedException();
    }
}