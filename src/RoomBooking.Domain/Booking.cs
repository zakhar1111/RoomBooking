namespace RoomBooking.Domain;

public class Booking
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime DateCheckIn { get; set; }
    public DateTime DateCheckOut { get; set; }


    public int GuestId { get; set; } //FK
    public int BookingStatusId { get; set; } //FK
}
