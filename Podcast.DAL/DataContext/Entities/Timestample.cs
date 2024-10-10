namespace Podcast.DAL.DataContext.Entities;

public class Timestample : Entity
{
    public DateTime CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime LastUpdatedAt { get; set; }
    public string? LastUpdatedBy { get; set; }
}
