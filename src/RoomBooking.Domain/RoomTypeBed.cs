namespace RoomBooking.Domain;

public class RoomTypeBed
{
    public int Id { get; set; }
    public int RoomTypeId { get; set; } //FK
    public int BedTypeId { get; set; } //FK

    public int Quantity { get; set; }
}
