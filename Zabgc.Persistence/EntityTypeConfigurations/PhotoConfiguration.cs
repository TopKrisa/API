using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zabgc.Domain.Models;

namespace Zabgc.Persistence.EntityTypeConfigurations
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Url).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.Size).IsRequired();

        }
    }
}
