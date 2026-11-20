namespace RoomBooking.Domain.Statuses;

public class PayStatus
{ 
    public int Id { get; set; }
    public PayStatusEnum Status { get; set; }
}

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