using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Infrastructure.Data.Configurations;

public class BookingEntityConfiguration : IEntityTypeConfiguration<BookingEntity>
{
    public void Configure(EntityTypeBuilder<BookingEntity> builder)
    {
        builder.HasKey(x => new { x.TouristId, x.TourId });

        // Tourist 1 : M Booking
        builder.HasOne(x => x.Tourist)
            .WithMany(x => x.Bookings)
            .HasForeignKey(x => x.TouristId);

        // Tour 1 : M Booking
        builder.HasOne(x => x.Tour)
            .WithMany(x => x.Bookings)
            .HasForeignKey(x => x.TourId);
    }
}
