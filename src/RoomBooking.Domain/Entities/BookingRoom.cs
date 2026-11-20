namespace RoomBooking.Domain.Entities;

public class BookingRoom
{
    public int Id { get; set; }
    public decimal PricePerNight { get; set; }

    public int RoomId { get; set; } //FK
    public int BookingId { get; set; } //FK
}
