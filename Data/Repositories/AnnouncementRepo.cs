namespace AnnouncementTask.Data.Repositories;

public class AnnouncementRepo(AnnouncementContext ctx) : IAnnouncementRepo
{
    public async Task<Announcement> AddAsync(Announcement announcement)
    {
        var entity = await ctx.AddAsync(announcement);
        await ctx.SaveChangesAsync();
        return entity.Entity;
    }

    public async Task DeleteAsync(Announcement announcement)
    {
        ctx.Announcements.Remove(announcement);
        await ctx.SaveChangesAsync();
    }

    public async Task<Announcement?> GetAsync(int id) =>
        await ctx
            .Announcements
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<Announcement>> GetAllAsync() =>
        await ctx.Announcements.ToListAsync();

    public async Task UpdateAsync(Announcement announcement)
    {
        ctx.Attach(announcement).State = EntityState.Modified;
        await ctx.SaveChangesAsync();
    }
}
