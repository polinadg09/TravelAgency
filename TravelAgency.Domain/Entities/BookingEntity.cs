using System.ComponentModel.DataAnnotations.Schema;
using TravelAgency.Domain.Enums;

namespace TravelAgency.Domain.Entities;

/// <summary> Связь многие ко многим между туристом и туром.</summary>
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
