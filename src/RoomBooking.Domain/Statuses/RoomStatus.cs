namespace RoomBooking.Domain.Statuses;

public class RoomStatus 
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public enum RoomStatusEnum
{
    Clean = 1,
    Dirty = 2,
    Maintenance = 3,
    OutOfService = 4
}
