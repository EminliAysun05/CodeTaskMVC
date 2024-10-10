using Podcast.DAL.DataContext;
using Podcast.DAL.DataContext.Entities;
using Podcast.DAL.Repositories.Contracts;

namespace Podcast.DAL.Repositories;

public class SpeakerProfessionRepository : EfCoreRepository<SpeakerProfession>, ISpeakerProfessionRepository
{
    private readonly AppDbContext _dbContext;

    public SpeakerProfessionRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}