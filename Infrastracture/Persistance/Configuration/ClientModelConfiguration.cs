using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Server.Infrastracture.Persistance.Models;

namespace Notes.Server.Infrastracture.Persistance.Configuration
{
    public class ClientModelConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.Age).IsRequired();
            builder.Property(c => c.CreatedAt).IsRequired();
            builder.Property(c => c.LastLogin).IsRequired();
            builder.Property(c => c.AvatarTumbnailPath).IsRequired(false);
            builder.Property(c => c.AvatarPath).IsRequired(false);
            builder.Property(c => c.Password).IsRequired().HasMaxLength(100);


            builder.HasMany(c => c.Notes)
                .WithOne(n => n.ClientOwner)
                .HasForeignKey(n => n.ClientOwnerId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
