namespace RoomBooking.Domain.Entities;

public class BookingExtra
{
    public int Id { get; set; }
    public int Quantity { get; set; }

    public int BookingId { get; set; } //FK
    public int ExtraId { get; set; } //FK
}
