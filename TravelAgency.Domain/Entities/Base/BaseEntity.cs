using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Domain.Entities.Base;

/// <summary>Базовый класс сущностей</summary>
public class BaseEntity : IBaseEntity
{
    [Key]
    public int Id { get; set; }

  
    public Guid ExternalId { get; set; } = Guid.NewGuid();

    public DateTime CreationTime { get; set; } = DateTime.UtcNow;

    public DateTime ModificationTime { get; set; } = DateTime.UtcNow;
}
