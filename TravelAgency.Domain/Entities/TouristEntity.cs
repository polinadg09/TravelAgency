using System.ComponentModel.DataAnnotations.Schema;
using TravelAgency.Domain.Entities.Base;

namespace TravelAgency.Domain.Entities;

[Table("tourists")]
public class TouristEntity : BaseEntity
{
    public string PassportData { get; set; } = string.Empty;
    public DateOnly Birthdate { get; set; }


    public int UserId { get; set; }
    public UserEntity User { get; set; } = null!;


    public ICollection<BookingEntity> Bookings { get; set; } = new List<BookingEntity>();
}
