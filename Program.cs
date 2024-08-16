var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServices();

var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddDbContext<AnnouncementContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/api/v1/announcements/{id}", AnnouncementEndpoints.Get);
app.MapGet("/api/v1/announcements/", AnnouncementEndpoints.GetAll);
app.MapGet("/api/v1/announcements/{id}/simillar", AnnouncementEndpoints.GetSimilar);
app.MapPost("/api/v1/announcements/create", AnnouncementEndpoints.Create);
app.MapPut("/api/v1/announcements/{id}", AnnouncementEndpoints.Update);
app.MapDelete("/api/v1/announcements/{id}", AnnouncementEndpoints.Delete);

app.Run();

