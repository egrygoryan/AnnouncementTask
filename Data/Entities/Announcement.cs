namespace AnnouncementTask.Data.Entities;

public class Announcement
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    //converter from CreateRequest to Announcement
    public static implicit operator Announcement(CreateAnnouncementRequest request) =>
        new()
        {
            Title = request.Title,
            Description = request.Description,
            CreatedAt = DateTime.Now
        };
}
