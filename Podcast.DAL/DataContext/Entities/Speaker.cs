namespace Podcast.DAL.DataContext.Entities;

public class Speaker :  Timestample
{
    //public Speaker()
    //{
        
    //}

    //public Speaker(string name, string imageUrl)
    //{
    //    Name = name;
    //    ImageUrl = imageUrl;
    //}
    
    public required string Name { get; set; }
    public required string ImageUrl {  get; set; }
    public List<SpeakerProfession>? SpeakerProfessions { get; set; }
    public List<Episode>? Episodes { get; set; }
}
