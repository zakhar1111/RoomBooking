namespace RoomBooking.Domain.Statuses;

public class RoomStatus 
{
    public int Id { get; set; }
    public RoomStatusEnum Name { get; set; }
}

public enum RoomStatusEnum
{
    Clean,
    Dirty,
    Maintenance,
    OutOfService
}
