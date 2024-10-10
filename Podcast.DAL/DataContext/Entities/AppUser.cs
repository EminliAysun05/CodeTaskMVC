using Microsoft.AspNetCore.Identity;

namespace Podcast.DAL.DataContext.Entities;

public class AppUser : IdentityUser
{
    public string? FullName {  get; set; }
}
