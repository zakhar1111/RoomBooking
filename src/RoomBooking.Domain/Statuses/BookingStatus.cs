namespace RoomBooking.Domain.Statuses;

public class BookingStatus
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public enum BookingStatusEnum
{
    PendingPayment = 1,
    Confirmed = 2,
    CheckIn = 3,
    CheckOut = 4,
    Draft = 5
}
