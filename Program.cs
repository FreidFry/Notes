using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Notes.Server.Core.Configuration;
using Notes.Server.Infrastracture.Persistance.DbContexts;
using Notes.Server.Properties;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load(options: new DotEnvOptions(envFilePaths: ["Settings.env"]));

Console.WriteLine("ENV: " + EnvSettings.ConnectionString);
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers();
builder.Services.AddAuthentication();

if(builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

builder.Services
    .AddCorpsConfigurations()
    .AddRateLimitConfiguration();

builder.Services.AddDbContext<AppDbContext>(option =>
    option.UseNpgsql(EnvSettings.ConnectionString));

var app = builder.Build();

using(var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}


app.UseCors("Corps");
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseRateLimiter();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFilesConfigure();



app.Run();
