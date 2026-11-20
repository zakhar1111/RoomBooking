namespace RoomBooking.Domain.Entities;

using RoomBooking.Domain.Statuses;

public class Payment
{ 
    public int Id { get; set; }

    public decimal Amount { get; set; }
    public DateTime PayAt { get; set; }


    public int BookingId { get; set; } //FK
    public PayStatusEnum Status { get; set; } = PayStatusEnum.Created;
}
