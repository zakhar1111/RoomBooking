namespace RoomBooking.Domain.Entities;

using RoomBooking.Domain.Statuses;

public class Booking
{
    public int Id { get; set; }

    public decimal TotalPrice { get; set; }
    public DateTime DateCheckIn { get; set; }
    public DateTime DateCheckOut { get; set; }

    public int Adults { get; set; }
    public int Children { get; set; }


    public int GuestId { get; set; } //FK
    public BookingStatusEnum Status { get; set; } = BookingStatusEnum.Draft;
}
