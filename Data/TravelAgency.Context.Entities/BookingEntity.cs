using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Context.Entities;

/// <summary>
/// Бронирование. Раскрывает связь «многие ко многим» между туристом и туром,
/// первичный ключ составной: (TouristId, TourId).
/// </summary>
[Table("bookings")]
public class BookingEntity
{
    public Guid TouristId { get; set; }

    public TouristEntity Tourist { get; set; } = null!;

    public Guid TourId { get; set; }

    public TourEntity Tour { get; set; } = null!;

    /// <summary>Дата и время бронирования (UTC).</summary>
    public DateTime BookingDate { get; set; }

    public BookingStatusEnum Status { get; set; }

    public int NumberOfPeople { get; set; }
}
