namespace RoomBooking.Domain;

public class BookingRoom
{
    public int Id { get; set; }
    public decimal PricePerNight { get; set; }

    public int RoomId { get; set; } 
    public int BookingId { get; set; }
}
