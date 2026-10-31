using Microsoft.EntityFrameworkCore;
using TravelAgency.Infrastructure.Data.Configurations;
using TravelAgency.Domain.Entities;

namespace TravelAgency.Infrastructure.Data;

public class TravelAgencyDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<TouristEntity> Tourists { get; set; }
    public DbSet<LocationEntity> Locations { get; set; }
    public DbSet<TourEntity> Tours { get; set; }
    public DbSet<BookingEntity> Bookings { get; set; }


    public TravelAgencyDbContext(DbContextOptions<TravelAgencyDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // настройка каждой сущности вынесена в отдельный класс
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TouristEntityConfiguration());
        modelBuilder.ApplyConfiguration(new LocationEntityConfiguration());
        modelBuilder.ApplyConfiguration(new TourEntityConfiguration());
        modelBuilder.ApplyConfiguration(new BookingEntityConfiguration());
    }
}
