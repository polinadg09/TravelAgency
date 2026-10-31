using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelAgency.Context.Entities;

namespace TravelAgency.Context.Configurations;

public class TouristEntityConfiguration : IEntityTypeConfiguration<TouristEntity>
{
    public void Configure(EntityTypeBuilder<TouristEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.ExternalId).IsUnique();
        builder.HasIndex(x => x.PassportData).IsUnique();

        // User 1 : 0..1 Tourist
        builder.HasOne(x => x.User)
            .WithOne(x => x.Tourist)
            .HasForeignKey<TouristEntity>(x => x.UserId);
    }
}
