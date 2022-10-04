using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zabgc.Domain.Models;

namespace Zabgc.Persistence.EntityTypeConfigurations
{
    public class NewsCategoryConfiguration : IEntityTypeConfiguration<NewsCategory>
    {
        public void Configure(EntityTypeBuilder<NewsCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(125);
            builder.Property(x => x.Description).IsRequired();
        }
    }
}
