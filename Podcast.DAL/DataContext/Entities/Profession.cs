namespace Podcast.DAL.DataContext.Entities;

public class Profession : Timestample
{
    public required string Name { get; set; }
    public List<SpeakerProfession>? SpeakerProfessions { get; set; }
}
