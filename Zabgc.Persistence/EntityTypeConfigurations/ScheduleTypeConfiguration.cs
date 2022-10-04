using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zabgc.Domain.Models;

namespace Zabgc.Persistence.EntityTypeConfigurations
{
    public class ScheduleTypeConfiguration : IEntityTypeConfiguration<ScheduleType>
    {
        public void Configure(EntityTypeBuilder<ScheduleType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
