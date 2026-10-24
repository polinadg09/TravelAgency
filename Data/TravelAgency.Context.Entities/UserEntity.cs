using System.ComponentModel.DataAnnotations.Schema;

namespace TravelAgency.Context.Entities;

/// <summary>Пользователь системы: данные для входа и общие персональные данные.</summary>
[Table("users")]
public class UserEntity
{
    public Guid Id { get; set; }

    public string Login { get; set; } = string.Empty;

    /// <summary>Хэш пароля. Пароль в открытом виде не хранится.</summary>
    public string PasswordHash { get; set; } = string.Empty;

    public UserRoleEnum Role { get; set; }

    public string Email { get; set; } = string.Empty;

    public string? PhoneNumber { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string? Patronymic { get; set; }

    /// <summary>
    /// Профиль туриста. Может быть у любого пользователя, в том числе у менеджера:
    /// так менеджер бронирует тур для себя.
    /// </summary>
    public TouristEntity? Tourist { get; set; }
}
