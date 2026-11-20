namespace RoomBooking.Domain.Entities;

public class RoomTypeFeature
{ 
    public int Id { get; set; }
    public int RoomTypeId { get; set; } //FK
    public int FeatureId { get; set; } //FK
}