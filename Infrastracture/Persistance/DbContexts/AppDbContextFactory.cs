using dotenv.net;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Notes.Server.Properties;

namespace Notes.Server.Infrastracture.Persistance.DbContexts
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            DotEnv.Load(options: new DotEnvOptions(envFilePaths: ["Settings.env"]));
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(EnvSettings.ConnectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
