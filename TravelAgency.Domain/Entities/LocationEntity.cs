using System.ComponentModel.DataAnnotations.Schema;
using TravelAgency.Domain.Entities.Base;
using TravelAgency.Domain.Enums;

namespace TravelAgency.Domain.Entities;

[Table("locations")]
public class LocationEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public HotelCategoryEnum Category { get; set; }

    public ICollection<TourEntity> Tours { get; set; } = new List<TourEntity>();
}
