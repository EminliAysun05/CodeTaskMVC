namespace Podcast.DAL.DataContext.Entities
{
    public class Topic : Timestample
    {
        public required string Name { get; set; }
        public required string CoverUrl { get; set; }

        public List<Episode>? Episodes { get; set; }

    }
}
