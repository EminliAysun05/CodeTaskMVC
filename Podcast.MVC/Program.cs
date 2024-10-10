using Podcast.DAL;
using Podcast.BLL;
using Podcast.BLL.Data;

namespace Podcast.MVC;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.AddDalServices(builder.Configuration);
        builder.Services.AddBllServices();
        Constants.EpisodeImagePath = Path.Combine(builder.Environment.WebRootPath, "images", "podcast");

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
