using MockInterview.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfigurations()
    .AddCustomLogging()
    .AddDbContexts()
    .AddEntityRepositories()
    .AddEntityServices()
    .AddBllServices()
    .AddValidations()
    .AddCustomRouting()
    .AddCustomControllers()
    .AddOpenApiTools();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSeedData();
}

app.UseOpenApiTools();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();