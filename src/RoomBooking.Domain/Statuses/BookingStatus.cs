namespace RoomBooking.Domain.Statuses;

public class BookingStatus
{
    public int Id { get; set; }
    public BookingStatusEnum Status { get; set; }
}

public enum BookingStatusEnum
{
    Confirmed,
    CheckIn,
    CheckOut,
    Draft
}
