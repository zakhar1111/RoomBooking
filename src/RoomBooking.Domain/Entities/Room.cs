namespace RoomBooking.Domain.Entities;

using RoomBooking.Domain.Statuses;

public class Room 
{
    public int Id { get; set; }
    public int Number { get; set; }
    public int Floor { get; set; }

    public HousekeepingStatus HousekeepingStatus { get; set; }
    public RoomOperationalStatus OperationalStatus { get; set; }
    public int RoomTypeId { get; set; }   //FK
    public int HotelId { get; set; }      //FK
}
