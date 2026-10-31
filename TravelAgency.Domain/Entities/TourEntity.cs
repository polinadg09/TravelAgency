using System.ComponentModel.DataAnnotations.Schema;
using TravelAgency.Domain.Entities.Base;

namespace TravelAgency.Domain.Entities;

[Table("tours")]
public class TourEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price { get; set; } 
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public int AvailableSeats { get; set; }


    public int LocationId { get; set; }
    public LocationEntity Location { get; set; } = null!;


    public ICollection<BookingEntity> Bookings { get; set; } = new List<BookingEntity>();
}
