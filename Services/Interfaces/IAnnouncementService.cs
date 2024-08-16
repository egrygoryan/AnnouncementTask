namespace AnnouncementTask.Services.Interfaces;

public interface IAnnouncementService
{
    Task<AnnouncementModel> GetAsync(int id);
    Task<IEnumerable<AnnouncementModel>> GetAllAsync();
    Task<IEnumerable<AnnouncementModel>> GetSimillarAsync(int id);
    Task<CreateAnnouncementResponse> CreateAsync(CreateAnnouncementRequest request);
    Task UpdateAsync(UpdateAnnouncementRequest request, int id);
    Task DeleteAsync(int id);
}
