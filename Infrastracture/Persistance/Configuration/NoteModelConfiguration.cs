using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Server.Infrastracture.Persistance.Models;

namespace Notes.Server.Infrastracture.Persistance.Configuration
{
    public class NoteModelConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Notes");

            builder.HasKey(n => n.Id);
            builder.Property(n => n.Title).IsRequired().HasMaxLength(100);
            builder.Property(n => n.Content).IsRequired().HasMaxLength(15000);
            builder.Property(n => n.CreatedAt).IsRequired();
            builder.Property(n => n.UpdatedAt);
            builder.Property(n => n.IsPinned).IsRequired();
            builder.Property(n => n.IsDeleted).IsRequired();
        }
    }
}
