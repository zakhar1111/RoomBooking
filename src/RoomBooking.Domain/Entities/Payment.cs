namespace RoomBooking.Domain.Entities;

public class Payment
{ 
    public int Id { get; set; }

    public decimal Amount { get; set; }
    public DateTime PayAt { get; set; }


    public int BookingStatusId { get; set; } //FK
    public int PayStatusId { get; set; }  //FK
}