using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Infrastructure.Data.Configurations;

public class TourEntityConfiguration : IEntityTypeConfiguration<TourEntity>
{
    public void Configure(EntityTypeBuilder<TourEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.ExternalId).IsUnique();
        builder.HasOne(x => x.Location)
            .WithMany(x => x.Tours)
            .HasForeignKey(x => x.LocationId);
    }
}
