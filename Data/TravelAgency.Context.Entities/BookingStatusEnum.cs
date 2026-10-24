namespace TravelAgency.Context.Entities;

/// <summary>Статус бронирования.</summary>
public enum BookingStatusEnum
{
    /// <summary>Создано, ожидает подтверждения оплаты.</summary>
    Pending,

    /// <summary>Оплата подтверждена менеджером.</summary>
    Paid,

    /// <summary>Отменено туристом или менеджером.</summary>
    Cancelled
}
