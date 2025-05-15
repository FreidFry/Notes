using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Notes.Server.Core.Configuration;
using Notes.Server.Infrastracture.Persistance.DbContexts;
using Notes.Server.Properties;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load(options: new DotEnvOptions(envFilePaths: ["Settings.env"]));

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


builder.Services
    .AddCorpsConfigurations()
    .AddRateLimitConfiguration()
    .AddMediatRConfiguration()
    .AddDipencyInjectionConfiguration()
    .AddJwtConfiguration();

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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseRateLimiter();


    app.UseSwagger();
    app.UseSwaggerUI();

app.UseStaticFilesConfigure();



app.Run();
