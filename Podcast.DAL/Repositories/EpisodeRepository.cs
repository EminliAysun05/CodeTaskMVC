using Podcast.DAL.DataContext;
using Podcast.DAL.DataContext.Entities;
using Podcast.DAL.Repositories.Contracts;

namespace Podcast.DAL.Repositories;

public class EpisodeRepository : EfCoreRepository<Episode>, IEpisodeRepository
{
    private readonly AppDbContext _dbContext;

    public EpisodeRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
