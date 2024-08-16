namespace AnnouncementTask.Models;

public class AnnouncementModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationTime { get; set; }

    //method for checking whether title and description contains same word 
    //from chosen entity
    public bool HaveSameWords(IEnumerable<string> splitTitle, IEnumerable<string> splitDescription)
    {
        var intersectionTitles = Title.Split(' ')
            .Intersect(splitTitle, StringComparer.CurrentCultureIgnoreCase);
        var intersectionDescriptions = Description.Split(' ')
            .Intersect(splitDescription, StringComparer.CurrentCultureIgnoreCase);

        var sameWordInTitleAndDescription = intersectionTitles
            .Intersect(intersectionDescriptions, StringComparer.CurrentCultureIgnoreCase)
            .Any();

        return sameWordInTitleAndDescription;
    }

    //converter from Announcement to model
    public static implicit operator AnnouncementModel(Announcement announcement) =>
        new()
        {
            Title = announcement.Title,
            Description = announcement.Description,
            CreationTime = announcement.CreatedAt
        };

    //converter from seq. of announcements to seq of models
    public static IEnumerable<AnnouncementModel> ConvertFromAnnouncements(IEnumerable<Announcement> announcements)
    {
        List<AnnouncementModel> models = [.. announcements];
        return models;
    }
}

