using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zabgc.Domain.Models;

namespace Zabgc.Persistence.EntityTypeConfigurations
{
    public class NewsPapperConfiguration : IEntityTypeConfiguration<Newspapper>
    {
        public void Configure(EntityTypeBuilder<Newspapper> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Url).IsRequired();
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
