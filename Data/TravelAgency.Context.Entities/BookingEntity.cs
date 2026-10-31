using System.ComponentModel.DataAnnotations.Schema;
using TravelAgency.Context.Entities.Enums;

namespace TravelAgency.Context.Entities;

/// <summary>
/// Связь «многие ко многим» между туристом и туром.
/// Не наследуется от BaseEntity: первичный ключ составной (TouristId + TourId).
/// </summary>
[Table("bookings")]
public class BookingEntity
{
    public DateTime BookingDate { get; set; } = DateTime.UtcNow;
    public BookingStatusEnum Status { get; set; }
    public int NumberOfPeople { get; set; }


    public int TouristId { get; set; }
    public TouristEntity Tourist { get; set; } = null!;


    public int TourId { get; set; }
    public TourEntity Tour { get; set; } = null!;
}
