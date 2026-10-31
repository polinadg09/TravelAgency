using System.ComponentModel.DataAnnotations.Schema;
using TravelAgency.Context.Entities.Base;
using TravelAgency.Context.Entities.Enums;

namespace TravelAgency.Context.Entities;

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


    // профиль туриста может быть у любого пользователя, в том числе у менеджера
    public TouristEntity? Tourist { get; set; }
}
