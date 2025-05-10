using Microsoft.EntityFrameworkCore;
using Notes.Server.Infrastracture.Persistance.Configuration;
using Notes.Server.Infrastracture.Persistance.Models;

namespace Notes.Server.Infrastracture.Persistance.DbContexts
{
    public class AppDbContext : DbContext
    {

        public DbSet<Client> Clients { get; set; }
        public DbSet<Note> Notes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientModelConfiguration());
            modelBuilder.ApplyConfiguration(new NoteModelConfiguration());
        }
    }
}
