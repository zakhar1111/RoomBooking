namespace RoomBooking.Domain.Statuses;

public enum PayStatusEnum
{
    Created,
    Authorized,
    Paid,
    Failed,
    Refunded,
    PendingPayment,
    Unpaid,
    PartiallyPaid,
    FullyPaid,
    Canceled
}
