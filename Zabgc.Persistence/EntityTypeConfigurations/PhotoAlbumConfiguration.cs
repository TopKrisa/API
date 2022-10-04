using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zabgc.Domain.Models;

namespace Zabgc.Persistence.EntityTypeConfigurations
{
    public class PhotoAlbumConfiguration : IEntityTypeConfiguration<PhotoAlbum>
    {
        public void Configure(EntityTypeBuilder<PhotoAlbum> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(125);
        }
    }
}
