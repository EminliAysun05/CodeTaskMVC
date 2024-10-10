namespace Podcast.DAL.DataContext.Entities;

public class SpeakerProfession : Entity
{
    public int SpeakerId { get; set; }
    public Speaker? Speaker { get; set; }
    public int ProfessionId {  get; set; }
    public Profession? Profession { get; set; }
}
