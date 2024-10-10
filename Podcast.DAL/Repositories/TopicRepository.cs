using Podcast.DAL.DataContext;
using Podcast.DAL.DataContext.Entities;
using Podcast.DAL.Repositories.Contracts;

namespace Podcast.DAL.Repositories;

public class TopicRepository : EfCoreRepository<Topic>, ITopicRepository
{
    private readonly AppDbContext _dbContext;

    public TopicRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}
