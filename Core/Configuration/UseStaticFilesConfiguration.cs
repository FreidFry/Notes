using Microsoft.Extensions.FileProviders;

namespace Notes.Server.Core.Configuration
{
    internal static class UseStaticFilesConfiguration
    {
        internal static void UseStaticFilesConfigure(this WebApplication app)
        {
            string wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            if (!Directory.Exists(wwwrootPath)) Directory.CreateDirectory(wwwrootPath);

            string userDataPath = Path.Combine(wwwrootPath, "userData");
            if (!Directory.Exists(userDataPath)) Directory.CreateDirectory(userDataPath);


            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(wwwrootPath),
                RequestPath = "/static"
            });

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(userDataPath),
                RequestPath = "/userData"
            });
        }
    }
}
