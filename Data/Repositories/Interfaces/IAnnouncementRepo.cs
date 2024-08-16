namespace AnnouncementTask.Data.Repositories.Interfaces;

public interface IAnnouncementRepo
{
    Task<Announcement?> GetAsync(int id);
    Task<IEnumerable<Announcement>> GetAllAsync();
    Task<Announcement> AddAsync(Announcement announcement);
    Task UpdateAsync(Announcement announcement);
    Task DeleteAsync(Announcement announcement);
}
