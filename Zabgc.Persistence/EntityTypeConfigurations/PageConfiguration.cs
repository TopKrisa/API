using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zabgc.Domain.Models;

namespace Zabgc.Persistence.EntityTypeConfigurations
{
    public class PageConfiguration : IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Text).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.CreationDate).IsRequired();
            builder.HasOne(typeof(PageCategory));
        }
    }
}
