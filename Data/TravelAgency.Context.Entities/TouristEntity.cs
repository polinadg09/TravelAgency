using System.ComponentModel.DataAnnotations.Schema;
using TravelAgency.Context.Entities.Base;

namespace TravelAgency.Context.Entities;

[Table("tourists")]
public class TouristEntity : BaseEntity
{
    public string PassportData { get; set; } = string.Empty;
    public DateOnly Birthdate { get; set; }


    public int UserId { get; set; }
    public UserEntity User { get; set; } = null!;


    public ICollection<BookingEntity> Bookings { get; set; } = new List<BookingEntity>();
}
