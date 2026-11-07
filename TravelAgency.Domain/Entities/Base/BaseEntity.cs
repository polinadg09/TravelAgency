using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Domain.Entities.Base;

/// <summary>Базовый класс сущностей: от него наследуется идентификатор.</summary>
public abstract class BaseEntity
{
    public Guid Id { get; set; }
}