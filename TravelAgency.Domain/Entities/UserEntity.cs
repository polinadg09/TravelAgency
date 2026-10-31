using System.ComponentModel.DataAnnotations.Schema;
using TravelAgency.Domain.Entities.Base;
using TravelAgency.Domain.Enums;

namespace TravelAgency.Domain.Entities;

[Table("users")]
public class UserEntity : BaseEntity
{
    public string Login { get; set; } = string.Empty;
    public UserRoleEnum Role { get; set; }
    public string Email { get; set; } = string.Empty;
    public string? PhoneNumber { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string? Patronymic { get; set; }
    
    public TouristEntity? Tourist { get; set; }
}
