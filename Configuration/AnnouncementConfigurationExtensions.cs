using AnnouncementTask.Data.Repositories;
using AnnouncementTask.Data.Repositories.Interfaces;

namespace AnnouncementTask.Configuration;

public static class AnnouncementConfigurationExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddScoped<IAnnouncementRepo, AnnouncementRepo>()
            .AddTransient<IAnnouncementService, AnnouncementService>();
}
