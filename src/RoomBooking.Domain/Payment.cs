namespace RoomBooking.Domain;

public class Payment
{ 
    public int Id { get; set; }

    public decimal Amount { get; set; }
    public DateTime PayAt { get; set; }


    public int BookingStatusId { get; set; }
    public int PayStatusId { get; set; }
}