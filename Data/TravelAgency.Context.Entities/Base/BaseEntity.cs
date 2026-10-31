using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Context.Entities.Base;

/// <summary>Базовый класс сущностей: от него наследуются идентификаторы.</summary>
public class BaseEntity : IBaseEntity
{
    [Key]
    public int Id { get; set; }

    /// <summary>Публичный идентификатор (его отдаём наружу вместо внутреннего Id).</summary>
    public Guid ExternalId { get; set; } = Guid.NewGuid();

    // UTC, потому что Npgsql не принимает локальное время для timestamptz
    public DateTime CreationTime { get; set; } = DateTime.UtcNow;

    public DateTime ModificationTime { get; set; } = DateTime.UtcNow;
}
