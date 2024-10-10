using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Podcast.DAL.DataContext.Entities;

namespace Podcast.DAL.DataContext;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> dbContext) : base(dbContext)
    {
    }

    public DbSet<Speaker> Speakers { get; set; }
    public DbSet<Profession> Professions { get; set; }
    public DbSet<SpeakerProfession> SpeakerProfessions { get; set; }
    public DbSet<Topic> Topics { get; set; }
    public DbSet<Episode> Episodes { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        //builder.Entity<Speaker>().HasData(
        //[
        //    new Speaker { Id = 1, Name = "Chan", ImageUrl = "1.jpg" },
        //    new Speaker { Id = 2, Name = "Elise", ImageUrl = "2.jpg" },
        //    new Speaker { Id = 3, Name = "William", ImageUrl = "3.jpg" },
        //    new Speaker { Id = 4, Name = "Aqil", ImageUrl = "4.jpg" },
        //    new Speaker { Id = 5, Name = "Sebuhi", ImageUrl = "5.jpg" },
        //    new Speaker { Id = 6, Name = "Rizvan", ImageUrl = "5.jpg" },
        //]);

        //builder.Entity<Profession>().HasData(
        //[
        //    new Profession { Id = 1, Name = "Education" },
        //    new Profession { Id = 2, Name = "Artist" },
        //    new Profession { Id = 3, Name = "Influencer" },
        //    new Profession { Id = 4, Name = "Makler" },
        //]);

        //builder.Entity<SpeakerProfession>().HasData(
        //[
        //    new SpeakerProfession { Id = 1, SpeakerId = 1, ProfessionId = 1 },
        //    new SpeakerProfession { Id = 2, SpeakerId = 2, ProfessionId = 2 },
        //    new SpeakerProfession { Id = 3, SpeakerId = 3, ProfessionId = 3 },
        //    new SpeakerProfession { Id = 4, SpeakerId = 4, ProfessionId = 4 },
        //    new SpeakerProfession { Id = 5, SpeakerId = 5, ProfessionId = 4 },
        //    new SpeakerProfession { Id = 6, SpeakerId = 1, ProfessionId = 3 },
        //]);

        //builder.Entity<Topic>().HasData(
        //    [   
        //        new Topic{Id=1, Name = "Education", CoverUrl = "1.jpg"},
        //        new Topic{Id=2, Name = "Sport", CoverUrl = "2.jpg"},
        //        new Topic{Id=3, Name = "Music", CoverUrl = "3.jpg"},
        //        new Topic{Id=4, Name = "Culture", CoverUrl = "4.jpg"},
        //    ]);

        builder.Entity<Episode>().HasData(
            [
                new Episode{Id=1, Title = "Modern",Description ="Bu sad wdf", CoverUrl="1.jpg", LikeCount=223, DownloadCount=234, DurationInMinute=12, MusicUrl="1.mp3", SpeakerId = 17, TopicId=1},
                new Episode{Id=2, Title = "Old",Description ="JGCHVhkj", CoverUrl="2.jpg", LikeCount=234, DownloadCount=57, DurationInMinute=60, MusicUrl="2.mp3", SpeakerId = 18, TopicId=2},
            ]);

        base.OnModelCreating(builder);
    }
}