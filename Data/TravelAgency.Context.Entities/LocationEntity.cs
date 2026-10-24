using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Context.Entities;

/// <summary>Место размещения (отель).</summary>
[Table("locations")]
public class LocationEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Country { get; set; } = string.Empty;

    public string City { get; set; } = string.Empty;

    public string? Address { get; set; }

    public HotelCategoryEnum Category { get; set; }

    public string? Description { get; set; }

    public ICollection<TourEntity> Tours { get; set; } = new List<TourEntity>();
}
