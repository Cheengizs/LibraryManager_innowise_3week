using LibraryManager.DatabaseImitation;
using LibraryManager.Repositories.AuthorRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddScoped<LibraryDbContext>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
