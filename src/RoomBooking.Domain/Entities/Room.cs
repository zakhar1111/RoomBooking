namespace RoomBooking.Domain.Entities;

public class Room 
{
    public int Id { get; set; }
    public int Number { get; set; }
    public int Floor { get; set; }

    public int RoomStatusId { get; set; } //FK
    public int RoomTypeId { get; set; }   //FK
    public int HotelId { get; set; }      //FK
}