using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Context.Entities;

/// <summary>Тур.</summary>
[Table("tours")]
public class TourEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public Guid LocationId { get; set; }

    public LocationEntity Location { get; set; } = null!;

    /// <summary>Цена за одного человека.</summary>
    public decimal Price { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int AvailableSeats { get; set; }

    public ICollection<BookingEntity> Bookings { get; set; } = new List<BookingEntity>();
}
