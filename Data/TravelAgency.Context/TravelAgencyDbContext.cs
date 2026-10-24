using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using TravelAgency.Context.Entities;

namespace TravelAgency.Context;

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
        // ---------- users ----------
        modelBuilder.Entity<UserEntity>().ToTable("users", t =>
            t.HasCheckConstraint("chk_users_login_len", "char_length(login) >= 3"));
        modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<UserEntity>().Property(x => x.Login).IsRequired().HasMaxLength(50);
        modelBuilder.Entity<UserEntity>().Property(x => x.PasswordHash).IsRequired().HasMaxLength(255);
        modelBuilder.Entity<UserEntity>().Property(x => x.Role).HasConversion<string>().HasMaxLength(20).IsRequired();
        modelBuilder.Entity<UserEntity>().Property(x => x.Email).IsRequired().HasMaxLength(100);
        modelBuilder.Entity<UserEntity>().Property(x => x.PhoneNumber).HasMaxLength(20);
        modelBuilder.Entity<UserEntity>().Property(x => x.Name).IsRequired().HasMaxLength(50);
        modelBuilder.Entity<UserEntity>().Property(x => x.Surname).IsRequired().HasMaxLength(50);
        modelBuilder.Entity<UserEntity>().Property(x => x.Patronymic).HasMaxLength(50);
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.Login).IsUnique();
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.Email).IsUnique();
        modelBuilder.Entity<UserEntity>().HasIndex(x => x.PhoneNumber).IsUnique();

        // ---------- tourists ----------
        modelBuilder.Entity<TouristEntity>().ToTable("tourists", t =>
            t.HasCheckConstraint("chk_tourists_birthdate", "birthdate >= '1900-01-01' AND birthdate <= CURRENT_DATE"));
        modelBuilder.Entity<TouristEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<TouristEntity>().Property(x => x.PassportData).IsRequired().HasMaxLength(20);
        modelBuilder.Entity<TouristEntity>().HasIndex(x => x.PassportData).IsUnique();
        // User 1 : 0..1 Tourist
        modelBuilder.Entity<TouristEntity>().HasOne(x => x.User)
            .WithOne(x => x.Tourist)
            .HasForeignKey<TouristEntity>(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // ---------- locations ----------
        modelBuilder.Entity<LocationEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<LocationEntity>().Property(x => x.Name).IsRequired().HasMaxLength(150);
        modelBuilder.Entity<LocationEntity>().Property(x => x.Country).IsRequired().HasMaxLength(80);
        modelBuilder.Entity<LocationEntity>().Property(x => x.City).IsRequired().HasMaxLength(80);
        modelBuilder.Entity<LocationEntity>().Property(x => x.Address).HasMaxLength(200);
        // enum хранится в БД строкой: OneStar, TwoStars, ...
        modelBuilder.Entity<LocationEntity>().Property(x => x.Category).HasConversion<string>().HasMaxLength(20).IsRequired();
        modelBuilder.Entity<LocationEntity>().HasIndex(x => new { x.Name, x.Country, x.City }).IsUnique();
        modelBuilder.Entity<LocationEntity>().HasIndex(x => x.Country);

        // ---------- tours ----------
        modelBuilder.Entity<TourEntity>().ToTable("tours", t =>
        {
            t.HasCheckConstraint("chk_tours_price", "price > 0");
            t.HasCheckConstraint("chk_tours_dates", "end_date >= start_date");
            t.HasCheckConstraint("chk_tours_available_seats", "available_seats >= 0");
        });
        modelBuilder.Entity<TourEntity>().HasKey(x => x.Id);
        modelBuilder.Entity<TourEntity>().Property(x => x.Name).IsRequired().HasMaxLength(150);
        modelBuilder.Entity<TourEntity>().Property(x => x.Price).HasPrecision(12, 2);
        modelBuilder.Entity<TourEntity>().HasIndex(x => new { x.Name, x.StartDate }).IsUnique();
        modelBuilder.Entity<TourEntity>().HasIndex(x => new { x.StartDate, x.EndDate });
        modelBuilder.Entity<TourEntity>().HasIndex(x => x.Price);
        // Location 1 : M Tour
        modelBuilder.Entity<TourEntity>().HasOne(x => x.Location)
            .WithMany(x => x.Tours)
            .HasForeignKey(x => x.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        // ---------- bookings (связь M:N Tourist <-> Tour) ----------
        modelBuilder.Entity<BookingEntity>().ToTable("bookings", t =>
            t.HasCheckConstraint("chk_bookings_number_of_people", "number_of_people >= 1"));
        // составной первичный ключ из двух идентификаторов
        modelBuilder.Entity<BookingEntity>().HasKey(x => new { x.TouristId, x.TourId });
        modelBuilder.Entity<BookingEntity>().Property(x => x.BookingDate).HasDefaultValueSql("CURRENT_TIMESTAMP");
        modelBuilder.Entity<BookingEntity>().Property(x => x.Status).HasConversion<string>().HasMaxLength(20).IsRequired();
        modelBuilder.Entity<BookingEntity>().HasIndex(x => x.TourId);
        modelBuilder.Entity<BookingEntity>().HasIndex(x => x.Status);
        // Tourist 1 : M Booking
        modelBuilder.Entity<BookingEntity>().HasOne(x => x.Tourist)
            .WithMany(x => x.Bookings)
            .HasForeignKey(x => x.TouristId)
            .OnDelete(DeleteBehavior.Restrict);
        // Tour 1 : M Booking
        modelBuilder.Entity<BookingEntity>().HasOne(x => x.Tour)
            .WithMany(x => x.Bookings)
            .HasForeignKey(x => x.TourId)
            .OnDelete(DeleteBehavior.Restrict);

        // В PostgreSQL колонки принято называть в snake_case: PhoneNumber -> phone_number
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                property.SetColumnName(ToSnakeCase(property.Name));
            }
        }
    }

    private static string ToSnakeCase(string name) =>
        Regex.Replace(name, "([a-z0-9])([A-Z])", "$1_$2").ToLowerInvariant();
}
