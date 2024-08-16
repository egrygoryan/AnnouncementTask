namespace AnnouncementTask.Endpoints;

public sealed class AnnouncementEndpoints
{
    public async static Task<IResult> Get(
    [FromRoute] int id,
    [FromServices] IAnnouncementService announcementService)
    {
        var result = await announcementService.GetAsync(id);

        return Results.Ok(result);

    }

    public async static Task<IResult> GetAll(
    [FromServices] IAnnouncementService announcementService)
    {
        var result = await announcementService.GetAllAsync();

        return Results.Ok(result);
    }

    public async static Task<IResult> GetSimilar(
    [FromRoute] int id,
    [FromServices] IAnnouncementService announcementService)
    {
        var result = await announcementService.GetSimillarAsync(id);

        return Results.Ok(result);
    }

    public async static Task<IResult> Create(
    [FromBody] CreateAnnouncementRequest request,
    [FromServices] IAnnouncementService announcementService)
    {
        var result = await announcementService.CreateAsync(request);

        return Results.Created($"/api/v1/announcements/{result.Id}", result);
    }

    public async static Task<IResult> Update(
    [FromRoute] int id,
    [FromBody] UpdateAnnouncementRequest request,
    [FromServices] IAnnouncementService announcementService)
    {
        await announcementService.UpdateAsync(request, id);

        return Results.Ok(new { Message = "Announcement updated succesfully" });
    }

    public async static Task<IResult> Delete(
    [FromRoute] int id,
    [FromServices] IAnnouncementService announcementService)
    {
        await announcementService.DeleteAsync(id);

        return Results.Ok(new { Message = "Announcement deleted succesfully" });
    }

}
