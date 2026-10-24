using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Context.Entities;

/// <summary>Профиль туриста: данные, нужные для оформления бронирования.</summary>
[Table("tourists")]
public class TouristEntity
{
    public Guid Id { get; set; }

    public string PassportData { get; set; } = string.Empty;

    public DateOnly Birthdate { get; set; }

    public Guid UserId { get; set; }

    public UserEntity User { get; set; } = null!;

    public ICollection<BookingEntity> Bookings { get; set; } = new List<BookingEntity>();
}
