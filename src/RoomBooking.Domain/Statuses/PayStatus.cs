namespace RoomBooking.Domain.Statuses;

public enum PayStatusEnum
{
    Created,
    Authorized,
    Paid,
    Failed,
    Refunded,
    Canceled = 9
}
