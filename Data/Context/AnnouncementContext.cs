namespace AnnouncementTask.Data.Context;

public class AnnouncementContext(DbContextOptions<AnnouncementContext> options) : DbContext(options)
{
    public DbSet<Announcement> Announcements { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
