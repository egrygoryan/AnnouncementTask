namespace AnnouncementTask.DTO;

public record CreateAnnouncementResponse(
    int Id,
    string Title,
    string Description,
    DateTime CreatedTime);
