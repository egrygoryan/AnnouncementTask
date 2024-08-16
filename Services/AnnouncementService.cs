
namespace AnnouncementTask.Services;

public class AnnouncementService(IAnnouncementRepo repo) : IAnnouncementService
{
    public async Task<CreateAnnouncementResponse> CreateAsync(CreateAnnouncementRequest request)
    {
        var announcement = await repo.AddAsync(request);
        return new CreateAnnouncementResponse(
            Id: announcement.Id,
            Title: announcement.Title,
            Description: announcement.Description,
            CreatedTime: announcement.CreatedAt);
    }


    public async Task DeleteAsync(int id)
    {
        var announcement = await repo.GetAsync(id)
            ?? throw new ArgumentException($"Announcement {id} doesn't exist");

        await repo.DeleteAsync(announcement);
    }

    public async Task<AnnouncementModel> GetAsync(int id) =>
        await repo.GetAsync(id)
        ?? throw new ArgumentException($"Announcement {id} doesn't exist");

    public async Task<IEnumerable<AnnouncementModel>> GetAllAsync()
    {
        var announcements = await repo.GetAllAsync();
        var result = AnnouncementModel.ConvertFromAnnouncements(announcements);

        return result;
    }

    public async Task UpdateAsync(UpdateAnnouncementRequest request, int id)
    {
        var announcement = await repo.GetAsync(id)
            ?? throw new ArgumentException($"Can't update non-existent announcement. Id:{id} ");

        announcement.Title = request.Title;
        announcement.Description = request.Description;

        await repo.UpdateAsync(announcement);
    }

    public async Task<IEnumerable<AnnouncementModel>> GetSimillarAsync(int id)
    {
        //Get all entities 
        var announcementEntities = await repo.GetAllAsync();
        //Retrieve entity for which simillar entities we are looking for
        var chosenAnnouncementEntity = announcementEntities.FirstOrDefault(x => x.Id == id)
            ?? throw new ArgumentException($"Announcement {id} doesn't exist");
        //Retrieve all other entities
        var otherAnnouncementsEntities = announcementEntities.Where(x => x.Id != id);

        //map enitties to models
        AnnouncementModel mappedChosenModel = chosenAnnouncementEntity;
        var mappedOtherModels = AnnouncementModel.ConvertFromAnnouncements(otherAnnouncementsEntities);

        //split title and description for further processing
        //to decrease size, removed repeated words for each seq.
        var splitTitle = mappedChosenModel.Title.Split(' ').Distinct(StringComparer.CurrentCultureIgnoreCase);
        var splitDescription = mappedChosenModel.Description.Split(' ').Distinct(StringComparer.CurrentCultureIgnoreCase);

        //for every model check whether it contains same words from chosen entity 
        var similar = mappedOtherModels.Where(x => x.HaveSameWords(splitTitle, splitDescription)).Take(3);

        return similar;
    }
}
